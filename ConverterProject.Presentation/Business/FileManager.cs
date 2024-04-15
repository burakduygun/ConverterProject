using OfficeOpenXml;
using Serilog;
using System.Configuration;
using System.Xml.Linq;

namespace ConverterProject.Presentation.Business
{
    public static class FileManager
    {
        private static readonly ILogger Logger = Log.Logger.ForContext(typeof(FileManager));

        public static void ConvertXmlToCsv(string readFilePath, string writeFilePath, string customFileName, bool isTest = false)
        {
            string message = string.Empty;

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                int failedRow = 0;
                int allRow = 0;

                List<Dictionary<string, string>> csvDataList = new List<Dictionary<string, string>>();

                using (ExcelPackage package = new ExcelPackage(new FileInfo(readFilePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    allRow = worksheet.Dimension.End.Row - 1;

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        string productKey = worksheet.Cells[row, 1].Value.ToString();
                        string xmlData = worksheet.Cells[row, 2].Value.ToString();

                        try
                        {
                            XElement xmlElement = XElement.Parse(xmlData);
                            Dictionary<string, string> rowData = ProcessXmlData(xmlElement, productKey);
                            csvDataList.Add(rowData);
                        }
                        catch (Exception ex)
                        {
                            failedRow++;
                            Logger.Error($"Satır {row}: XML verisi işlenemedi. Error: {ex.Message}");
                        }
                    }
                }

                WriteToCsv(csvDataList, writeFilePath, customFileName);

                message = $"Dönüştürme işlemi tamamlandı. " +
                            $"\nToplam kayıt sayısı: {allRow} " +
                            $"\nBaşarılı kayıt sayısı: {allRow - failedRow}" +
                            $"\nHatalı kayıt sayısı: {failedRow}" +
                            $"\nHatalı kayıtlar için " +
                            $"{Path.GetFullPath(ConfigurationManager.AppSettings["serilog:write-to:File.path"]!)} " +
                            $"dosyasını inceleyebilirsiniz.";
            }
            catch (Exception ex)
            {
                message = "Dönüştürme sırasında bir hata oluştu: " + ex.Message;
            }

            if (!isTest)
                MessageBox.Show(message, "Result", MessageBoxButtons.OK);
        }

        public static Dictionary<string, string> ProcessXmlData(XElement xmlRoot, string productKey)
        {
            Dictionary<string, string> rowData = new Dictionary<string, string>();

            rowData["ProductKey"] = productKey;

            return ProcessXmlElement(xmlRoot, rowData);

        }

        private static Dictionary<string, string> ProcessXmlElement(XElement xmlRoot, Dictionary<string, string> rowData)
        {
            foreach (XElement childElement in xmlRoot.Elements())
            {
                if (childElement.HasElements)
                {
                    ProcessXmlElement(childElement, rowData);
                }
                else
                {
                    if (childElement.HasAttributes)
                    {
                        foreach (XAttribute attribute in childElement.Attributes())
                        {
                            if (attribute.Name == "Name" && childElement.Attribute("UsageCount") != null)
                            {
                                rowData[attribute.Value.ToUpper()] = childElement.Attribute("UsageCount")!.Value;
                            }
                            else if (attribute.Name == "Name" && childElement.Attribute("Value") != null)
                            {
                                rowData[attribute.Value.ToUpper()] = childElement.Attribute("Value")!.Value;
                            }
                            else if (attribute.Name == "Value" && !childElement.HasAttributes)
                            {
                                rowData[childElement.Name.LocalName.ToUpper()] = attribute.Value;
                            }
                        }
                    }
                    else
                    {
                        rowData[childElement.Name.LocalName.ToUpper()] = childElement.Value;
                    }
                }
            }
            return rowData;
        }

        public static void WriteToCsv(List<Dictionary<string, string>> csvDataList, string filePath, string customFileName)
        {
            string fileName = string.IsNullOrEmpty(customFileName) ? DateTime.Now.ToString("ddMMyyyyHHmm") : customFileName;

            using (StreamWriter writer = new StreamWriter(Path.Combine(filePath, $"{fileName}.csv"), false))
            {
                var allKeys = csvDataList.SelectMany(x => x.Keys).Distinct().ToList();
                writer.WriteLine(string.Join(",", allKeys));

                csvDataList.ForEach(data =>
                {
                    writer.WriteLine(string.Join(",", allKeys.Select(key => data.ContainsKey(key) ? data[key] : "")));
                });
            }
        }
    }
}
