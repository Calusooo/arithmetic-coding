using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArithmeticCoding.ABSCoding;

namespace ArithmeticCoding.IntCoding
{
    public class IntegerCoding : Coding
    {
        public static int lBitow = 0, kodLcal;
        public static string bity = "", calTemp;
        char[] bufor1 = new char[6];
        char[] bufor2 = new char[20];
        public IntegerCoding()
        {
            this.Slowo = "0";
        }
        public IntegerCoding(string slowo)
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
}
