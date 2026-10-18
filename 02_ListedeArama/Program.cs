using System;
using System.Collections.Generic;

class Program
{
    static bool NumaraVarMi(List<string> liste, string aranan)
    {
        foreach (string numara in liste)
        {
            if (numara == aranan)
                return true;
        }
        return false;
    }

    static void Main()
    {
        var numaralar = new List<string> { "LAB-001", "LAB-002", "LAB-003" };
        Console.WriteLine("=== Uygulama 2: Listede Arama ===");
        Console.WriteLine("Testler:");
        TestEt(numaralar, "LAB-001"); // Ilk eleman
        TestEt(numaralar, "LAB-003"); // Son eleman
        TestEt(numaralar, "LAB-999"); // Olmayan eleman
        TestEt(new List<string>(), "LAB-001"); // Bos liste

        Console.Write("\nAranacak demirbas numarasi: ");
        string aranan = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
        TestEt(numaralar, aranan);
    }

    static void TestEt(List<string> liste, string aranan)
    {
        Console.WriteLine($"{aranan}: {(NumaraVarMi(liste, aranan) ? "Bulundu" : "Bulunamadi")}");
    }
}
