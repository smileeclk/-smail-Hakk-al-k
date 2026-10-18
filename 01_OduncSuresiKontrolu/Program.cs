using System;

class Program
{
    static bool OduncUygunMu(bool oduncte, int gun)
    {
        return !oduncte && gun >= 1 && gun <= 7;
    }

    static void Main()
    {
        Console.WriteLine("=== Uygulama 1: Odunc Suresi Kontrolu ===");
        Console.Write("Ekipman su anda oduncte mi? (E/H): ");
        string? durum = Console.ReadLine()?.Trim().ToUpperInvariant();
        if (durum != "E" && durum != "H")
        {
            Console.WriteLine("Gecersiz durum. E veya H girin.");
            return;
        }

        bool oduncte = durum == "E";
        Console.Write("Kac gun odunc almak istiyorsunuz? (1-7): ");
        string? giris = Console.ReadLine();
        if (!int.TryParse(giris, out int gun) || gun < 1 || gun > 7)
        {
            Console.WriteLine("Gecersiz giris: 1-7 arasinda tam sayi girin.");
            return;
        }

        Console.WriteLine(OduncUygunMu(oduncte, gun)
            ? "Talep uygun. Ekipman odunc verilebilir."
            : "Talep reddedildi: ekipman zaten oduncte.");
    }
}
