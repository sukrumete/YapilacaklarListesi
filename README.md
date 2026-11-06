# Yapılacaklar Listesi 📝

C# ile yazılmış basit bir konsol yapılacaklar listesi (To-Do) uygulaması. C# öğrenme sürecimdeki üçüncü projem.

## Ne yapıyor?

Program açılınca bir menü gösterir, kullanıcı numarayla seçim yapar:

- **Ekle:** Görev, son tarih ve öncelik (Düşük, Orta, Yüksek) yazılır, oluşturma tarihi otomatik eklenir
- **Listele:** Görevler numaralı, durumları, tarihleri ve öncelikleriyle gösterilir
- **Sil, Tamamlandı, Düzenle:** Listedeki numarayla yapılır (Düzenle sadece başlığı değiştirir)
- **Bitmeyenler:** Sadece tamamlanmamış görevler, önceliğe göre (Yüksek en üstte) gösterilir
- Görevler `gorevler.txt` dosyasına kaydedilir, program açılınca yüklenir. Dosyada her görev tek satırdır: `Başlık;Durum;Oluşturma tarihi;Son tarih;Öncelik`
- Yanlış girişte kapanmaz: Menüde olmayan seçimde "Geçersiz Seçim", listede olmayan numarada "Geçersiz Numara" der

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
6
Kitap Okumak (Tamamlanmadı) - 05.11.2026 23:58 - Son Tarih: 1.12.2028 - Öncelik: Yuksek
Geziye Gitmek (Tamamlanmadı) - 05.11.2026 23:59 - Son Tarih: 1.12.2029 - Öncelik: Yuksek
Resim Çizmek (Tamamlanmadı) - 05.11.2026 23:58 - Son Tarih: 1.12.2028 - Öncelik: Orta
Müzeye Gitmek (Tamamlanmadı) - 05.11.2026 23:59 - Son Tarih: 1.12.2030 - Öncelik: Dusuk
```

## Kullanılanlar

- C#
- .NET 10

## Dosyalar

- `Program.cs`: menü ve `switch` içindeki işlemler
- `GorevYoneticisi.cs`: görev listesi, `Kaydet` ve `Yukle`
- `Gorev.cs`: bir görevin bilgileri
- `Oncelik.cs`: öncelik seçenekleri

## Nasıl çalıştım?

- Bu projeyi yapay zekâ ile soru-cevap şeklinde ilerleyerek yaptım. V3'ün başını Claude ile yaptım, haftalık hakkım bitince devamını ChatGPT ile yaptım, sonrasında yine Claude kullandım. Yapay zekâ bana sorular sordu, ipuçları verdi ve kavramları açıkladı.
- Kod satırlarını kendim yazdım. Takıldığım yerde ipucu istedim, hatalarımın nedenini sordum. Bazı yerlerde çözümü yapay zekâ gösterdi.
- Dosyaya kaydetme (V4), `enum` ile öncelik (V7) ve `GorevYoneticisi` sınıfı (V9) bölümlerinde yapay zekâ çok daha fazla yönlendirme yaptı. `bool.TryParse` ve `Enum.TryParse` satırlarını, `Oncelik.Orta` yazımını, `OrderByDescending(k => ...)` kalıbını ve `GorevYoneticisi`'nin iskeletini yapay zekâ gösterdi. V9'u tek başıma kuramazdım.
- Her değişiklikten sonra programı kendim test ettim.
- Nerede kendim bulduğumu, nerede yardım aldığımı versiyon versiyon [GELISIM.md](https://github.com/sukrumete/YapilacaklarListesi/blob/master/GELISIM.md) dosyasında açıkça yazdım.

## Bu projede öğrendiklerim

- **Temeller:** `List<T>`, `foreach`, `switch`, `while (true)` ile menü, `int.TryParse` ile güvenli sayı alma
- **Listede nesne:** Listede 1'den, listenin içinde 0'dan başlayan sayma (`numara - 1`)
- **OOP:** `Gorev` sınıfı (başlık, durum, tarihler), `enum Oncelik`, `GorevYoneticisi` sınıfı, her sınıfı ayrı dosyaya taşımak
- **Dosyalar:** Listeyi her seferinde baştan yazmak (`WriteAllLines`), açılışta okuyup `Split(';')` ile parçalamak, `bool.TryParse` ve `Enum.TryParse` ile yazıyı türe çevirmek
- **Sıralama ve süzme:** `OrderByDescending` ile öncelik sıralaması, `if` ile bitmeyenleri süzmek
- **Test dersi:** Sıralayınca Bitmeyenler listesinin numaraları Listele'dekiyle uyuşmadı, testte fark ettim, bu listede numara göstermemeye karar verdim

**En çok zorlandığım konular:** Dosyadan okuyup görevi yeniden kurmak (V4), `enum` ve `Oncelik.Orta` gibi yeni yazımlar (V7), sınıfı parçalayıp `GorevYoneticisi`'ne bölmek (V9). Tekrar ederek oturtmaya devam ediyorum.

## Bilinen sınırlamalar

- Görev başlığında ya da son tarihte `;` olursa dosyada o satır yanlış bölünür. Dosya elle bozulursa program açılırken çökebilir
- Son tarih sadece yazı: Geçerli olup olmadığı kontrol edilmiyor, geçip geçmediği hesaplanmıyor
- Öncelikte 1, 2, 3 dışında bir şey yazılırsa görev sessizce "Orta" olur
- Düzenle sadece başlığı değiştiriyor
- Bitmeyenler listesinde numara yok, numarayı Listele ekranından almak gerekiyor
- `GorevYoneticisi`'ne sadece liste, `Kaydet` ve `Yukle` taşındı. Ekleme, silme, tamamlandı ve düzenleme işleri hâlâ `Program.cs`'de

👉 Versiyon versiyon detaylı gelişim günlüğü: [GELISIM.md](https://github.com/sukrumete/YapilacaklarListesi/blob/master/GELISIM.md)
