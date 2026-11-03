# Yapılacaklar Listesi 📝

C# ile yazılmış basit bir konsol yapılacaklar listesi (To-Do) uygulaması. C# öğrenme sürecimdeki üçüncü projem.

## Ne yapıyor?

Program açılınca bir menü gösterir, kullanıcı numarayla seçim yapar:

- **1 – Ekle:** Yeni bir görev yazılır ve listeye eklenir
- **2 – Listele:** Görevler numaralı olarak alt alta yazdırılır, yanlarında durumları görünür (1-... (Tamamlandı), 2-... (Tamamlanmadı))
- **3 – Sil:** Görevler numaralı gösterilir, kullanıcı silmek istediği görevin numarasını yazar
- **4 – Tamamlandı:** Kullanıcı, tamamladığı görevin numarasını girerek görevi tamamlandı olarak işaretler
- **5 – Çıkış:** Program kapanır
- Her işlemden sonra menü tekrar gösterilir
- Yanlış girişte program kapanmaz:
  - Menüde olmayan bir sayı ya da harf yazılırsa "Geçersiz Seçim" der
  - Silme veya tamamlandı işaretleme sırasında listede olmayan bir numara ya da harf yazılırsa "Geçersiz Numara" der

**Not:** Aşağıdaki örnek çıktı V2 sürümündeki testlerden alınmıştır. V3 sürümünde menüye "Tamamlandı" seçeneği eklenmiştir.

```
Lütfen Seçeneklerden Birini Seçiniz
1-) Ekle, 2-) Listele, 3-) Sil, 4-) Çıkış
3
1-Naber
2-Selam
3-Merhaba
Silmek istediğiniz görevin numarasını yazınız
9
Geçersiz Numara
Lütfen Seçeneklerden Birini Seçiniz
1-) Ekle, 2-) Listele, 3-) Sil, 4-) Çıkış
3
1-Naber
2-Selam
3-Merhaba
Silmek istediğiniz görevin numarasını yazınız
2
Görev Silindi
Lütfen Seçeneklerden Birini Seçiniz
1-) Ekle, 2-) Listele, 3-) Sil, 4-) Çıkış
2
1-Naber
2-Merhaba
```

(Gerçek test çıktılarım, iki ayrı denemeden birleştirildi; okunaklı olsun diye görev ekleme kısmı ve "a" denemesi çıkarıldı.)

## Kullanılanlar

- C#
- .NET 10

## Nasıl çalıştım?

- Bu projeyi de yapay zekâ ile soru-cevap şeklinde ilerleyerek yapıyorum. V3'ün büyük kısmında Claude, haftalık hakkım bitince ChatGPT kullandım. Her adımda yapay zekâ bana sorular soruyor, ipuçları veriyor ve kavramları açıklıyor.
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

## Sonraki adımlar

- [x] Menü, görev ekleme, listeleme ve çıkış
- [x] Numarasıyla görev silmek
- [x] "Tamamlandı" işaretlemek (Gorev sınıfı)
- [ ] Görevleri dosyaya kaydetmek ve açılışta yüklemek
- [ ] Görevi düzenlemek
- [ ] Tarih eklemek (oluşturma tarihi, son tarih)
- [ ] Öncelik eklemek (Düşük, Orta, Yüksek)
- [ ] Filtreleme ve sıralama
- [ ] GorevYoneticisi sınıfı ve ayrı dosyalar
