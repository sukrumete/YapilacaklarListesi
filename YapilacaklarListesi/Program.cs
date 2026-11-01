List<string> gorevler = new List<string>();




while (true)
{
    Console.WriteLine("Lütfen Seçeneklerden Birini Seçiniz");
    Console.WriteLine("1-) Ekle, 2-) Listele, 3-) Çıkış");
    int secim;
    bool gecerli = int.TryParse(Console.ReadLine(), out secim);

    switch (secim)
    {
        case 1:
            Console.WriteLine("Görevinizi Yazınız");
            string gorev = Console.ReadLine();
            gorevler.Add(gorev);
            break;
        case 2:
            foreach (string madde in gorevler)
            {
                Console.WriteLine(madde);
            }
            break;
        case 3:
            Console.WriteLine("Çıkış Yapılıyor");
            return;
        default:
            Console.WriteLine("Geçersiz Seçim");
            break;
    }
}

//Yapilaacaklar Listesi Uygulaması