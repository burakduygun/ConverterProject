# Converter Project
Bu proje, XML dosyalarını CSV formatına dönüştüren bir projedir. XML dosyalarından verileri okur, işler ve CSV dosyasına aktarır.

- CreateTempDirectories metodunda geçici klasörün var olup olmadığı kontrol ediyor ve yoksa oluşturuyor.
- ConvertXmlToCsv metodunda bir Xml dosyasını okuyup içersindeki verileri csv formatına dönüştürüyor
  - CleanXmlData metodu ile Xml deki boşlukları temizleniyor.
  - Csv’ye yazılırken hatalı durumlar loglanıyor.
  - Messageboxlar ile sonuç kullanıcıya bildiriliyor.
- ProcessXmlData metodu, DeserializeXmlData metoduyla Xml deserailize ediliyor.
- WriteToCsv metoduyla Csv dosyasına veriler yazılıyor.
- ValueObjectBase XML dosyalarındaki öznitelik veya metin değerlerini temsil ediyor.
- GetValue metodu bir ValueObjectBase nesnesinin değerini döndürür. Eğer nesne null değilse ve öznitelik değeri boş değilse, özniteliğin değeri döndürülür.
- Bussiness işlemlerinin olduğu FileManager.cs classı için Xunit kullanılarak unit testler yazıldı.
---
- Xml içerisinde Tinfos kök elementi olduğu durumda .csv'ye dönüştürme işlemi başlatılıyor. Tinfos kök elementiyle başlamayan xml'lerde dönüştürme yapılmıyor. Csv’ye yazılırken hatalı durumlar loglanıyor.
- UsageStat içerisinde ki tüm elementler,
- AppInformation içerisinde ki sadece AppVersion elementi,
- DbInformation tagi içindeki Db içerisinde ki sadece DbSize,
- UserInformation içerisinde ki LicensedUserCount, UserCount, LemActive ve MobileUserCount elementleri dönüştürme sırasında kolon olarak dahil ediliyor.
- FirmStat içindeki Row içindeki col taglerinin içindeki last'lı değerler kaldırıldığında, - FirmStat tagi içinde hiçbir değer kalmadığı için FirmStatı okuyan metod yorum satırına alınmıştır. Bu yöntem, istendiğinde açılabilir ve çalışabilir durumdadır.
- Xml içerisinde dönüştürülen verilerden benzersiz bir şekilde maksimum kolon sayısı yaratılıp değerler atanıyor. Değerin ilgili xml satırında olmaması durumunda o satır için o kolon boş geçiliyor.
- ValueObjectBase sınıfı, XML serileştirmesi için kullanılıyor. Bu sınıf, belirli bir değeri hem XML attribute olarak hem de text olarak yazmak için kullanılır.
