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
            this.Word = "0";
        }
        public IntegerCoding(string word)
        {
            this.Word = word;
        }
        public void UstawPrzedzial(double biezacyPrzedzialOd, double biezacyPrzedzialDo, int k, string word)
        {
            for (int i = k; i < word.Length;)
            {
                if (word[i] == 'A')
                {
                    PrzedzialOd = biezacyPrzedzialOd;
                    PrzedzialOd = Math.Floor(PrzedzialOd);
                    PrzedzialDo = (biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.4) - 1;
                    PrzedzialDo = Math.Floor(PrzedzialDo);
                    break;
                }
                else if (word[i] == 'B')
                {
                    PrzedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.4;
                    PrzedzialOd = Math.Floor(PrzedzialOd);
                    PrzedzialDo = (biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.7) - 1;
                    PrzedzialDo = Math.Floor(PrzedzialDo);
                    break;
                }
                else if (word[i] == 'C')
                {
                    PrzedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.7;
                    PrzedzialOd = Math.Floor(PrzedzialOd);
                    PrzedzialDo = (biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.9) - 1;
                    PrzedzialDo = Math.Floor(PrzedzialDo);
                    break;
                }
                else if (word[i] == '#')
                {
                    PrzedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd + 1) * 0.9;
                    PrzedzialOd = Math.Floor(PrzedzialOd);
                    PrzedzialDo = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 1;
                    PrzedzialDo = Math.Floor(PrzedzialDo);
                    break;
                }
                else break;
            }
        }

        public override string Kodowanie1(string word)
        {
            BiezacyPrzedzialOd = 0;
            BiezacyPrzedzialDo = 63;
            for (int k = 0; k <= word.Length; k++)
            {
                if (k == word.Length)
                {
                    lBitow++;
                    if (BiezacyPrzedzialOd < 16)
                    {
                        if (lBitow == 0) bity = "";
                        else if (lBitow == 1) bity = "1";
                        else if (lBitow == 2) bity = "11";
                        else if (lBitow == 3) bity = "111";
                        else if (lBitow == 4) bity = "1111";
                        CodeStr = CodeStr + "0" + bity;
                        return CodeStr;
                    }
                    else
                    {
                        if (lBitow == 0) bity = "";
                        else if (lBitow == 1) bity = "0";
                        else if (lBitow == 2) bity = "00";
                        else if (lBitow == 3) bity = "000";
                        else if (lBitow == 4) bity = "0000";
                        CodeStr = CodeStr + "1" + bity;
                        return CodeStr;
                    }
                }
                UstawPrzedzial(BiezacyPrzedzialOd, BiezacyPrzedzialDo, k, word);
                BiezacyPrzedzialOd = PrzedzialOd;
                BiezacyPrzedzialDo = PrzedzialDo;
                while (true)
                {

                    if (BiezacyPrzedzialOd >= 0 && BiezacyPrzedzialOd < 32 && BiezacyPrzedzialDo >= 0 && BiezacyPrzedzialDo < 32)
                    {
                        if (lBitow == 0) bity = "";
                        else if (lBitow == 1) bity = "1";
                        else if (lBitow == 2) bity = "11";
                        else if (lBitow == 3) bity = "111";
                        else if (lBitow == 4) bity = "1111";
                        CodeStr = CodeStr + "0" + bity;
                        lBitow = 0;

                    }
                    else if (BiezacyPrzedzialOd >= 32 && BiezacyPrzedzialOd < 64 && BiezacyPrzedzialDo >= 32 && BiezacyPrzedzialDo < 64)
                    {
                        if (lBitow == 0) bity = "";
                        else if (lBitow == 1) bity = "0";
                        else if (lBitow == 2) bity = "00";
                        else if (lBitow == 3) bity = "000";
                        else if (lBitow == 4) bity = "0000";
                        CodeStr = CodeStr + "1" + bity;
                        lBitow = 0;
                        BiezacyPrzedzialOd -= 32;
                        BiezacyPrzedzialDo -= 32;

                    }
                    else if (BiezacyPrzedzialOd >= 16 && BiezacyPrzedzialOd <= 48 && BiezacyPrzedzialDo >= 16 && BiezacyPrzedzialDo < 48)
                    {
                        lBitow++;
                        BiezacyPrzedzialOd -= 16;
                        BiezacyPrzedzialDo -= 16;
                    }
                    else break;
                    BiezacyPrzedzialOd *= 2;
                    BiezacyPrzedzialDo *= 2;
                    BiezacyPrzedzialDo += 1;
                }
            }
            return CodeStr;
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
        public override string Dekodowanie1(string Kod2)
        {

            Word = "";
            BiezacyPrzedzialOd = 0;
            BiezacyPrzedzialDo = 63;
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
                    if (BiezacyPrzedzialOd >= 0 && BiezacyPrzedzialOd < 32 && BiezacyPrzedzialDo >= 0 && BiezacyPrzedzialDo < 32)
                    {
                        przesunBit(bufor1, bufor2);
                        kodLcal = zamianaBinNaInt(bufor1);
                    }
                    else if (BiezacyPrzedzialOd >= 32 && BiezacyPrzedzialOd < 64 && BiezacyPrzedzialDo >= 32 && BiezacyPrzedzialDo < 64)
                    {
                        BiezacyPrzedzialOd -= 32;
                        BiezacyPrzedzialDo -= 32;
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
                    else if (BiezacyPrzedzialOd >= 16 && BiezacyPrzedzialOd <= 48 && BiezacyPrzedzialDo >= 16 && BiezacyPrzedzialDo <= 48)
                    {
                        BiezacyPrzedzialOd -= 16;
                        BiezacyPrzedzialDo -= 16;
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
                    BiezacyPrzedzialOd *= 2;
                    BiezacyPrzedzialDo *= 2;
                    BiezacyPrzedzialDo += 1;
                }

                ustawPodPrzedzial(BiezacyPrzedzialOd, BiezacyPrzedzialDo);
                if (przedzial1Od <= kodLcal && kodLcal <= przedzial1Do)
                {
                    Word += "A";
                    BiezacyPrzedzialOd = przedzial1Od;
                    BiezacyPrzedzialDo = przedzial1Do;
                }
                else if (przedzial2Od <= kodLcal && kodLcal <= przedzial2Do)
                {
                    Word += "B";
                    BiezacyPrzedzialOd = przedzial2Od;
                    BiezacyPrzedzialDo = przedzial2Do;
                }
                else if (przedzial3Od <= kodLcal && kodLcal <= przedzial3Do)
                {
                    Word += "C";
                    BiezacyPrzedzialOd = przedzial3Od;
                    BiezacyPrzedzialDo = przedzial3Do;

                }
                else if (przedzial4Od <= kodLcal && kodLcal <= przedzial4Do)
                {
                    Word += "#";
                    break;
                }
            }
            return Word;
        }
        public override double Kodowanie(string Slowo)
        {
            return 0;
        }
        public override string Dekodowanie(double Kod)
        {
            return "0";
        }
    }
}
