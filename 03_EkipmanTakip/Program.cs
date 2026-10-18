using System;
using System.Collections.Generic;

class Program
{
    static readonly List<Ekipman> ekipmanlar = new()
    {
        new Ekipman("LAB-001", "Kamera"),
        new Ekipman("LAB-002", "Mikrofon"),
        new Ekipman("LAB-003", "Tripod")
    };

    static readonly List<Ogrenci> ogrenciler = new()
    {
        new Ogrenci("1001", "Ayse Yilmaz"),
        new Ogrenci("1002", "Mehmet Demir")
    };

    static Ekipman? EkipmanBul(List<Ekipman> liste, string no)
    {
        foreach (Ekipman e in liste)
            if (e.DemirbasNo == no.Trim().ToUpperInvariant())
                return e;
        return null;
    }

    static Ogrenci? OgrenciBul(List<Ogrenci> liste, string no)
    {
        foreach (Ogrenci o in liste)
            if (o.Numara == no.Trim())
                return o;
        return null;
    }

    static void Listele(bool sadeceMusait = false)
    {
        Console.WriteLine("\nDemirbas | Ekipman | Durum");
        bool bulundu = false;
        foreach (Ekipman e in ekipmanlar)
        {
            if (sadeceMusait && e.Oduncte) continue;
            bulundu = true;
            Console.WriteLine($"{e.DemirbasNo} | {e.Ad} | {(e.Oduncte ? "Oduncte (" + e.OduncAlanNo + ")" : "Musait")}");
        }
        if (!bulundu) Console.WriteLine("Listelenecek ekipman yok.");
    }

    static void OduncVer()
    {
        Console.Write("Demirbas no: ");
        string no = Console.ReadLine() ?? "";
        Ekipman? ekipman = EkipmanBul(ekipmanlar, no);
        if (ekipman == null)
        {
            Console.WriteLine("Ekipman bulunamadi.");
            return;
        }
        Console.Write("Ogrenci no: ");
        string ogrenciNo = Console.ReadLine() ?? "";
        if (OgrenciBul(ogrenciler, ogrenciNo) == null)
        {
            Console.WriteLine("Kayitli ogrenci bulunamadi.");
            return;
        }
        Console.WriteLine(ekipman.OduncVer(ogrenciNo) ? "Odunc verildi." : "Islem reddedildi: ekipman zaten oduncte.");
    }

    static void IadeAl()
    {
        Console.Write("Demirbas no: ");
        Ekipman? ekipman = EkipmanBul(ekipmanlar, Console.ReadLine() ?? "");
        if (ekipman == null)
        {
            Console.WriteLine("Ekipman bulunamadi.");
            return;
        }
        Console.WriteLine(ekipman.IadeAl() ? "Iade alindi." : "Islem reddedildi: ekipman zaten musait.");
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Ekipman Takip ===");
            Console.WriteLine("1 - Listele");
            Console.WriteLine("2 - Odunc ver");
            Console.WriteLine("3 - Iade al");
            Console.WriteLine("4 - Sadece musait ekipmanlar");
            Console.WriteLine("0 - Cikis");
            Console.Write("Secim: ");
            string? secim = Console.ReadLine();
            if (secim == null) break;
            switch (secim)
            {
                case "1": Listele(); break;
                case "2": OduncVer(); break;
                case "3": IadeAl(); break;
                case "4": Listele(true); break;
                case "0": return;
                default: Console.WriteLine("Gecersiz secim."); break;
            }
        }
    }
}
