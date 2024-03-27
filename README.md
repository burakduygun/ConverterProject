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
- Unit tests using Xunit were written for the FileManager.cs class where business operations take place.
---
- When there is a root element named Tinfos within the XML, the conversion process to .csv begins. Conversion is not performed for XML files that do not start with the Tinfos root element. Errors occurring during writing to the .csv file are logged.
- All elements within UsageStat,
- Only AppVersion element within AppInformation,
- Only DbSize within the Db element within DbInformation tag,
- Elements LicensedUserCount, UserCount, LemActive, and MobileUserCount within UserInformation are included as columns during the conversion process.
- When the last values in the col tags in the Row in FirmStat are removed, the FirmStat method is put in the comment line because there is no value left in the FirmStat tag. This method can be opened and executed on demand.
- Unique maximum column count is generated from the converted data within the XML, and values are assigned. If a value is not present in the corresponding XML row, the column is left blank for that row.
- The ValueObjectBase class is used for XML serialization. This class is used to write a specific value both as an XML attribute and as text.
