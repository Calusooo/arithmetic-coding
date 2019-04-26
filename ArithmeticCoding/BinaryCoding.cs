using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArithmeticCoding.ABSCoding;

namespace ArithmeticCoding.BCoding
{
    public class BinaryCoding : Coding
    {
        public static int lBitow = 0;
        public static string bity = "";
        public static double liczba;
        public BinaryCoding()
        {
            this.Slowo = "0";
        }
        public BinaryCoding(string slowo)
        {
            this.Slowo = slowo;
        }
        public void ustawPrzedzial(double biezacyPrzedzialOd, double biezacyPrzedzialDo, int k, string Slowo)
        {
            for (int i = k; i <= Slowo.Length;)
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
}
