# Yapılacaklar Listesi 📝

C# ile yazılmış basit bir konsol yapılacaklar listesi (To-Do) uygulaması. C# öğrenme sürecimdeki üçüncü projem.

## Ne yapıyor?

Program açılınca bir menü gösterir, kullanıcı numarayla seçim yapar:

- **1 – Ekle:** Yeni bir görev, son tarih ve öncelik (1 Düşük, 2 Orta, 3 Yüksek) yazılır, listeye eklenir (oluşturma tarihi otomatik eklenir)
- **2 – Listele:** Görevler numaralı olarak alt alta yazdırılır, yanlarında durumları, oluşturma tarihleri, son tarihleri ve öncelikleri görünür
- **3 – Sil:** Görevler numaralı gösterilir, kullanıcı silmek istediği görevin numarasını yazar
- **4 – Tamamlandı:** Kullanıcı, tamamladığı görevin numarasını girerek görevi tamamlandı olarak işaretler
- **5 – Düzenle:** Görevler numaralı gösterilir, kullanıcı düzenlemek istediği görevin numarasını ve yeni başlığı yazar
- **6 – Bitmeyenler:** Sadece tamamlanmamış görevler, önceliğe göre (Yüksek en üstte) numarasız gösterilir
- **7 – Çıkış:** Program kapanır
- Her işlemden sonra menü tekrar gösterilir
- Görevler `gorevler.txt` dosyasına kaydedilir ve program tekrar açılınca yüklenir (görev ekleyince, silince, tamamlandı işaretleyince ve düzenleyince dosya güncellenir). Dosyada her görev tek satırdır: `Başlık;Durum;Oluşturma tarihi;Son tarih;Öncelik`
- Yanlış girişte program kapanmaz:
  - Menüde olmayan bir sayı ya da harf yazılırsa "Geçersiz Seçim" der
  - Silme, tamamlandı işaretleme veya düzenleme sırasında listede olmayan bir numara ya da harf yazılırsa "Geçersiz Numara" der
  - Öncelik için 1, 2 ya da 3 dışında bir şey yazılırsa görev "Orta" öncelikle kaydedilir

```
Lütfen Seçeneklerden Birini Seçiniz
1-) Ekle, 2-) Listele, 3-) Sil, 4-) Tamamlandı 5-) Düzenle 6-) Bitmeyenler 7-) Çıkış
1
Görevinizi Yazınız
Kitap Okumak
Son Tarihinizi Yazınız
1.12.2028
Öncelik seçiniz (1-Düşük, 2-Orta, 3-Yüksek)
3
```

```
Lütfen Seçeneklerden Birini Seçiniz
1-) Ekle, 2-) Listele, 3-) Sil, 4-) Tamamlandı 5-) Düzenle 6-) Bitmeyenler 7-) Çıkış
4
Tamamlamak istediğiniz görevin numarasını yazınız
4
Tamamlandı olarak işaretlendi
Lütfen Seçeneklerden Birini Seçiniz
1-) Ekle, 2-) Listele, 3-) Sil, 4-) Tamamlandı 5-) Düzenle 6-) Bitmeyenler 7-) Çıkış
6
Kitap Okumak (Tamamlanmadı) - 05.11.2026 23:58 - Son Tarih: 1.12.2028 - Öncelik: Yuksek
Geziye Gitmek (Tamamlanmadı) - 05.11.2026 23:59 - Son Tarih: 1.12.2029 - Öncelik: Yuksek
Resim Çizmek (Tamamlanmadı) - 05.11.2026 23:58 - Son Tarih: 1.12.2028 - Öncelik: Orta
Müzeye Gitmek (Tamamlanmadı) - 05.11.2026 23:59 - Son Tarih: 1.12.2030 - Öncelik: Dusuk
```

(Gerçek test çıktılarım: Kitap Okumak görevini ekleme ve "Okula gitmek" görevini tamamlayıp Bitmeyenler listesini açma. Araları okunaklı olsun diye çıkarıldı.)

## Kullanılanlar

- C#
- .NET 10

## Dosyalar

- `Program.cs`: menü ve `switch` içindeki işlemler
- `GorevYoneticisi.cs`: görev listesini (`Gorevler`) tutar, `Kaydet` ve `Yukle` metotları burada
- `Gorev.cs`: bir görevin bilgileri (başlık, tamamlandı, oluşturma tarihi, son tarih, öncelik)
- `Oncelik.cs`: öncelik seçenekleri (`Dusuk`, `Orta`, `Yuksek`)

## Nasıl çalıştım?

- Bu projeyi de yapay zekâ ile soru-cevap şeklinde ilerleyerek yapıyorum. V1, V2, V4, V5, V6, V7, V8 ve V9'da Claude kullandım. V3'ün başını Claude ile yaptım, haftalık hakkım bitince devamını ChatGPT ile yaptım. Her adımda yapay zekâ bana sorular soruyor, ipuçları veriyor ve kavramları açıklıyor.
- Kod satırlarını kendim yazıyorum. Takıldığım yerde önce küçük ipucu, sonra boşluk doldurma şeklinde yardım istiyorum. Bazı yerlerde çözümü yapay zekâ gösterdi, bunları aşağıda açıkça yazdım.
- Planı ve fikirleri birlikte oluşturduk. README metinlerini de yapay zekâ ile birlikte düzenledim.
- Her değişiklikten sonra programı kendim test ettim.

## Bu projede öğrendiklerim

### Versiyon 1

- Menü satırlarını `Console.WriteLine` ile kendim yazdım. Yapay zekânın "lokanta menüsü" benzetmesini yanlış anlayıp ilk denemede "İçecekler" yazdım, sonra düzelttim. "Tıklayınız" yazmıştım → yapay zekâ konsolda tıklama olmadığını söyledi, "Seçiniz" yaptım
- Seçimi almak için `int secim;` yazdım ama kutuyu boş bıraktım → yapay zekâ okuma komutunun `=`'den sonra yazılabileceğini söyledi. Önce `Add` yazdım, ipucuyla `Console.ReadLine` komutunu buldum. Parantezleri unuttum, `WriteLine` ile karşılaştıran ipucuyla ekledim
- `Console.ReadLine()`'ın her zaman yazı (metin) verdiğini ve `int` kutusuna doğrudan girmediğini yapay zekâ açıkladı. "Metin kutusu kullanmak" ya da "sayıya çevirmek" seçeneklerinden sayıya çevirmeyi ben seçtim
- Güvenli çeviri komutunun `TryParse` olduğunu hatırladım. Çökeni `ToString` sandım → yapay zekâ `ToString`'in ters yönde çevirdiğini, çökenin `Parse` olduğunu söyledi
- TryParse satırını hesap makinesindeki SayiAl metoduna bakarak yazmaya çalıştım. `out`'tan sonra `sayi` değil `secim` gelmesi gerektiğini kendim fark ettim. TryParse'ın evet / hayır (`bool`) döndürdüğünü ve sayının `out` ile geldiğini yapay zekâ kargo benzetmesiyle açıkladı, satırı boşluk doldurma ile yazdım. Kutuya `true` adını vermeye çalıştım → yapay zekâ `true`'nun ad değil değer olduğunu açıkladı. `gecerli` adını yapay zekâ önerdi
- Aynı değişkeni (`secim`) farklı değerlerle karşılaştırdığımız için `switch` kullanmayı ben seçtim. İlk denemede `switch (secim)` satırı, `case`'ten sonraki `:` ve bir `;` eksikti, `Case` ve `Switch`'i büyük harfle yazdım, `3`'ü tırnaklı yazdım → yapay zekâ farkları hesap makinesindeki switch ile karşılaştırmamı önerdi ve ipuçları verdi. `secim` sayı kutusu olduğu için tırnak olmayacağını yapay zekâ açıkladı. Son hali boşluk doldurma ile yazdım
- Ekleme için `Add`, listeleme için `foreach`, çıkış için `return` gerektiğini kendim düşündüm. Önce görevleri tutacak bir liste gerektiğini yapay zekâ söyledi. `List<T>` kullanmayı kendim önerdim, `List<string> gorevler = new List<string>();` satırını boşluk doldurma ile yazdım
- İlk denemede `Add.secim` yazdım → yapay zekâ sıranın tersine olduğunu (önce listenin adı, sonra `.Add`) ve eklenecek şeyin menü seçimi değil, kullanıcının yazacağı görev olduğunu açıkladı
- Ekleme kısmında `string = Console.ReadLine();` yazdım, kutunun adı eksikti → ipucuyla `gorev` ekledim. `gorevler.Add(gorev);` satırını kendim yazdım
- Listeleme için `foreach (string gorev in gorevler)` satırını kendim yazdım (foreach'i sık unuttuğumu söyledim, notlarıma baktım). `break`'i foreach'in süslü parantezinin içine koydum → yapay zekâ bunun döngüyü ilk görevde kıracağını söyledi. Dışarı alırken bu sefer case'in sonuna `break` koymayı unuttum, yapay zekâ hatırlattı ve her case'in sonunda zorunlu olduğunu "oda kapısı" benzetmesiyle açıkladı
- `gorev` adında CS0136 hatası aldım → yapay zekâ switch içindeki bütün case'lerin aynı süslü parantezi (kapsamı) paylaştığını, case 1'deki `gorev` yüzünden foreach'te aynı adın kullanılamayacağını açıkladı. `madde` adını yapay zekâ önerdi
- Menüyü tekrarlamak için `while (true)` fikri benimdi. İlk denemede menü ve seçim satırlarını döngünün dışında bıraktım → yapay zekâ menünün bir kere gösterileceğini ve seçimin tekrar sorulmayacağını sordu. Seçim satırlarını içeri aldım. Listenin dışarıda kalması gerektiğini (içeride her turda sıfırlanır) ipucuyla gördüm. Menüyü de içeri almak benim tercihimdi
- Yapay zekâ "case 3'teki `break` while'dan da çıkar mı?" diye sordu. Test ettim: 3'e basınca program kapanmadı, menü tekrar geldi. `break`'in sadece en yakın yapıdan (switch) çıktığını yapay zekâ açıkladı. `return` ile çözdüm, `return` fikri baştan benimdi
- `default` ile geçersiz seçim mesajı ekledim, yapısı notlarımda vardı. İçini Visual Studio otomatik önerdi. "a" yazınca neden "Geçersiz Seçim" çıktığını anlamadım → yapay zekâ TryParse çeviremeyince `secim`'e 0 koyduğunu, case 0 olmadığı için `default`'a düştüğünü açıkladı
- Ekleme, listeleme, çıkış, menüde olmayan sayı (5) ve harf (a) durumlarını ayrı ayrı test ettim

### Versiyon 2

- Sil'in 3, Çıkış'ın 4 olmasına kendim karar verdim ve case numaralarını kendim güncelledim. Menü satırını güncellemeyi unuttum → yapay zekâ fark ettirdi (eksik virgülü de yapay zekâ ekledi). İlk denemede Sil kısmına `string gorev` (V1'deki ad çakışmasının aynısı), `gorevler.Delete(gorev)` ve yine "Tıklayınız" yazdım → yapay zekâ fark ettirdi, silme kısmını adım adım kurmak için önce sadece bir mesaj bıraktık. case 3'ün sonundaki `break`'i unuttum, ipucuyla ekledim
- Numarayla silmek için kullanıcının önce numaraları görmesi gerektiğini yapay zekâ söyledi. Numara saymak için `++` kullanmayı, Sayı Tahmin'deki deneme sayacını hatırlatan ipucuyla buldum. `sira` adını yapay zekâ önerdi. `sira = 0` ve `sira++` satırlarını kendim yazdım (`int` ve `;` ipucuyla eklendi)
- `sira` kutusunu önce `while`'ın dışında oluşturdum → yapay zekâ iki kere üst üste listeleyince numaraların 3, 4'ten devam edeceğini sordu. İlk başta sorunu anlamadım, yapay zekâ adım adım gösterdi. Kutuyu `while`'ın içine almayı kendim önerdim. Taşırken kopyaladım, üstteki eskisini silmeyi unuttum → yapay zekâ fark ettirdi
- Numaralı yazdırmak için `$"..."` kullandım. İlk denemelerde süslü parantezlere `gorev` ve `gorevler` yazdım, sonra sırayı ters koydum (`naber-1`) → yapay zekâ `gorev`'in case 1'e ait olduğunu, `gorevler`'in bütün liste olduğunu açıkladı. `$"{sira}-{madde}"` satırını boşluk doldurma ile yazdım. Birkaç kez üst üste listeleyip numaraların hep 1'den başladığını test ettim
- Sil kısmında listeyi göstermek için case 2'deki `foreach` bloğunu kopyalamayı yapay zekâ önerdi
- Visual Studio'nun yapay zekâ tamamlaması silme kısmının tamamını (`RemoveAt`, `Count`, `numara - 1`, if / else) önerdi. Kabul etmedim, kodu adım adım kendim yazdım; ama yönü bu öneride önceden görmüş oldum
- Kullanıcının yazdığı numarayı almak için menüdeki TryParse satırını örnek aldım. `numara` ve `numaraGecerli` adlarını yapay zekâ önerdi. İlk denemede `out sira` yazdım → yapay zekâ `sira`'nın liste sayacı olduğunu hatırlattı
- Silme satırını yazarken önce `Delete`, sonra `Remove(secim)`, sonra `RemoveAt(secim)` yazdım → yapay zekâ `Remove`'un yazısıyla, `RemoveAt`'ın sıra numarasıyla sildiğini ve `secim`'de menü seçiminin (3) olduğunu açıkladı. Kodu Program.cs'ye yazmadan ilerlediğim için `numara` kutusunu unutmuştum; `gorevler.RemoveAt(numara);` satırının son halini yapay zekâ verdi
- Test ederken program çöktü (ArgumentOutOfRangeException) → yapay zekâ listelerin 0'dan başladığını apartman (zemin kat) benzetmesiyle ve bir tabloyla açıkladı. Tabloya bakarak ekrandaki numara ile listedeki numara arasındaki farkın hep 1 olduğunu buldum. `-1 numara` yazdım, doğru yazılışı (`numara - 1`) yapay zekâ gösterdi
- Yapay zekânın önerdiği testte 9 yazınca da program çöktü. Güvenli numaraların en az 1, en fazla görev sayısı olduğunu kendim söyledim. Görev sayısı değiştiği için sabit yazılamayacağını yapay zekâ söyledi, `Count`'u ipucuyla notlarımdan buldum (önce `?? ""` düşündüm). Notlarımdaki `list`'in benim listemin adı yerine geçtiğini öğrendim
- Kontrol koşulunu yazarken TryParse satırlarını if'in içine koydum, `numaraGecerli` ile `numara`'yı karıştırdım, `1 <` ile 1'i dışarıda bıraktım ve if satırının sonuna `;` koydum → yapay zekâ her birini açıkladı (`;` olursa alttaki satırın her zaman çalışacağını da). Son halini (`numaraGecerli && numara >= 1 && numara <= gorevler.Count`) boşluk doldurma ile yazdım. `=<` diye bir işaret olmadığını öğrendim
- Sonuç mesajlarını eklerken önce ayrı bir if yazdım → yapay zekâ mesajların var olan if'in ve onun `else`'inin içine gireceğini söyledi
- 9, "a" ve geçerli numara ile test ettim. Bir görev silinince alttakilerin numarasının kaydığını gördüm (3-Merhaba → 2-Merhaba)

### Versiyon 3

Bu versiyonun başını Claude ile yaptım. Claude haftalık kullanım hakkım bittiği için devamını (menüye Tamamlandı eklemek, case 4 ve listede durumun görünmesi) ChatGPT ile yaptım. İkisi de hazır kod yerine soru ve ipucuyla ilerledi, ama bazı satırları ikisi de gösterdi. Aşağıda ayırdım.

**Claude ile yaptığım kısım:**

- Görevin yalnızca yazısını değil "bitti mi?" bilgisini de tutmam gerektiğini, bunun için görevi bir "kart" gibi düşünmemi Claude anlattı. `Tamamlandi` kutusunun `bool` olması gerektiğini kendim buldum
- `class Gorev` sınıfını (`Baslik` ve `Tamamlandi`) Sayı Tahmin'deki `Oyuncu` sınıfına bakarak kendim yazdım. `Tamamlandı` diye Türkçe karakterle yazmıştım → Claude fark ettirdi
- `List<string>`'i `List<Gorev>` yaptım. Değiştirince `Add` ve `foreach` satırlarında kırmızı çizgi çıktı; sebebini (liste artık yazı değil kart tutuyor) Claude açıkladı
- case 1'de kalıptan yeni kart çıkarmak için Sayı Tahmin'deki `yeniKart` satırını Claude hatırlattı, boşluk doldurma ile `Gorev yeniGorev = new Gorev();` yazdım (ilk denemede `Oyuncu` yazmıştım). `yeniGorev.Baslik(gorev);` yazdım → Claude özelliğe parantezle değil `=` ile değer konduğunu açıkladı. `gorevler.Add(yeniGorev);` içindeki `yeniGorev`'i kendim buldum

**ChatGPT ile yaptığım kısım:**

- `foreach (string madde in gorevler)` satırının `foreach (Gorev madde in gorevler)` olması gerektiğini ChatGPT gösterdi. `madde.Baslik` kullanmayı da ChatGPT söyledi; "neden böyle yaptık" diye sorunca açıkladı, sonraki soruyu (`madde.Baslik`) doğru cevapladım
- Menüye 4. seçeneği eklemeyi ChatGPT önerdi. Çıkış'ın `case 5` olması gerektiğini ChatGPT fark ettirdi, değişikliği ben yaptım
- case 4'te önce görevleri listelemek için `foreach`'i case 3'ten kopyaladım. Araya `bool Tamamlandi; true` yazmıştım → ChatGPT düzeltti
- Ekrandaki numaranın listede 1 eksik olduğunu (`numara - 1`) kendim hatırladım. "Kullanıcı 2 girerse hangi indeks?" sorusuna yanlış cevap verdim (3), ChatGPT düzeltti
- `gorevler[numara - 1].Tamamlandi = true;` satırını ChatGPT gösterdi. Önce `gorevler.RemoveAt(...)` ve `gorevler.Tamamlandi = true;` yazdım. Listeden numarayla bir göreve `[ ]` ile ulaşmayı ilk kez gördüm, ChatGPT sıfırdan anlattı
- `numara` kutusunu `case 3` ve `case 4`'te ayrı tanımlayınca iki hata aldım ("already defined" ve "unassigned"). ChatGPT sebebini (case'ler aynı kapsamı paylaşıyor) açıkladı ve `int numara;` satırını switch'in üstüne taşımamı söyledi. Taşıdım
- case 4'ün başındaki iki satırı (soru mesajı ve `tamamlamaGecerli` adıyla TryParse) ChatGPT verdi. Önce sırasını karıştırdım, ChatGPT düzeltti. "Numaranın geçerli olup olmadığını kontrol etmemiz lazım" fikri benden geldi; `if` koşulunu case 3'ten uyarlayarak kendim yazdım (`tamamlamaGecerli` adını ChatGPT söyledi). `Count`'un ne olduğunu unutmuştum, ChatGPT hatırlattı
- case 4'ün `if / else` bloğunu (başarı mesajı ve `Geçersiz Numara` mesajı) kendim yazdım
- Listede tamamlanan görevi göstermek için `case 2`'de `if (madde.Tamamlandi == true)` kullanacağımı kendim buldum. İçindeki yazdırma satırlarında zorlandım (`$` işaretini yanlış yere koydum, `Başarısız` yazdım, `#` kullandım). ChatGPT bunları adım adım düzeltti ve `$"{madde.Baslik} (Tamamlandı)"` örneğini gösterdi. `else` kısmını bu örneğe bakarak yazdım. Numaralı son hali (`$"{sira}-{madde.Baslik} (Tamamlandı)"` ve `(Tamamlanmadı)`) ChatGPT yazdı. ChatGPT bir de `case 2`'nin başına `sira = 0;` eklemişti, kabul etmedim; `sira` zaten `while`'ın içinde olduğu için her turda sıfırlanıyor
- Dört görev ekleyip ikincisini tamamlandı olarak işaretledim ve listeyi tekrar açarak durumun göründüğünü kontrol ettim. Silme işlemini de ayrıca test ettim

### Versiyon 4

- Programı kapatınca görevlerin silinmesini çözmek için dosyaya kaydetmeye karar verdik. Dosyaya kart (`Gorev`) yazılamayacağını, sadece yazı yazılabildiğini yapay zekâ hatırlattı (Sayı Tahmin V7'de `ToString` ile görmüştüm). Bir görevin iki bilgisini (başlık ve tamamlandı) tek satıra `;` ile birleştirme fikrini ve `Çiçek sulamak;True` örneğini yapay zekâ gösterdi. `$"..."` kullanacağımı söyledim, ama onu `Console.WriteLine` ile düşünmüştüm → yapay zekâ dosyaya yazmanın ayrı komutlarla yapıldığını söyledi. `$"{madde.Baslik};{madde.Tamamlandi}"` satırını boşluk doldurma ile yazdım
- Dosyaya yazarken her görevi dosyanın sonuna eklemeyi (`AppendAllText`) seçtim. Yapay zekâ "2. görevi silersen, 3.'yü tamamlarsan dosya bunu bilir mi?" diye sordu. Silinen görevin geri geleceğini görünce dosyayı her seferinde baştan yazmanın doğru olduğunu kendim söyledim. `File.WriteAllLines` komutunu ve "önce yazıları bir listede topla, sonra tek seferde yaz" planını yapay zekâ önerdi
- `List<string> satirlar = new List<string>();` satırını kalıbı hatırlayarak yazdım. foreach'te ilk denemede okuduğum ve doldurduğum listeyi karıştırdım (`foreach (string satirlar in ...`, sonra `satirlar.Add(gorevler)`) → yapay zekâ `gorevler`'in kartları tuttuğunu, `satirlar`'ın dosyaya gidecek yazılar olduğunu "bir defterden diğerine aktarmak" benzetmesiyle açıkladı. `foreach (Gorev madde in gorevler)` satırını kendim yazdım. `$"{madde.Baslik};{madde.Tamamlandi}"` içinde yuvarlak parantez kullanmıştım → yapay zekâ süslü parantez gerektiğini söyledi
- `File.WriteAllLines("gorevler.txt", satirlar);` satırının kalıbını yapay zekâ verdi. Önce dosyaya `gorevler`'in gideceğini söyledim, yanlıştı. Yapay zekâ dosyaya kart değil yazı gittiğini açıkladı, sonra boşlukta `satirlar`'ı doğru buldum
- Bu üç parçayı `Kaydet()` adlı bir metoda koymayı yapay zekâ önerdi. Başlığı `public void Kaydet()` yazdım → yapay zekâ `public`'in gerekmediğini (metot sınıfın içinde değil) ve süslü parantez gerektiğini söyledi. İlk denemede üç parçayı süslü parantezin dışında bıraktım, içine taşıdım. `Kaydet();` çağrısını case 1'de `Add`'den sonra, `break`'in üstüne koymayı kendim buldum. Case 3 ve case 4'e de `Kaydet();` koymamı yapay zekâ söyledi. Case 3'te nereye koyacağımı sorunca `break;`'ten önce olması gerektiğini kendim söyledim. Yapay zekâ `if`'in içi ya da dışı olmak üzere iki yer gösterdi, dışını ben seçtim ve gerekçesini de yazdım (iş bittikten sonra kaydetmek). Case 4'te de aynı yere yazdım. Kaydet'in listenin o anki halini yazdığı için değişiklikten sonra çağrılması gerektiğini yapay zekâ açıkladı
- Açılışta okumak için `File.Exists("gorevler.txt")` kontrolünü Sayı Tahmin'deki V7 koduna bakarak kendim yazdım. `string[] satirlar = File.ReadAllLines("gorevler.txt");` ve `foreach (string satir in satirlar)` satırlarını yapay zekâ verdi. Ne yaptıklarını kendi cümlemle anlattım (`satirlar` bütün dosya, `satir` tek satır). `Kaydet`'teki `satirlar` ile çakışmadığını ("yan yana iki ayrı süslü parantez, aynı odayı paylaşmıyorlar") kendim söyledim
- `Split`'i notlarımda olduğunu hatırlamıyordum → yapay zekâ "ekmeği dilimlemek" benzetmesiyle anlattı. `satir.Split(';')` satırını yazdım. Ayraç için önce `'_'`, sonra `''`, sonra `'-'` yazdım (SKU örneğinden kalma), ipuçlarıyla `';'` olduğunu buldum. Parça numaralarını ilk başta karıştırdım (Baslik'in numarasına "1", sonra `Tamamlandi` dedim), yapay zekâ tabloyla gösterdi. `yeniGorev.Baslik = parcalar[0];` satırını case 1'e bakarak yazdım
- `bool.TryParse(parcalar[1], out yeniGorev.Tamamlandi);` satırını yapay zekâ gösterdi. Dosyadan gelen "True" yazısının tekrar `bool`'a çevrilmesi gerektiğini ben söyledim (`int.TryParse` mantığı). Satırın ne yaptığını kendi cümlemle açıkladım. Bu versiyonun en zor kısmıydı. Açılışta okuma bloğunun tamamını (if, ReadAllLines, foreach, Split, yeni kart, Add) yapay zekâ tek parça hâlinde bir araya getirdi, ben `Program.cs`'ye yerleştirdim
- Görev ekleyince `gorevler.txt` dosyasında `Çiçek Sulamak;False` gibi satırları, tamamlandı işaretleyince `...;True` satırını, silince görevin dosyadan gittiğini kontrol ettim. Programı kapatıp açınca 6 görevin ve tamamlandı durumunun geri geldiğini test ettim
- Bilinen sınırlamalar: Görev adında `;` olursa o satır yanlış bölünür. Dosya elle bozulursa (ör. satırda `;` yoksa) program açılırken çökebilir

### Versiyon 5

- Düzenlemek için kullanıcıdan önce bir numara isteyeceğimizi (silme ve tamamlandıdaki gibi) kendim söyledim. Ondan sonra ne istenmesi gerektiğini ilk denemelerde yanlış söyledim (`Tamamlandi`, sonra `new`) → yapay zekâ düzenlemenin görevin yazısını değiştirmek olduğunu hatırlattı, yazıyı tutan kutunun `Baslik` olduğunu `public string Baslik;` satırına bakarak buldum
- Menüde Düzenle'yi 5, Çıkış'ı 6 yapmayı yapay zekânın ipucuyla (Çıkış bir kayacak) buldum. Menü satırını ve `case` numaralarını kendim güncelledim. `case 5`'i önce boş bıraktım, test edebilmek için içine bir mesaj yazmamı yapay zekâ söyledi
- Kullanıcı hangi görevi düzenleyeceğini görsün diye `case 3`'teki `foreach` bloğunu `case 5`'e kopyalamayı yapay zekâ önerdi. Ne yaptığını anlamadım, `madde`, `sira++` ve `foreach`'in kaç tur döneceğini yapay zekâ adım adım açıkladı. `foreach`'in kaç tur döneceğini yanlış tahmin ettim: Listenin numaraları 0'dan başladığı için 3 kartta 4 tur döner sandım. Yapay zekâ `foreach`'in numaraya değil kartlara baktığını, 3 kart için 3 tur döndüğünü ve `sira`'nın 0'dan başlayıp her turda 1 artarak son turda 3 olduğunu tabloyla gösterdi
- Numarayı almak için TryParse satırını boşluk doldurma ile yazdım. `duzenlemeGecerli` adını yapay zekâ verdi, `out numara`'yı kendim buldum. Soruyu ve TryParse satırını `foreach`'ten önce yazmıştım → yapay zekâ sırayı düzeltti (önce liste, sonra soru, sonra numara)
- Numaranın geçerli olup olmadığını kontrol eden `if / else` bloğunu `case 4`'e bakarak yazdım. Yapay zekâ boşluklu bir iskelet verdi, boşlukları (`numara >= 1`, `numara <= gorevler.Count`) ben doldurdum
- Yazarken Visual Studio'nun yapay zekâ tamamlaması düzenleme kısmının tamamını gri yazıyla önerdi. Kabul etmedim. `gorevler[numara - 1].Baslik = Console.ReadLine();` satırını `case 4`'e bakarak kendim yazdım, ama öneride yönünü önceden görmüştüm
- Kullanıcıya ne yazacağını söyleyen bir soru eksikti, bunu yapay zekâ fark ettirdi. "Yeni başlığı yazınız" ve "Görev düzenlendi" mesajlarını yapay zekâ önerdi, ekledim
- `Kaydet();` çağrısını `break;`'in üstüne kendim koydum
- 7 gibi olmayan bir numarayı, 4. görevin başlığını değiştirmeyi ve listelemeyi test ettim. Programı kapatıp açınca yeni başlığın (Kale) dosyadan geldiğini gördüm

### Versiyon 6

- Planda tarih için "oluşturma tarihi, son tarih" yazıyordu. Önce oluşturma tarihini yaptım. Karta yeni bir kutu eklememiz gerektiğini düşünürken "sınıfın içine yeni bir metot mu koymalıyız?" diye sordum, `Baslik` ve `Tamamlandi`'nın ne olduğunu da unutmuştum → yapay zekâ bunların metot değil, kartın üstündeki kutular (özellik) olduğunu, metotların iş yaptığını, tarihin ise bir bilgi olduğu için özellik olacağını açıkladı
- Kutunun türünü önce `int` yazdım → yapay zekâ tarihin tam sayı olmadığını, notlarımdaki `DateTime.Now.ToString(...)` satırındaki `DateTime`'a bakmamı söyledi. `ToString` sayıyı yazıya çeviriyordu diye `string` yazmayı kendim düşündüm. Yapay zekâ `string` ile `DateTime`'ın farkını anlattı (`string` kolay ama tarihleri hesaplayamaz, `DateTime` hesaplar ama dosyadan okurken çeviri ister). V8'de tarihe göre sıralama olmadığını söyleyince `string` ile devam etmeye karar verdim. `public string OlusturmaTarihi;` satırını kendim yazdım
- case 1'de oluşturma tarihini koyan satırı ilk denemede `yeni.Gorev.OlusturulmaTarihi = gorev;` yazdım (kartın adı ters, kutu adı yanlış, sağ tarafa görev yazısı koymuştum) → yapay zekâ üçünü de düzeltti. Sonra `ToString("dd.MM.yyyy HH:mm")`'i başına bir şey koymadan yazdım → yapay zekâ `ToString`'in çevireceği bir şeye ihtiyacı olduğunu söyledi. `DateTime.Now`'ın "şu anı bulmak", `string`'in "kutunun türü" olduğunu ("duvar saatine bakıp kâğıda yazmak" benzetmesiyle) yapay zekâ açıkladı. Tamamlanmış satırı (`DateTime.Now.ToString("dd.MM.yyyy HH:mm")`) ben yazdım
- Listede göstermek için `case 2`'de iki satırın sonuna `- {madde.OlusturmaTarihi}` eklemeyi yapay zekâ söyledi, satırı boşluk doldurma ile yazdım. `if` ve `else` için ayrı mı yapacağım diye sordum, ikisine de aynısının gireceğini yapay zekâ açıkladı. Yeni görevde tarihin göründüğünü, eski görevlerin sonunda boş kaldığını test ettim
- Tarihi dosyaya yazmak için `Kaydet`'teki satırın sonuna bir `;` ve üçüncü kutuyu eklemeyi yapay zekâ söyledi. Ne yaptığını anlamamıştım, yapay zekâ "tarih şu an geçici hafızada, dosyaya yazılmıyor" diye açıkladı. Satırı (`;{madde.OlusturmaTarihi}`) yazdım, ve her parçanın ne işe yaradığını kendi cümlemle anlattım. Dosyada satırların `Başlık;Durum;Tarih` biçiminde yazıldığını kontrol ettim
- Açılışta okuyan bloğa `yeniGorev.OlusturmaTarihi = parcalar[2];` satırını ekledim. Tabloya bakarak üçüncü parçanın numarasını (2) ve kutu adını kendim buldum. Programı kapatıp açınca tarihlerin geldiğini test ettim
- Son tarihi eklemeyi önce yapay zekâ gereksiz bulmuştu (plan şişmesin diye). Bir kullanıcı gözüyle bakmasını isteyince, yapay zekâ bir yapılacaklar listesinde "bunu şu güne kadar bitirmem lazım" bilgisinin işe yaradığını söyledi; ayrıca son tarih planın ilk hâlinde de vardı. Eklemeye ben karar verdim (ilerlemem gerekiyordu). "Neden son tarih yazıyoruz?" diye sordum, yapay zekâ sebebini açıkladı
- Sınıfa `public string SonTarih;` satırını ekledim. Case 1'de başlıktan sonra "Son Tarihinizi Yazınız" sorusunu ve `string sontarih = Console.ReadLine();` satırını yazdım. İlk denemede mesajı başlık sorusuyla aynı bırakmıştım → yapay zekâ ikinci soruyu ayırmamı söyledi. Kutuyu küçük harfle (`sontarih`) yazdım çünkü bana "metottan sonra küçük yazılır" diye öğretilmişti → yapay zekâ kuralın doğrusunun "yerel kutular küçük, sınıfın özellikleri ve metotlar büyük harfle başlar" olduğunu açıkladı
- Kullanıcının yazdığı tarihi karta koymakta zorlandım. Önce `Gorev sontarih = new Gorev);`, `gorev.SonTarih = sontarih`, sonra `Gorev.SonTarih = sontarih;` yazdım → yapay zekâ `Gorev`'in kalıbın adı (kurabiye kalıbı), `yeniGorev`'in kalıptan çıkan kart olduğunu, değerin kalıba değil karta yazıldığını açıkladı. Doğru satırı (`yeniGorev.SonTarih = sontarih;`) önce yapay zekâ gösterdi, kalıbı sonra boşluk doldurmayla kendim yazdım. `yeniGorev`'i case 1'e yazmadığım için nerede oluşturduğumuzu sordum → yapay zekâ case 1'in son halini tek parça gösterdi, ben yerleştirdim
- Listede son tarihi `... - {madde.OlusturmaTarihi} - Son Tarih: {madde.SonTarih}` biçiminde gösterdim (boşluğu yapay zekâ bıraktı, kutu adını ben yazdım, `if` ve `else`'in ikisine)
- `Kaydet`'e dördüncü parçayı (`;{madde.SonTarih}`) ekledim, dosyada satırların `Başlık;Durum;Oluşturma tarihi;Son tarih` biçimine geçtiğini kontrol ettim. Açılışta okuyan bloğa `yeniGorev.SonTarih = parcalar[3];` satırını ekledim (parça numarasını tablodan buldum). Eski görevlerin satırları `;` ile bittiği için `parcalar[3]` çökmedi, bunu yapay zekâ açıkladı
- Yeni görev eklemeyi (başlık ve son tarih), listelemeyi, programı kapatıp açıp son tarihin (1.12.2040) dosyadan geldiğini test ettim
- Bilinen sınırlamalar: Son tarih sadece yazı olarak tutuluyor, program tarihin geçerli olup olmadığını kontrol etmiyor ve geçip geçmediğini hesaplamıyor. Düzenle (5) sadece başlığı değiştiriyor, son tarih sonradan değiştirilemiyor. Eski görevlerin son tarihi boş. Görev başlığında ya da son tarihte `;` olursa dosyada o satır yanlış bölünür

### Versiyon 7

- Planda öncelik için `enum` yazıyordu, ne olduğunu bilmiyordum. `string` ile `enum` farkını yapay zekâ "restoranın sabit menü kartı" benzetmesiyle anlattı. `string`'in her şeyi kabul ettiğini, `enum`'un sadece verilen seçenekleri kabul ettiğini kendim söyledim
- `enum Oncelik { Dusuk, Orta, Yuksek }` yazısının şeklini (`enum`, ad, süslü parantez, virgülle ayrılmış seçenekler), adını ve seçenekleri yapay zekâ söyledi, ben yazdım. İlk denemede süslü parantezleri unuttum → yapay zekâ hatırlattı
- Karta öncelik kutusunu önce `public string Seviye;` yazdım → yapay zekâ `string`'in her şeyi kabul ettiğini, türün menü kartının adı (`Oncelik`) olması gerektiğini söyledi. Sonra `public enum Seviye` yazdım → `enum` kelimesinin sadece menü kartını yazarken kullanıldığını, kutuyu açarken tür adının (`Oncelik`) yazıldığını açıkladı. `public Oncelik Seviye;` bana önce "saçma" geldi, yapay zekâ `Gorev yeniGorev` ile aynı mantık olduğunu gösterdi. `Seviye` adını yapay zekâ önerdi
- Kullanıcıya "1-Düşük, 2-Orta, 3-Yüksek" diye sorup sayıyı sonra seçeneğe çevirme planını yapay zekâ kurdu. Mesajı ve `int.TryParse` iskeletini yapay zekâ verdi (menüdeki `secim` satırının aynısı), boşlukları ben doldurdum. İlk denemede `bool true` ve `out numara` yazdım → yapay zekâ düzeltti. `oncelikNumara` ve `oncelikGecerli` adlarını yapay zekâ örnek verdi
- Sayıyı seçeneğe çevirmek için `switch` kullanacağımı kendim söyledim (hepsi aynı kutuya bakıyor, değerler sabit). Switch'in sonucunu tutacak kutuyu switch'ten önce açmam ve ona başlangıç değeri vermem gerektiğini yapay zekâ söyledi. `Oncelik secilenOncelik = Oncelik.Orta;` satırını yapay zekâ gösterdi (`Oncelik.Orta` yazımını daha önce hiç görmemiştim), türü (`Oncelik`) ben yazdım, ne yaptığını `bool tekrar = true;` ile karşılaştırarak yapay zekâ açıkladı. Switch'in iskeletini yapay zekâ verdi, `case 1`'i istemişti, üç case'i de (`Dusuk`, `Orta`, `Yuksek`) kendim yazdım
- Seçilen önceliği karta koymakta zorlandım: `yeniGorev.Oncelik = oncelikNumara;`, `yeniGorev.Oncelik = Seviye;`, `yeniGorev.Oncelik = Oncelik.Seviye` yazdım → yapay zekâ `Oncelik`'in tür, `Seviye`'nin kutunun adı olduğunu, sağ tarafa da sayı değil switch'in doldurduğu kutunun (`secilenOncelik`) gelmesi gerektiğini birkaç kez açıkladı. Doğru satırı (`yeniGorev.Seviye = secilenOncelik;`) sonunda kendim yazdım
- Listede göstermek için `case 2`'de iki satırın sonuna `- Öncelik: {madde.Seviye}` eklemeyi yapay zekâ söyledi, kutu adını ben yazdım. Eski görevlerin `Dusuk` görünmesini yapay zekâ açıkladı: Hiçbir şey konmayan `enum` kutusuna menüdeki ilk seçenek girer
- `Kaydet`'te satırın sonuna `;{madde.Seviye}` eklemeyi yapay zekâ söyledi, kutu adını ben yazdım. `;`'den önce yanlışlıkla bir boşluk bırakmıştım → yapay zekâ fark ettirdi (boşluk dosyaya yazılır ve her kayıtta büyürdü)
- Açılışta okuma satırını eklemeden önce programı kapatıp açınca `Yuksek` yazdığım görev `Dusuk` oldu → yapay zekâ, dosyadan okunan kartın `Seviye` kutusunun doldurulmadığı için boş kaldığını ve `Kaydet`'in bunu dosyaya yazdığını açıkladı. `Enum.TryParse(parcalar[4], out yeniGorev.Seviye);` satırının kalıbını yapay zekâ gösterdi, parça numarasını (4) ve kutu adını ben yazdım. Satırın ne yaptığını önce "sayıyı metne çevirir" diye anlattım, yön tersti: Dosyadaki yazıyı (`Yuksek`) seçeneğe çevirir. Sayıyı yazıya `ToString`, yazıyı türe `TryParse` çevirir
- Bu versiyon benim için en yeni konuydu. `enum`'u ve `Oncelik.Orta` gibi yazımı ilk kez gördüm, ilk başta hiçbir şey aklıma gelmedi, zorlandım
- Eski görevleri Sil menüsüyle silip üç yeni görev ekledim (öncelik 2, 3 ve 1). Programı kapatıp açınca üçünün de önceliğinin (Orta, Yuksek, Dusuk) dosyadan geldiğini gördüm
- Bilinen sınırlamalar: Öncelik sorusunda 1, 2, 3 dışında bir şey (ör. 7 ya da harf) yazılırsa program hata vermeden `Orta` seçer. `oncelikGecerli` kutusunu açtım ama hiçbir yerde kullanmadım. Düzenle (5) önceliği de son tarihi de değiştirmiyor

### Versiyon 8

- Planda "filtreleme ve sıralama (sadece bitmeyenler, önceliğe göre)" yazıyordu. Bunun için menüye yeni bir seçenek ekleyeceğimizi yapay zekâ söyledi. Yeni seçeneğin adı ("Bitmeyenler") yapay zekâdan örnek olarak geldi. Numaraları (6 Bitmeyenler, 7 Çıkış), menü satırını ve `case` numaralarını kendim yazdım
- Bitmeyenleri göstermek için `case 2`'deki `foreach` bloğunu kopyalamayı yapay zekâ önerdi. "Bitmeyenler foreach dışında kalmalı" gibi karışık bir cümle yazdım → yapay zekâ `foreach`'in aynı kalacağını, süzme işini `if`'in yapacağını açıkladı. Koşulun `false` aramak olduğunu kendim söyledim, `if (madde.Tamamlandi == false)` satırını `case 2`'deki `== true` kalıbına bakarak yazdım
- `else` için ne yazacağımı bilemedim → yapay zekâ bu `case`'te bitenleri göstermediğimiz için `else`'in tamamen silinebileceğini açıkladı (notlarımda "else yazmak zorunlu değil" yazıyordu)
- `sira++`'ın `if`'in dışında, `foreach`'in içinde kalacağını (bitenler de sayılsın diye) yapay zekâ anlattı. İlk önce "foreach dışında kalmayacak mı?" diye karıştırdım
- Sıralama için `OrderBy` ve `OrderByDescending` farkını yapay zekâ anlattı. En acil görevi üstte görmek için `OrderByDescending`'i kendim seçtim. `enum` seçeneklerinin arka planda numaralandığını (`Dusuk` = 0, `Orta` = 1, `Yuksek` = 2) yapay zekâ açıkladı
- `foreach (Gorev madde in gorevler.OrderByDescending(k => k.______))` kalıbını yapay zekâ gösterdi (Sayı Tahmin V9'daki `OrderBy(k => ...)` notum vardı, `=>` işaretini hâlâ tam anlamamıştım). Boşluğa `Seviye`'yi ben yazdım. "Neden `k.Seviye`?" diye sordum → yapay zekâ `k.Seviye`'nin sıralamanın hangi kutuya bakacağını gösterdiğini açıkladı. Alfabetik sıralamak isteseydim `k.Baslik` yazacağımı kendim söyledim
- Sıralayınca `6` listesindeki numaralar `2` listesindekilerle uyuşmadı (Okula gitmek `6`'da `2`, `2`'de `4`). Yapay zekâ önce numaraların aynı kalacağını söylemişti, bu yanlıştı; testteki farkı görünce hatasını kabul etti ve sebebini açıkladı (`sira++` artık öncelik sırasına göre sayıyor). İki çözümden (`IndexOf` ile gerçek numarayı yazmak ya da numarayı kaldırmak) "numarayı listeden almayı bilmiyorum, kısa yoldan gideyim" diyerek ikincisini seçtim. `sira++` ve `{sira}-` kısmını sildim
- Birkaç görevi tamamlandı yapıp `6` ile listeledim, biten görevlerin listeden çıktığını, kalanların `Yuksek`, `Orta`, `Dusuk` sırasıyla göründüğünü gördüm. `7` ile çıkışı da test ettim
- Bilinen sınırlamalar: Bitmeyenler listesinde numara yok. Sil, Tamamlandı ya da Düzenle için numarayı Listele (2) ekranından almak gerekiyor. Sıralama sadece ekranda geçerli, defterdeki ve dosyadaki sıra değişmiyor. Sadece öncelik sıralaması var

### Versiyon 9

- Planda "GorevYoneticisi sınıfı ve ayrı dosyalar (Hesap Makinesi V13 gibi)" yazıyordu. Fikri ("Program.cs garson, GorevYoneticisi mutfak": menüyü Program.cs gösterir, defterle ilgili işleri sınıf yapar) yapay zekâ anlattı. İşi üç adıma bölmeyi de yapay zekâ önerdi: önce `Gorev` ve `Oncelik`'i ayrı dosyaya taşımak, sonra `GorevYoneticisi`'ni yazmak, sonra `Program.cs`'yi ona bağlamak
- `GorevYoneticisi.cs`'de önce sadece listeyi yazdım. `public List<Gorev> gorevler = new List<Gorev>();` satırını notlarımdaki `Gecmis` örneğine bakarak yazdım, `class` kelimesini unuttum, sonra ekledim. Sınıfın kutusunun büyük harfle (`Gorevler`) yazılması gerektiğini yapay zekâ söyledi
- `Kaydet`'i `Program.cs`'den kopyaladım. Başına `public` yazmamı ve `foreach`'te `Gorevler` kullanmamı yapay zekâ söyledi (iskeleti o verdi), boşlukları ben doldurdum
- Dosyadan okuma bloğunu da sınıfa taşımamı yapay zekâ önerdi ve adını `Yukle` koymamı söyledi (ben `public void Kaydet();` yazmıştım, sonuna `;` konmayacağını da yapay zekâ söyledi). "Neden `Yukle`'nin içine aldık?" diye sordum → yapay zekâ okuma bloğunu tek bir adla çağırılabilir yapmak için olduğunu, sınıfın içine serbest komut konamayacağını açıkladı. Bloğun içindeki `gorevler.Add(yeniGorev)` satırını `Gorevler.Add(yeniGorev)` yapmamı yapay zekâ söyledi, ben yaptım
- `GorevYoneticisi yonetici = new GorevYoneticisi();` satırını Hesap Makinesi'ndeki `HesapMakinesi makine = new HesapMakinesi();` örneğine bakarak yazdım, `while`'ın dışına koydum. `yonetici` adını yapay zekâ önerdi
- Programı adım adım bağlamak için yapay zekâ geçici bir yol önerdi: eski `gorevler` adını yeni deftere ikinci ad yapmak. `yonetici.Yukle();` satırını yapay zekâ gösterdi, "neden `Yukle()`'yi çağırdık?" diye sordum, açıkladı. `List<Gorev> gorevler = yonetici.Gorevler;` satırındaki boşluğu (`yonetici`) ben doldurdum. Eski 15 satırlık okuma bloğunu sildim
- Eski `Kaydet` metodunu çağrıları değiştirmeden önce sildim, `Program.cs`'de kırmızı çizgiler çıktı → yapay zekâ sebebini açıkladı, dört `Kaydet();` çağrısını `yonetici.Kaydet();` yaptım
- `Program.cs`'deki `gorevler` yazan yerleri `yonetici.Gorevler` yaptım. Yapay zekâ Bul ve Değiştir'i önerdi, ben elle yaptım ve önce yarım bıraktım (sadece `foreach`'leri değiştirmiştim) → yapay zekâ iki adın karışık kalmasının karışıklık yaratacağını söyledi, hepsini değiştirdim. En üstteki ikinci ad satırını (`List<Gorev> gorevler = yonetici.Gorevler;`) sildim
- Tek başıma kuramazdım: sınıfın şeklini ve neyin nereye taşınacağını yapay zekâ gösterdi. Ben dosyaları taşıdım, boşlukları doldurdum, `Program.cs`'deki satırları değiştirdim
- Ekleme, listeleme, tamamlandı işaretleme, düzenleme, silme ve bitmeyenler listesini yeni yapıyla test ettim, programı kapatıp açınca değişikliklerin yerinde olduğunu gördüm
- Bilinen sınırlamalar: `GorevYoneticisi`'ne sadece liste, `Kaydet` ve `Yukle` taşındı. Ekleme, silme, tamamlandı işaretleme ve düzenleme işleri hâlâ `Program.cs`'de (`yonetici.Gorevler` üzerinde yapılıyor), yani bölme yarım. Önceki versiyonların sınırlamaları (öncelikte 1, 2, 3 dışı giriş, başlıkta `;`, Düzenle'nin sadece başlığı değiştirmesi) duruyor

## Sonraki adımlar

- [x] Menü, görev ekleme, listeleme ve çıkış
- [x] Numarasıyla görev silmek
- [x] "Tamamlandı" işaretlemek (Gorev sınıfı)
- [x] Görevleri dosyaya kaydetmek ve açılışta yüklemek
- [x] Görevi düzenlemek
- [x] Tarih eklemek (oluşturma tarihi, son tarih)
- [x] Öncelik eklemek (Düşük, Orta, Yüksek)
- [x] Filtreleme ve sıralama
- [x] GorevYoneticisi sınıfı ve ayrı dosyalar
