# Converter Project
Bu proje, XML verilerini Excel dosyalarından CSV formatına dönüştüren bir dönüştürücü aracı içerir. Excel dosyalarındaki verileri okur, XML içeriğini işler ve işlenen verileri bir CSV dosyasına aktarır.

- ConvertXmlToCsv yöntemi bir Excel dosyasını okur ve XML verilerini CSV biçimine dönüştürür. XML verilerini ayrıştırmak için XElement sınıfını kullanır ve bir sözlük biçiminde işler.
- XML ayrıştırma veya CSV yazma sırasında karşılaşılan hatalar Serilog kullanılarak günlüğe kaydedilir.
- Dönüşüm sonuçları mesaj kutuları aracılığıyla kullanıcıya iletilir.
- ProcessXmlData yöntemi XML verilerini ayrıştırır ve sözlük girdilerine eşler.
- ProcessXmlElement yöntemi XML öğelerini işler
- CSV verileri WriteToCsv yöntemi kullanılarak bir dosyaya yazılır. XML verilerindeki tüm benzersiz anahtarları sütun başlıkları olarak içerir.
- FileManager.cs sınıfı için Xunit kullanan birim testleri yazılmıştır.
