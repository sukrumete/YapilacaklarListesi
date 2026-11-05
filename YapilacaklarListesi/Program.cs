GorevYoneticisi yonetici = new GorevYoneticisi();
yonetici.Yukle();


while (true)
{
    int sira = 0;
    Console.WriteLine("Lütfen Seçeneklerden Birini Seçiniz");
    Console.WriteLine("1-) Ekle, 2-) Listele, 3-) Sil, 4-) Tamamlandı 5-) Düzenle 6-) Bitmeyenler 7-) Çıkış");
    int secim;
    int numara;
    bool gecerli = int.TryParse(Console.ReadLine(), out secim);
    switch (secim)
    {
        case 1:
            Console.WriteLine("Görevinizi Yazınız");
            string gorev = Console.ReadLine();
            Console.WriteLine("Son Tarihinizi Yazınız");
            string sontarih = Console.ReadLine();
            Console.WriteLine("Öncelik seçiniz (1-Düşük, 2-Orta, 3-Yüksek)");
            int oncelikNumara;
            bool oncelikGecerli = int.TryParse(Console.ReadLine(), out oncelikNumara);
            Oncelik secilenOncelik = Oncelik.Orta;
            switch (oncelikNumara)
            {
                case 1:
                    secilenOncelik = Oncelik.Dusuk;
                    break;
                case 2:
                    secilenOncelik = Oncelik.Orta;
                    break;
                case 3:
                    secilenOncelik = Oncelik.Yuksek;
                    break;
            }
            Gorev yeniGorev = new Gorev();
            yeniGorev.Baslik = gorev;
            yeniGorev.OlusturmaTarihi = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            yeniGorev.SonTarih = sontarih;
            yeniGorev.Seviye = secilenOncelik;
            yonetici.Gorevler.Add(yeniGorev);
            yonetici.Kaydet();
            break;
        case 2:
            foreach (Gorev madde in yonetici.Gorevler)
            {
                sira++;

                if (madde.Tamamlandi == true)
                {
                    Console.WriteLine($"{sira}-{madde.Baslik} (Tamamlandı) - {madde.OlusturmaTarihi} - Son Tarih: {madde.SonTarih} - Öncelik: {madde.Seviye}");
                }
                else
                {
                    Console.WriteLine($"{sira}-{madde.Baslik} (Tamamlanmadı) - {madde.OlusturmaTarihi} - Son Tarih: {madde.SonTarih} - Öncelik: {madde.Seviye}");
                }
            }
            break;
        case 3:
            foreach (Gorev madde in yonetici.Gorevler)
            {
                sira++;
                Console.WriteLine($"{sira}-{madde.Baslik}");
            }
            Console.WriteLine("Silmek istediğiniz görevin numarasını yazınız");
            bool numaraGecerli = int.TryParse(Console.ReadLine(), out numara);
            if (numaraGecerli && numara >= 1 && numara <= yonetici.Gorevler.Count)
            {
                yonetici.Gorevler.RemoveAt(numara - 1);
                Console.WriteLine("Görev Silindi");
            }
            else
            {
                Console.WriteLine("Geçersiz Numara");
            }
            yonetici.Kaydet();
            break;
        case 4:
            Console.WriteLine("Tamamlamak istediğiniz görevin numarasını yazınız");
            bool tamamlamaGecerli = int.TryParse(Console.ReadLine(), out numara);
            if (tamamlamaGecerli && numara >= 1 && numara <= yonetici.Gorevler.Count)
            {
                yonetici.Gorevler[numara - 1].Tamamlandi = true;
                Console.WriteLine("Tamamlandı olarak işaretlendi");
            }
            else
            {
                Console.WriteLine("Geçersiz Numara");


            }
            yonetici.Kaydet();
            break;
        case 5:
            foreach (Gorev madde in yonetici.Gorevler)
            {
                sira++;
                Console.WriteLine($"{sira}-{madde.Baslik}");
            }
            Console.WriteLine("Düzenlemek istediğiniz görevin numarasını yazınız");
            bool duzenlemeGecerli = int.TryParse(Console.ReadLine(), out numara);
            if (duzenlemeGecerli && numara >= 1 && numara <= yonetici.Gorevler.Count)
            {
                Console.WriteLine("Yeni başlığı yazınız");
                yonetici.Gorevler[numara - 1].Baslik = Console.ReadLine();
                Console.WriteLine("Görev düzenlendi");
            }
            else
            {
                Console.WriteLine("Geçersiz Numara");
            }
            yonetici.Kaydet();
            break;
        case 6:
            foreach (Gorev madde in yonetici.Gorevler.OrderByDescending(k => k.Seviye))
            {

                if (madde.Tamamlandi == false)
                {
                    Console.WriteLine($"{madde.Baslik} (Tamamlanmadı) - {madde.OlusturmaTarihi} - Son Tarih: {madde.SonTarih} - Öncelik: {madde.Seviye}");
                }
            }
            break;
        case 7:
            Console.WriteLine("Çıkış Yapılıyor");
            return;
        default:
            Console.WriteLine("Geçersiz Seçim");
            break;
    }
}
