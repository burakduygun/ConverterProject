using ConverterProject.Presentation.Business;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System.Windows.Forms;

namespace ConverterProject.Tests
{
    public class FilerManagerTests
    {
        [Fact]
        public void CreateTempDirectories_ShouldCreateDirectory_IfNotExist()
        {
            // Arrange
            Directory.Delete(AppConstants.TempFolderPath, true);

            // Act
            FileManager.CreateTempDirectories();

            // Assert
            Assert.True(Directory.Exists(AppConstants.TempFolderPath));
        }

        [Fact]
        public void ConvertXmlToCsv_Successfully()
        {
            // Arrange
            string readFilePath = AppConstants.ReadFilePath;
            string writeFilePath = AppConstants.WriteFilePath;

            // Act
            FileManager.ConvertXmlToCsv(readFilePath, writeFilePath,AppConstants.TestTextData,true);
     
            // Assert
            Assert.True(Directory.GetFiles(writeFilePath).Length > 0);
        }
    }
}