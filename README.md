# Yapılacaklar Listesi 📝

C# ile yazılmış basit bir konsol yapılacaklar listesi (To-Do) uygulaması. C# öğrenme sürecimdeki üçüncü projem.

## Ne yapıyor?

Program açılınca bir menü gösterir, kullanıcı numarayla seçim yapar:

- **1 – Ekle:** Yeni bir görev yazılır ve listeye eklenir
- **2 – Listele:** Eklenen görevler alt alta yazdırılır
- **3 – Çıkış:** Program kapanır
- Her işlemden sonra menü tekrar gösterilir
- Yanlış girişte program kapanmaz: Menüde olmayan bir sayı ya da harf yazılırsa "Geçersiz Seçim" der ve menüyü tekrar gösterir

```
Lütfen Seçeneklerden Birini Seçiniz
1-) Ekle, 2-) Listele, 3-) Çıkış
1
Görevinizi Yazınız
naber
Lütfen Seçeneklerden Birini Seçiniz
1-) Ekle, 2-) Listele, 3-) Çıkış
2
naber
Lütfen Seçeneklerden Birini Seçiniz
1-) Ekle, 2-) Listele, 3-) Çıkış
a
Geçersiz Seçim
```

(Örnek çıktı iki ayrı testimden birleştirildi; satırların hepsi gerçek test çıktısı.)

## Kullanılanlar

- C#
- .NET 10

## Nasıl çalıştım?

- Bu projeyi de yapay zekâ ile soru-cevap şeklinde ilerleyerek yapıyorum. Her adımda yapay zekâ bana sorular soruyor, ipuçları veriyor ve kavramları açıklıyor.
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
- Bilinen sınırlamalar: Görevler program kapanınca siliniyor (dosyaya kaydetme V4'te). Liste boşken "Listele" seçilirse hiçbir şey yazmıyor. Görevler numarasız listeleniyor

## Sonraki adımlar

- [x] Menü, görev ekleme, listeleme ve çıkış
- [ ] Numarasıyla görev silmek
- [ ] "Tamamlandı" işaretlemek (Gorev sınıfı)
- [ ] Görevleri dosyaya kaydetmek ve açılışta yüklemek
- [ ] Görevi düzenlemek
- [ ] Tarih eklemek (oluşturma tarihi, son tarih)
- [ ] Öncelik eklemek (Düşük, Orta, Yüksek)
- [ ] Filtreleme ve sıralama
- [ ] GorevYoneticisi sınıfı ve ayrı dosyalar
