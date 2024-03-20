using ConverterProject.Models;
using OfficeOpenXml;
using Serilog;
using System.Configuration;
using System.Xml.Serialization;

namespace ConverterProject.Presentation.Business
{
    public static class FileManager
    {
        private static readonly ILogger Logger = Log.Logger.ForContext(typeof(FileManager));

        public static void CreateTempDirectories()
        {
            if (!Directory.Exists(AppConstants.TempFolderPath))
            {
                Directory.CreateDirectory(AppConstants.TempFolderPath);
            }
        }

        public static void ConvertXmlToCsv(string readFilePath, string writeFilePath, string customFileName, bool isTest = false)
        {
            string message = string.Empty;

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                int failedRow = 0;
                int allRow = 0;

                List<(string, Dictionary<string, string>)> csvDataList = new List<(string, Dictionary<string, string>)>();

                using (ExcelPackage package = new ExcelPackage(new FileInfo(readFilePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    allRow = worksheet.Dimension.End.Row > 0 ? worksheet.Dimension.End.Row - 1 : 0;

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        string productKey = worksheet.Cells[row, 1].Value.ToString()!;
                        string xmlData = CleanXmlData(worksheet.Cells[row, 2].Value.ToString()!);

                        if (xmlData.StartsWith(AppConstants.StartNode))
                        {
                            try
                            {
                                TINFOs tINFOs = DeserializeXmlData(xmlData);

                                Dictionary<string, string> rowData = new Dictionary<string, string>();

                                tINFOs.USAGESTAT?.FORMS?.ForEach(form => rowData[form.Name] = form.UsageCount.ToString());

                                tINFOs.FIRMSTAT?.ROW?.COLS?.ForEach(col => rowData[col.Name] = col.Value.ToString());

                                csvDataList.Add((productKey, rowData));
                            }
                            catch (InvalidOperationException ex)
                            {
                                failedRow++;
                                Logger.Error($"Satır {row}: XML verisi işlenemedi. Error: {ex.Message}");
                            }
                        }
                        else
                            throw new Exception("Dosya formatı uygun değil!");
                    }
                }

                WriteToCsv(csvDataList, writeFilePath, customFileName);
                message = $"Dönüştürme işlemi tamamlandı. " +
                                $"\nToplam kayıt sayısı: {allRow} " +
                                $"\nBaşarılı kayıt sayısı: {allRow - failedRow}" +
                                $"\nHatalı kayıt sayısı: {failedRow}" +
                                $"\nHatalı kayıtlar için {ConfigurationManager.AppSettings["serilog:write-to:File.path"]} log dosyasını inceleyebilirsiniz.";
            }
            catch (Exception ex)
            {
                message = "Dönüştürme sırasında bir hata oluştu: " + ex.Message;
            }

            if (!isTest)
                MessageBox.Show(message, "Result", MessageBoxButtons.OK);
        }

        public static TINFOs DeserializeXmlData(string xmlData)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TINFOs));
            using (StringReader reader = new StringReader(xmlData))
            {
                return (TINFOs)serializer.Deserialize(reader)!;
            }
        }

        public static void WriteToCsv(List<(string, Dictionary<string, string>)> csvDataList, string filePath, string customFileName)
        {
            string fileName = string.IsNullOrEmpty(customFileName) ? DateTime.Now.ToString("ddMMyyyyHHmm") : customFileName;

            using (StreamWriter writer = new StreamWriter(Path.Combine(filePath, $"{fileName}.csv"), false))
            {
                var allKeys = csvDataList.SelectMany(x => x.Item2.Keys).Distinct().ToList();
                writer.WriteLine($"ProductKey,{string.Join(",", allKeys)}");

                csvDataList.ForEach(data =>
                {
                    writer.WriteLine($"{data.Item1},{string.Join(",", allKeys.Select(key => data.Item2.ContainsKey(key) ? data.Item2[key] : ""))}");
                });
            }
        }

        private static string CleanXmlData(string xmlData)
        {
            return xmlData.Trim();
        }
    }
}
