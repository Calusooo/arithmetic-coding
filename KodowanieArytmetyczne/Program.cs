using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KodowanieArytmetyczne
{
    class Program
    {
        public static string slowo, kodB, kodC, kodCal, kodBin, slowoZ, slowoC, slowoB;
        public static double kodZ, kodZM;
        static void Main(string[] args)
        {
            Console.WriteLine("KODOWANIE: ");
            Console.WriteLine("Podaj slowo do zakodowania składające się z 5 znakow (P = {0,4;0,3;0.2;0.1)");
            Console.WriteLine("Bank znaków: A,B,C - jako 5 znak wprowadz #");
            CzytajDane slowo1 = new CzytajDane();
            slowo = slowo1.czytajSlowo();

            Kodowanie kod10 = new KodowanieZmiennoprzecinkowe();
            kodZ = kod10.kodowanie(slowo);
            Console.WriteLine("Kod zmiennoprzecinkowy dla slowa " + slowo + " = " + kodZ);

            Kodowanie kod20 = new KodowanieBinarne();
            kodB = kod20.kodowanie1(slowo);
            Console.WriteLine("Kod binarny dla slowa " + slowo + " = " + kodB);

            Kodowanie kod30 = new KodowanieCalkowitoliczbowe();
            kodC = kod30.kodowanie1(slowo);
            Console.WriteLine("Kod calkowitoliczbowy dla slowa " + slowo + " = " + kodC);

            Console.WriteLine();
            Console.WriteLine("DEKODOWANIE: ");
            CzytajDane kod1 = new CzytajDane();
            kodZM = kod1.czytajKod();
            Kodowanie slowo10 = new KodowanieZmiennoprzecinkowe();
            slowoZ = slowo10.dekodowanie(kodZM);
            Console.WriteLine("Zdekodowanie slowo (zmiennoprzecinkowe) brzmi: " + slowoZ);

            CzytajDane kod3 = new CzytajDane();
            kodBin = kod3.czytajKod2();
            Kodowanie slowo30 = new KodowanieZmiennoprzecinkowe();
            slowoB = slowo30.dekodowanie1(kodBin);
            Console.WriteLine("Zdekodowanie slowo (binarne) brzmi: " + slowoZ);

            CzytajDane kod2 = new CzytajDane();
            kodCal = kod2.czytajKod1();
            Kodowanie slowo20 = new KodowanieCalkowitoliczbowe();
            slowoC = slowo20.dekodowanie1(kodCal);
            Console.WriteLine("Zdekodowanie slowo (calkowitoliczbowe) brzmi: " + slowoC);
            
            Console.ReadLine();
        }
    }
}
class CzytajDane
{
    public CzytajDane()
    {
        this.Slowo1 = "0";
        this.KodZM = 0;
    }
    public CzytajDane(string slowo)
    {
        this.Slowo1 = slowo;
    }
    public CzytajDane(double kod)
    {
        this.KodZM = kod;
    }
    public string Slowo1
    {
        get;
        protected set;
    }
    public string KodCal
    {
        get;
        protected set;
    }
    public string KodBin
    {
        get;
        protected set;
    }
    public double KodZM
    {
        get;
        protected set;
    }
    public string czytajSlowo()
    {
        Console.Write("Podaj slowo: ");
        Slowo1 = Console.ReadLine();
        return Slowo1;
    }
    public double czytajKod()
    {
        Console.Write("Wprowadz wygenerowany kod zmiennoprzecinkowy: ");
        KodZM = Convert.ToDouble(Console.ReadLine());
        return KodZM;
    }
    public string czytajKod2()
    {
        Console.Write("Wprowadz wygenerowany kod binarny: ");
        KodBin = Console.ReadLine();
        return KodBin;
    }
    public string czytajKod1()
    {
        Console.Write("Wprowadz wygenerowany kod calkowity: ");
        KodCal = Console.ReadLine();
        return KodCal;
    }
}

abstract class Kodowanie
{
    public static double przedzial1Od, przedzial2Od, przedzial3Od, przedzial4Od;
    public static double przedzial1Do, przedzial2Do, przedzial3Do, przedzial4Do;
    public Kodowanie()
    {
        this.Kod = 0;
        this.Kod2 = "";
    }
    public Kodowanie(double kod)
    {
        this.Kod = kod;
    }
    public Kodowanie(string kod)
    {
        this.Kod2 = kod;
    }
    public double Kod
    {
        get;
        protected set;
    }
    public string Kod2
    {
        get;
        protected set;
    }
    public string Slowo
    {
        get;
        protected set;
    }
    public double biezacyPrzedzialOd
    {
        get;
        protected set;
    }
    public double biezacyPrzedzialDo
    {
        get;
        protected set;
    }
    public double przedzialOd
    {
        get;
        protected set;
    }
    public double przedzialDo
    {
        get;
        protected set;
    }
    public void ustawPodPrzedzialy(double biezacyPrzedzialOd, double biezacyPrzedzialDo)
    {
        przedzial1Od = biezacyPrzedzialOd;
        przedzial1Do = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.4;

        przedzial2Od = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.4;
        przedzial2Do = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.7;

        przedzial3Od = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.7;
        przedzial3Do = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.9;

        przedzial4Od = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.9;
        przedzial4Do = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 1;

        przedzial1Do = Math.Round(przedzial1Do, 5);
        przedzial2Od = Math.Round(przedzial2Od, 5);
        przedzial2Do = Math.Round(przedzial2Do, 5);
        przedzial3Od = Math.Round(przedzial3Od, 5);
        przedzial3Do = Math.Round(przedzial3Do, 5);
        przedzial4Od = Math.Round(przedzial4Od, 5);
    }
    abstract public double kodowanie(string Slowo);
    abstract public string kodowanie1(string Slowo);
    abstract public string dekodowanie(double Kod);
    abstract public string dekodowanie1(string Kod2);
  }

class KodowanieZmiennoprzecinkowe : Kodowanie
{
    public KodowanieZmiennoprzecinkowe()
    {
        this.Slowo = "0";
    }
    public KodowanieZmiennoprzecinkowe(string slowo)
    {
        this.Slowo = slowo;
    }
    public override double kodowanie(string Slowo)
    {
        biezacyPrzedzialOd = 0.0;
        biezacyPrzedzialDo = 1.0;
        for (int i = 0; i <= Slowo.Length; i++)
        {
            if (Slowo[i] == 'A')
            {
                przedzialOd = biezacyPrzedzialOd;
                przedzialDo = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.4;
                biezacyPrzedzialOd = przedzialOd;
                biezacyPrzedzialDo = przedzialDo;
            }
            else if (Slowo[i] == 'B')
            {
                przedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.4;
                przedzialDo = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.7;
                biezacyPrzedzialOd = przedzialOd;
                biezacyPrzedzialDo = przedzialDo;
            }
            else if (Slowo[i] == 'C')
            {
                przedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.7;
                przedzialDo = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.9;
                biezacyPrzedzialOd = przedzialOd;
                biezacyPrzedzialDo = przedzialDo;
            }
            else if (Slowo[i] == '#')
            {
                przedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.9;
                przedzialDo = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 1;
                biezacyPrzedzialOd = przedzialOd;
                biezacyPrzedzialDo = przedzialDo;
                Kod = przedzialOd;
                break;
            }
        }
        
        return Kod;
    }
    public override string dekodowanie(double Kod)
    {
        Slowo = "";
        biezacyPrzedzialOd = 0.0;
        biezacyPrzedzialDo = 1.0;
        while (true)
        {
            ustawPodPrzedzialy(biezacyPrzedzialOd, biezacyPrzedzialDo);
            if (przedzial1Od < Kod && Kod < przedzial1Do)
            {
                Slowo += "A";
                biezacyPrzedzialOd = przedzial1Od;
                biezacyPrzedzialDo = przedzial1Do;
            }
            else if (przedzial2Od <= Kod && Kod < przedzial2Do)
            {
                Slowo += "B";
                biezacyPrzedzialOd = przedzial2Od;
                biezacyPrzedzialDo = przedzial2Do;
            }
            else if (przedzial3Od <= Kod && Kod < przedzial3Do)
            {
                Slowo += "C";
                biezacyPrzedzialOd = przedzial3Od;
                biezacyPrzedzialDo = przedzial3Do;
            }
            else if (przedzial4Od <= Kod && Kod < przedzial4Do)
            {
                Slowo += "#";
                break;
            }
        }

        return Slowo;
    }
    public override string kodowanie1(string Slowo)
    {
        return "0";
    }
    public override string dekodowanie1(string Kod2)
    {
        return "0";
    }
}


class KodowanieBinarne : Kodowanie
{
    public static int lBitow = 0;
    public static string bity = "";
    public static double liczba;
    public KodowanieBinarne()
    {
        this.Slowo = "0";
    }
    public KodowanieBinarne(string slowo)
    {
        this.Slowo = slowo;
    }
    public void ustawPrzedzial(double biezacyPrzedzialOd, double biezacyPrzedzialDo, int k, string Slowo)
    {
        for (int i = k ; i <= Slowo.Length;)
        {
            if (i == Slowo.Length) { break; }
            else if (Slowo[i] == 'A')
            {
                przedzialOd = biezacyPrzedzialOd;
                przedzialDo = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.4;
                break;
            }
            else if (Slowo[i] == 'B')
            {
                przedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.4;
                przedzialDo = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.7;
                break;
            }
            else if (Slowo[i] == 'C')
            {
                przedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.7;
                przedzialDo = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.9;
                break;
            }
            else if (Slowo[i] == '#')
            {
                przedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.9;
                przedzialDo = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 1;
                break;
            }
            else break;
        }
    }
    public override string kodowanie1(string Slowo)
    {
        biezacyPrzedzialOd = 0.0;
        biezacyPrzedzialDo = 1.0;
        for (int k = 0; k <= Slowo.Length; k++)
        {
            ustawPrzedzial(biezacyPrzedzialOd, biezacyPrzedzialDo, k, Slowo);
            biezacyPrzedzialOd = przedzialOd;
            biezacyPrzedzialDo = przedzialDo;
            if (k == Slowo.Length)
            {
                lBitow++;
                if (biezacyPrzedzialOd < 0.25)
                {
                    if (lBitow == 0) bity = "";
                    else if (lBitow == 1) bity = "1";
                    else if (lBitow == 2) bity = "11";
                    else if (lBitow == 3) bity = "111";
                    else if (lBitow == 4) bity = "1111";
                    Kod2 = Kod2 + "0" + bity;
                    return Kod2;
                }
                else
                {
                    if (lBitow == 0) bity = "";
                    else if (lBitow == 1) bity = "0";
                    else if (lBitow == 2) bity = "00";
                    else if (lBitow == 3) bity = "000";
                    else if (lBitow == 4) bity = "0000";
                    Kod2 = Kod2 + "1" + bity;
                    return Kod2;
                }
            }
            while (true)
            {
                if (biezacyPrzedzialOd >= 0.25 && biezacyPrzedzialOd < 0.75 && biezacyPrzedzialDo >= 0.25 && biezacyPrzedzialDo < 0.75)
                {
                    lBitow++;
                    biezacyPrzedzialOd -= 0.25;
                    biezacyPrzedzialDo -= 0.25;
                }
                else if (biezacyPrzedzialOd >= 0 && biezacyPrzedzialOd < 0.5 && biezacyPrzedzialDo >= 0 && biezacyPrzedzialDo < 0.5)
                {
                    if (lBitow == 0) bity = "";
                    else if (lBitow == 1) bity = "1";
                    else if (lBitow == 2) bity = "11";
                    else if (lBitow == 3) bity = "111";
                    else if (lBitow == 4) bity = "1111";
                    Kod2 = Kod2 + "0" + bity;
                    lBitow = 0;
                }
                else if (biezacyPrzedzialOd >= 0.5 && biezacyPrzedzialOd < 1 && biezacyPrzedzialDo >= 0.5 && biezacyPrzedzialDo < 1)
                {
                    if (lBitow == 0) bity = "";
                    else if (lBitow == 1) bity = "0";
                    else if (lBitow == 2) bity = "00";
                    else if (lBitow == 3) bity = "000";
                    else if (lBitow == 4) bity = "0000";
                    Kod2 = Kod2 + "1" + bity;
                    lBitow = 0;
                    biezacyPrzedzialOd -= 0.5;
                    biezacyPrzedzialDo -= 0.5;
                }
                else break;
                biezacyPrzedzialOd *= 2;
                biezacyPrzedzialDo *= 2;
            }
        }
        return Kod2;
    }
    public double kodNaDzies(string Kod2)
    {
        int n = Kod2.Length;
        char[] bufor = new char[n];
        liczba = 0.0;
        for (int i = 0; i < Kod2.Length; i++)
        {
            bufor[i] = Kod2[i];
        }
        for (int i = 0; i < bufor.Length; i++)
        {
            if (bufor[i] == '1')
            {
                double j = (i + 1) * (-1);
                liczba += Math.Pow(2.0, j);
            }
        }
        return liczba;
    }
    public override string dekodowanie1(string Kod2)
    {
        Slowo = "";
        biezacyPrzedzialOd = 0.0;
        biezacyPrzedzialDo = 1.0;
        Kod = kodNaDzies(Kod2);
        while (true)
        {
            while (true)
            {
                if (biezacyPrzedzialOd >= 0 && biezacyPrzedzialOd < 0.5 && biezacyPrzedzialDo >= 0 && biezacyPrzedzialDo < 0.5)
                {
                    continue;
                }
                else if (biezacyPrzedzialOd >= 0.5 && biezacyPrzedzialOd < 1 && biezacyPrzedzialDo >= 0.5 && biezacyPrzedzialDo < 1)
                {
                    biezacyPrzedzialOd -= 0.5;
                    biezacyPrzedzialDo -= 0.5;
                    Kod -= 0.5;
                }
                else if (biezacyPrzedzialOd >= 16 && biezacyPrzedzialOd <= 48 && biezacyPrzedzialDo >= 16 && biezacyPrzedzialDo <= 48)
                {
                    biezacyPrzedzialOd -= 0.25;
                    biezacyPrzedzialDo -= 0.25;
                    Kod -= 0.25;
                }
                else break;
                biezacyPrzedzialOd *= 2;
                biezacyPrzedzialDo *= 2;
                Kod *= 2;
            }


            ustawPodPrzedzialy(biezacyPrzedzialOd, biezacyPrzedzialDo);
            if (przedzial1Od <= Kod && Kod <= przedzial1Do)
            {
                Slowo += "A";
                biezacyPrzedzialOd = przedzial1Od;
                biezacyPrzedzialDo = przedzial1Do;
            }
            else if (przedzial2Od <= Kod && Kod <= przedzial2Do)
            {
                Slowo += "B";
                biezacyPrzedzialOd = przedzial2Od;
                biezacyPrzedzialDo = przedzial2Do;
            }
            else if (przedzial3Od <= Kod && Kod <= przedzial3Do)
            {
                Slowo += "C";
                biezacyPrzedzialOd = przedzial3Od;
                biezacyPrzedzialDo = przedzial3Do;

            }
            else if (przedzial4Od <= Kod && Kod <= przedzial4Do)
            {
                Slowo += "#";
                break;
            }
        }
        return Slowo;
    }
    public override double kodowanie(string Slowo)
    {
        return 0;
    }
    public override string dekodowanie(double Kod)
    {
        return "0";
    }
}
class KodowanieCalkowitoliczbowe : Kodowanie
{
    public static int lBitow = 0, kodLcal;
    public static string bity = "", calTemp;
    char[] bufor1 = new char[6];
    char[] bufor2 = new char[20];
    public KodowanieCalkowitoliczbowe()
    {
        this.Slowo = "0";
    }
    public KodowanieCalkowitoliczbowe(string slowo)
    {
        this.Slowo = slowo;
    }
    public void ustawPrzedzial(double biezacyPrzedzialOd, double biezacyPrzedzialDo, int k, string Slowo)
    {
        for (int i = k; i < Slowo.Length;)
        {
            if (Slowo[i] == 'A')
            {
                przedzialOd = biezacyPrzedzialOd;
                przedzialOd = Math.Floor(przedzialOd);
                przedzialDo = (biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.4) - 1;
                przedzialDo = Math.Floor(przedzialDo);
                break;
            }
            else if (Slowo[i] == 'B')
            {
                przedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.4;
                przedzialOd = Math.Floor(przedzialOd);
                przedzialDo = (biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.7) - 1;
                przedzialDo = Math.Floor(przedzialDo);
                break;
            }
            else if (Slowo[i] == 'C')
            {
                przedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.7;
                przedzialOd = Math.Floor(przedzialOd);
                przedzialDo = (biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.9) - 1;
                przedzialDo = Math.Floor(przedzialDo);
                break;
            }
            else if (Slowo[i] == '#')
            {
                przedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.9;
                przedzialOd = Math.Floor(przedzialOd);
                przedzialDo = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 1;
                przedzialDo = Math.Floor(przedzialDo);
                break;
            }
            else break;
        }
    }
    public override string kodowanie1(string Slowo)
    {
        biezacyPrzedzialOd = 0;
        biezacyPrzedzialDo = 63;
        for (int k = 0; k <= Slowo.Length; k++)
        {
            if (k == Slowo.Length)
            {
                lBitow++;
                if (biezacyPrzedzialOd < 16)
                {
                    if (lBitow == 0) bity = "";
                    else if (lBitow == 1) bity = "1";
                    else if (lBitow == 2) bity = "11";
                    else if (lBitow == 3) bity = "111";
                    else if (lBitow == 4) bity = "1111";
                    Kod2 = Kod2 + "0" + bity;
                    return Kod2;
                }
                else
                {
                    if (lBitow == 0) bity = "";
                    else if (lBitow == 1) bity = "0";
                    else if (lBitow == 2) bity = "00";
                    else if (lBitow == 3) bity = "000";
                    else if (lBitow == 4) bity = "0000";
                    Kod2 = Kod2 + "1" + bity;
                    return Kod2;
                }
            }
            ustawPrzedzial(biezacyPrzedzialOd, biezacyPrzedzialDo, k, Slowo);
            biezacyPrzedzialOd = przedzialOd;
            biezacyPrzedzialDo = przedzialDo;
            while (true)
            {

                if (biezacyPrzedzialOd >= 0 && biezacyPrzedzialOd < 32 && biezacyPrzedzialDo >= 0 && biezacyPrzedzialDo < 32)
                {
                    if (lBitow == 0) bity = "";
                    else if (lBitow == 1) bity = "1";
                    else if (lBitow == 2) bity = "11";
                    else if (lBitow == 3) bity = "111";
                    else if (lBitow == 4) bity = "1111";
                    Kod2 = Kod2 + "0" + bity;
                    lBitow = 0;

                }
                else if (biezacyPrzedzialOd >= 32 && biezacyPrzedzialOd < 64 && biezacyPrzedzialDo >= 32 && biezacyPrzedzialDo < 64)
                {
                    if (lBitow == 0) bity = "";
                    else if (lBitow == 1) bity = "0";
                    else if (lBitow == 2) bity = "00";
                    else if (lBitow == 3) bity = "000";
                    else if (lBitow == 4) bity = "0000";
                    Kod2 = Kod2 + "1" + bity;
                    lBitow = 0;
                    biezacyPrzedzialOd -= 32;
                    biezacyPrzedzialDo -= 32;

                }
                else if (biezacyPrzedzialOd >= 16 && biezacyPrzedzialOd <= 48 && biezacyPrzedzialDo >= 16 && biezacyPrzedzialDo < 48)
                {
                    lBitow++;
                    biezacyPrzedzialOd -= 16;
                    biezacyPrzedzialDo -= 16;
                }
                else break;
                biezacyPrzedzialOd *= 2;
                biezacyPrzedzialDo *= 2;
                biezacyPrzedzialDo += 1;
            }
        }
        return Kod2;
    }
    public void ustawPodPrzedzial(double biezacyPrzedzialOd, double biezacyPrzedzialDo)
    {
        przedzial1Od = biezacyPrzedzialOd;
        przedzial1Do = (biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.4) - 1;
        przedzial1Do = Math.Floor(przedzial1Do);

        przedzial2Od = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.4;
        przedzial2Od = Math.Floor(przedzial2Od);
        przedzial2Do = (biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.7) - 1;
        przedzial2Do = Math.Floor(przedzial2Do);

        przedzial3Od = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.7;
        przedzial3Od = Math.Floor(przedzial3Od);
        przedzial3Do = (biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.9) - 1;
        przedzial3Do = Math.Floor(przedzial3Do);

        przedzial4Od = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.9;
        przedzial4Od = Math.Floor(przedzial4Od);
        przedzial4Do = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 1;
        przedzial4Do = Math.Floor(przedzial4Do);
    }
    public int zamianaBinNaInt(char[] bufor)
    {
        calTemp = "";
        for (int i = 0; i < bufor.Length; i++)
        {
            calTemp += bufor[i].ToString();
        }
        kodLcal = Convert.ToByte(calTemp, 2);

        return kodLcal;
    }
    public void przesunBit(char[] Bufor1, char[] Bufor2)
    {
        for (int i = 0; i < 6; i++)
        {
            if (i == 5)
            {
                bufor1[i] = bufor2[i - 5];
                break;
            }
            else bufor1[i] = bufor1[i + 1];
        }
        for (int i = 0; i < bufor2.Length; i++)
        {
            if (i < bufor2.Length - 1) bufor2[i] = bufor2[i + 1];
            else bufor2[bufor2.Length - 1] = '0';
        }
    }
    public override string dekodowanie1(string Kod2)
    {

        Slowo = "";
        biezacyPrzedzialOd = 0;
        biezacyPrzedzialDo = 63;
        for (int i = 0; i < bufor1.Length; i++)
        {
            bufor1[i] = Kod2[i];
        }
        for (int i = 6; i < Kod2.Length; i++)
        {

            bufor2[i - 6] = Kod2[i];
        }
        for (int k = bufor2.Length - 1; k > Kod2.Length - bufor1.Length - 1; k--)
            bufor2[k] = '0';
        kodLcal = zamianaBinNaInt(bufor1);

        while (true)
        {
            while (true)
            {
                if (biezacyPrzedzialOd >= 0 && biezacyPrzedzialOd < 32 && biezacyPrzedzialDo >= 0 && biezacyPrzedzialDo < 32)
                {
                    przesunBit(bufor1, bufor2);
                    kodLcal = zamianaBinNaInt(bufor1);
                }
                else if (biezacyPrzedzialOd >= 32 && biezacyPrzedzialOd < 64 && biezacyPrzedzialDo >= 32 && biezacyPrzedzialDo < 64)
                {
                    biezacyPrzedzialOd -= 32;
                    biezacyPrzedzialDo -= 32;
                    kodLcal -= 32;
                    calTemp = Convert.ToString(kodLcal, 2);
                    int j = 0;
                    for (int i = calTemp.Length - 1; i >= 0; i--)
                    {

                        bufor1[bufor1.Length - 1 - j] = calTemp[i];
                        j++;

                    }
                    for (int k = 0; k < bufor1.Length - calTemp.Length; k++)
                        bufor1[k] = '0';
                    przesunBit(bufor1, bufor2);
                    kodLcal = zamianaBinNaInt(bufor1);
                }
                else if (biezacyPrzedzialOd >= 16 && biezacyPrzedzialOd <= 48 && biezacyPrzedzialDo >= 16 && biezacyPrzedzialDo <= 48)
                {
                    biezacyPrzedzialOd -= 16;
                    biezacyPrzedzialDo -= 16;
                    kodLcal -= 16;
                    calTemp = Convert.ToString(kodLcal, 2);
                    int j = 0;
                    for (int i = calTemp.Length - 1; i >= 0; i--)
                    {

                        bufor1[bufor1.Length - 1 - j] = calTemp[i];
                        j++;

                    }
                    for (int k = 0; k < bufor1.Length - calTemp.Length; k++)
                        bufor1[k] = '0';

                    przesunBit(bufor1, bufor2);
                    kodLcal = zamianaBinNaInt(bufor1);
                }
                else break;
                biezacyPrzedzialOd *= 2;
                biezacyPrzedzialDo *= 2;
                biezacyPrzedzialDo += 1;
            }

            ustawPodPrzedzial(biezacyPrzedzialOd, biezacyPrzedzialDo);
            if (przedzial1Od <= kodLcal && kodLcal <= przedzial1Do)
            {
                Slowo += "A";
                biezacyPrzedzialOd = przedzial1Od;
                biezacyPrzedzialDo = przedzial1Do;
            }
            else if (przedzial2Od <= kodLcal && kodLcal <= przedzial2Do)
            {
                Slowo += "B";
                biezacyPrzedzialOd = przedzial2Od;
                biezacyPrzedzialDo = przedzial2Do;
            }
            else if (przedzial3Od <= kodLcal && kodLcal <= przedzial3Do)
            {
                Slowo += "C";
                biezacyPrzedzialOd = przedzial3Od;
                biezacyPrzedzialDo = przedzial3Do;

            }
            else if (przedzial4Od <= kodLcal && kodLcal <= przedzial4Do)
            {
                Slowo += "#";
                break;
            }
        }
        return Slowo;
    }
    public override double kodowanie(string Slowo)
    {
        return 0;
    }
    public override string dekodowanie(double Kod)
    {
        return "0";
    }
}   