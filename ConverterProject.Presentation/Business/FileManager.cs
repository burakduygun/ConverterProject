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

                        xmlData = xmlData.Replace("TINFOs", "TINFOS");

                        try
                        {
                            Dictionary<string, string> rowData = ProcessXmlData(xmlData);
                            csvDataList.Add((productKey, rowData));
                        }
                        catch (InvalidOperationException ex)
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

        public static Tinfos DeserializeXmlData(string xmlData)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Tinfos));
            using (StringReader reader = new StringReader(xmlData))
            {
                return (Tinfos)serializer.Deserialize(reader)!;
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

        public static Dictionary<string, string> ProcessXmlData(string xmlData)
        {
            Tinfos tINFOs = DeserializeXmlData(xmlData);

            Dictionary<string, string> rowData = new Dictionary<string, string>();

            ProcessUsageStats(tINFOs.UsageStat?.Forms!, rowData);
            //ProcessFirmStats(tINFOs.FIRMSTAT, rowData);
            ProcessAppInformation(tINFOs.AppInformation, rowData);
            ProcessDBInformation(tINFOs.DbInformation, rowData);
            ProcessUserInformation(tINFOs.UserInformation, rowData);

            return rowData;
        }

        public static void ProcessDBInformation(DbInformation? dbInfo, Dictionary<string, string> rowData)
        {
            rowData["DBSIZE"] = ValueObjectBase.GetValue(dbInfo?.Db?.DbSize!);
        }

        public static void ProcessFirmStats(FirmStat? firmStat, Dictionary<string, string> rowData)
        {
            firmStat?.Row?.Cols?.ForEach(col => rowData[col.Name] = col.Value.ToString());
        }

        public static void ProcessUsageStats(List<UsageStatForm> forms, Dictionary<string, string> rowData)
        {
            forms?.ForEach(form => rowData[form.Name] = form.UsageCount.ToString()!);
        }

        public static void ProcessUserInformation(UserInformation? userInfo, Dictionary<string, string> rowData)
        {
            rowData["USERCOUNT"] = ValueObjectBase.GetValue(userInfo?.UserCount!)!;
            rowData["LICENSEDUSERCOUNT"] = ValueObjectBase.GetValue(userInfo?.LicensedUserCount!)!;
            rowData["MOBILEUSERCOUNT"] = userInfo?.MobileUserCount?.Value.ToString()!;
        }

        public static void ProcessAppInformation(AppInformation? appInfo, Dictionary<string, string> rowData)
        {
            rowData["APPVERSION"] = ValueObjectBase.GetValue(appInfo?.AppVersion!)!;
        }
    }
}
