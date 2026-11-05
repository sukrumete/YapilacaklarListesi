List<Gorev> gorevler = new List<Gorev>();

if (File.Exists("gorevler.txt"))
{
    string[] satirlar = File.ReadAllLines("gorevler.txt");
    foreach (string satir in satirlar)
    {
        string[] parcalar = satir.Split(';');
        Gorev yeniGorev = new Gorev();
        yeniGorev.Baslik = parcalar[0];
        bool.TryParse(parcalar[1], out yeniGorev.Tamamlandi);
        yeniGorev.OlusturmaTarihi = parcalar[2];
        yeniGorev.SonTarih = parcalar[3];
        Enum.TryParse(parcalar[4], out yeniGorev.Seviye);
        gorevler.Add(yeniGorev);
    }
}

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
            gorevler.Add(yeniGorev);
            Kaydet();
            break;
        case 2:
            foreach (Gorev madde in gorevler)
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
            foreach (Gorev madde in gorevler)
            {
                sira++;
                Console.WriteLine($"{sira}-{madde.Baslik}");
            }
            Console.WriteLine("Silmek istediğiniz görevin numarasını yazınız");
            bool numaraGecerli = int.TryParse(Console.ReadLine(), out numara);
            if (numaraGecerli && numara >= 1 && numara <= gorevler.Count)
            {
                gorevler.RemoveAt(numara - 1);
                Console.WriteLine("Görev Silindi");
            }
            else
            {
                Console.WriteLine("Geçersiz Numara");
            }
            Kaydet();
            break;
        case 4:
            Console.WriteLine("Tamamlamak istediğiniz görevin numarasını yazınız");
            bool tamamlamaGecerli = int.TryParse(Console.ReadLine(), out numara);
            if (tamamlamaGecerli && numara >= 1 && numara <= gorevler.Count)
            {
                gorevler[numara - 1].Tamamlandi = true;
                Console.WriteLine("Tamamlandı olarak işaretlendi");
            }
            else
            {
                Console.WriteLine("Geçersiz Numara");


            }
            Kaydet();
            break;
        case 5:
            foreach (Gorev madde in gorevler)
            {
                sira++;
                Console.WriteLine($"{sira}-{madde.Baslik}");
            }
            Console.WriteLine("Düzenlemek istediğiniz görevin numarasını yazınız");
            bool duzenlemeGecerli = int.TryParse(Console.ReadLine(), out numara);
            if (duzenlemeGecerli && numara >= 1 && numara <= gorevler.Count)
            {
                Console.WriteLine("Yeni başlığı yazınız");
                gorevler[numara - 1].Baslik = Console.ReadLine();
                Console.WriteLine("Görev düzenlendi");
            }
            else
            {
                Console.WriteLine("Geçersiz Numara");
            }
            Kaydet();
            break;
        case 6:
            foreach (Gorev madde in gorevler.OrderByDescending(k => k.Seviye))
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

void Kaydet()
{
    List<string> satirlar = new List<string>();
    foreach (Gorev madde in gorevler)
    {
        satirlar.Add($"{madde.Baslik};{madde.Tamamlandi};{madde.OlusturmaTarihi};{madde.SonTarih};{madde.Seviye}");
    }
    File.WriteAllLines("gorevler.txt", satirlar);
}

class Gorev
{
    public string Baslik;
    public bool Tamamlandi;

    public string OlusturmaTarihi;

    public string SonTarih;

    public Oncelik Seviye;
}

enum Oncelik
{
    Dusuk, Orta, Yuksek
}