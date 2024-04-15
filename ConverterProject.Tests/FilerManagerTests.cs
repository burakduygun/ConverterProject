using ConverterProject.Presentation.Business;

namespace ConverterProject.Tests
{
    public class FilerManagerTests
    {
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