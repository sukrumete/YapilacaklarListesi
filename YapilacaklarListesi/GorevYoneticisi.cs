using System;
using System.Collections.Generic;
using System.Text;

class GorevYoneticisi
{
    public List<Gorev> Gorevler = new List<Gorev>();

    public void Kaydet()
    {
        List<string> satirlar = new List<string>();
        foreach (Gorev madde in Gorevler)
        {
            satirlar.Add($"{madde.Baslik};{madde.Tamamlandi};{madde.OlusturmaTarihi};{madde.SonTarih};{madde.Seviye}");
        }
        File.WriteAllLines("gorevler.txt", satirlar);
    }

    public void Yukle()
    {
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
                Gorevler.Add(yeniGorev);
            }
        }
    }
}