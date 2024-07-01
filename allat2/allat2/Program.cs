using System;

class Allat
{
    public static int AktualisEv { get; set; }
    public static int KorHatar { get; set; }
    public string Nev { get; }
    public int SzulEv { get; }
    public int Szepseg { get; set; }
    public int Viselkedes { get; set; }

    public Allat(string nev, int szulEv)
    {
        Nev = nev;
        SzulEv = szulEv;
    }

    public int Pontszam()
    {
        int kor = AktualisEv - SzulEv;
        if (kor >= KorHatar)
        {
            return 0;
        }
        return (KorHatar - kor) * Szepseg + kor * Viselkedes;
    }

    public override string ToString()
    {
        return $"Név: {Nev}, Pontszám: {Pontszam()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        int aktEv = 2024, korhatar = 10;
        // Az aktuális év és a korhatár megadása
        Allat.AktualisEv = aktEv;
        Allat.KorHatar = korhatar;
        AllatVerseny();
        Console.ReadKey();
    }

    private static void AllatVerseny()
    {
        // az allat nevű változó deklarálása
        Allat allat;
        string nev;
        int szulEv, szepseg, viselkedes;
        int veletlenPontHatar = 10;
        // egy Random példány létrehozása
        Random rand = new Random();
        // számoláshoz szükséges kezdőértékek beállítása
        int osszesVersenyzo = 0;
        int osszesPont = 0;
        int legtobbPont = 0;

        Console.WriteLine("Kezdődik a verseny");
        char tovabb = 'i';
        while (tovabb == 'i')
        {
            Console.Write("Az állat neve: ");
            nev = Console.ReadLine();
            Console.Write("születési éve: ");
            while (!int.TryParse(Console.ReadLine(), out szulEv) || szulEv <= 0 || szulEv > Allat.AktualisEv)
            {
                Console.Write("Hibás adat, kérem újra: ");
            }

            // véletlen pontértékek
            szepseg = rand.Next(veletlenPontHatar + 1);
            viselkedes = rand.Next(veletlenPontHatar + 1);

            // Allat példány létrehozása és pontok beállítása
            allat = new Allat(nev, szulEv)
            {
                Szepseg = szepseg,
                Viselkedes = viselkedes
            };

            int pontszam = allat.Pontszam();
            osszesPont += pontszam;
            osszesVersenyzo++;
            if (pontszam > legtobbPont)
            {
                legtobbPont = pontszam;
            }

            Console.WriteLine(allat);
            Console.Write("Van még versenyző? (i/n): ");
            tovabb = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }

        Console.WriteLine($"Összes versenyző: {osszesVersenyzo}");
        if (osszesVersenyzo > 0)
        {
            Console.WriteLine($"Átlag pontszám: {(double)osszesPont / osszesVersenyzo}");
            Console.WriteLine($"Legnagyobb pontszám: {legtobbPont}");
        }
    }
}
