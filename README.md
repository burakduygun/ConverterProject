# Converter Project
This project includes a converter tool that converts XML data from Excel files to CSV format. It reads data from Excel files, processes the XML content, and exports the processed data to a CSV file.

- The ConvertXmlToCsv method reads an Excel file and converts the XML data to CSV format. It uses the XElement class to parse XML data and processes it in the form of a dictionary.
- Errors encountered while parsing XML or writing CSV are logged using Serilog.
- Conversion results are delivered to the user via message boxes.
- The ProcessXmlData method parses XML data and maps it to dictionary entries.
- ProcessXmlElement method processes XML elements
- CSV data is written to a file using the WriteToCsv method. It contains all unique keys in the XML data as column headers.
- Written unit tests using Xunit for the FileManager.cs class.
