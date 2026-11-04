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
        gorevler.Add(yeniGorev);
    }
}

while (true)
{
    int sira = 0;
    Console.WriteLine("Lütfen Seçeneklerden Birini Seçiniz");
    Console.WriteLine("1-) Ekle, 2-) Listele, 3-) Sil, 4-) Tamamlandı 5-) Düzenle 6-) Çıkış");
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
            Gorev yeniGorev = new Gorev();
            yeniGorev.Baslik = gorev;
            yeniGorev.OlusturmaTarihi = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            yeniGorev.SonTarih = sontarih;
            gorevler.Add(yeniGorev);
            Kaydet();
            break;
        case 2:
            foreach (Gorev madde in gorevler)
            {
                sira++;

                if (madde.Tamamlandi == true)
                {
                    Console.WriteLine($"{sira}-{madde.Baslik} (Tamamlandı) - {madde.OlusturmaTarihi} - Son Tarih: {madde.SonTarih}");
                }
                else
                {
                    Console.WriteLine($"{sira}-{madde.Baslik} (Tamamlanmadı) - {madde.OlusturmaTarihi} - Son Tarih: {madde.SonTarih}");
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
        satirlar.Add($"{madde.Baslik};{madde.Tamamlandi};{madde.OlusturmaTarihi};{madde.SonTarih}");
    }
    File.WriteAllLines("gorevler.txt", satirlar);
}

class Gorev
{
    public string Baslik;
    public bool Tamamlandi;

    public string OlusturmaTarihi;

    public string SonTarih;
}