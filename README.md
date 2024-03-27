# Converter Project

This project includes a converter tool that converts XML files to CSV format. It reads data from XML files, processes it and exports it to CSV file.

- In the CreateTempDirectories method, it checks if the temporary folder exists and creates it if it doesn't.
- In the ConvertXmlToCsv method, it reads an XML file and converts its data into CSV format.
  - It cleans up spaces in the XML data using the CleanXmlData method.
  - Errors encountered during CSV writing are logged.
  - Results are communicated to the user via Messageboxes.
- ProcessXmlData method deserializes the XML data using the DeserializeXmlData method.
- Data is written to the CSV file using the WriteToCsv method.
- ValueObjectBase represents attribute or text values in XML files.
- GetValue method returns the value of a ValueObjectBase object. If the object is not null and the attribute value is not empty, the value of the attribute is returned.
