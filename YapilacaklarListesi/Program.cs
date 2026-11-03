List<Gorev> gorevler = new List<Gorev>();

while (true)
{
    int sira = 0;
    Console.WriteLine("Lütfen Seçeneklerden Birini Seçiniz");
    Console.WriteLine("1-) Ekle, 2-) Listele, 3-) Sil, 4-) Tamamlandı 5-) Çıkış ");
    int secim;
    int numara;
    bool gecerli = int.TryParse(Console.ReadLine(), out secim);
    switch (secim)
    {
        case 1:
            Console.WriteLine("Görevinizi Yazınız");
            string gorev = Console.ReadLine();
            Gorev yeniGorev = new Gorev();
            yeniGorev.Baslik = gorev;
            gorevler.Add(yeniGorev);
            break;
        case 2:
            foreach (Gorev madde in gorevler)
            {
                sira++;

                if (madde.Tamamlandi == true)
                {
                    Console.WriteLine($"{sira}-{madde.Baslik} (Tamamlandı)");
                }
                else
                {
                    Console.WriteLine($"{sira}-{madde.Baslik} (Tamamlanmadı)");
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
            break;
        case 5:
            Console.WriteLine("Çıkış Yapılıyor");
            return;
        default:
            Console.WriteLine("Geçersiz Seçim");
            break;
    }
}

class Gorev
{
    public string Baslik;
    public bool Tamamlandi;
}