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
        public static int numberOfBits = 0;
        public static string bits = "";
        public static double dblNumber;
        public BinaryCoding()
        {
            this.Word = "0";
        }
        public BinaryCoding(string word)
        {
            this.Word = word;
        }
        public void UstawPrzedzial(double biezacyPrzedzialOd, double biezacyPrzedzialDo, int k, string word)
        {
            for (int i = k; i <= word.Length;)
            {
                if (i == word.Length) { break; }
                else if (word[i] == 'A')
                {
                    PrzedzialOd = biezacyPrzedzialOd;
                    PrzedzialDo = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.4;
                    break;
                }
                else if (word[i] == 'B')
                {
                    PrzedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.4;
                    PrzedzialDo = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.7;
                    break;
                }
                else if (word[i] == 'C')
                {
                    PrzedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.7;
                    PrzedzialDo = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.9;
                    break;
                }
                else if (word[i] == '#')
                {
                    PrzedzialOd = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 0.9;
                    PrzedzialDo = biezacyPrzedzialOd + (biezacyPrzedzialDo - biezacyPrzedzialOd) * 1;
                    break;
                }
                else break;
            }
        }
        public override string Kodowanie1(string word)
        {
            BiezacyPrzedzialOd = 0.0;
            BiezacyPrzedzialDo = 1.0;
            for (int k = 0; k <= word.Length; k++)
            {
                UstawPrzedzial(BiezacyPrzedzialOd, BiezacyPrzedzialDo, k, word);
                BiezacyPrzedzialOd = PrzedzialOd;
                BiezacyPrzedzialDo = PrzedzialDo;
                if (k == word.Length)
                {
                    numberOfBits++;
                    if (BiezacyPrzedzialOd < 0.25)
                    {
                        if (numberOfBits == 0) bits = "";
                        else if (numberOfBits == 1) bits = "1";
                        else if (numberOfBits == 2) bits = "11";
                        else if (numberOfBits == 3) bits = "111";
                        else if (numberOfBits == 4) bits = "1111";
                        CodeStr = CodeStr + "0" + bits;
                        return CodeStr;
                    }
                    else
                    {
                        if (numberOfBits == 0) bits = "";
                        else if (numberOfBits == 1) bits = "0";
                        else if (numberOfBits == 2) bits = "00";
                        else if (numberOfBits == 3) bits = "000";
                        else if (numberOfBits == 4) bits = "0000";
                        CodeStr = CodeStr + "1" + bits;
                        return CodeStr;
                    }
                }
                while (true)
                {
                    if (BiezacyPrzedzialOd >= 0.25 && BiezacyPrzedzialOd < 0.75 && BiezacyPrzedzialDo >= 0.25 && BiezacyPrzedzialDo < 0.75)
                    {
                        numberOfBits++;
                        BiezacyPrzedzialOd -= 0.25;
                        BiezacyPrzedzialDo -= 0.25;
                    }
                    else if (BiezacyPrzedzialOd >= 0 && BiezacyPrzedzialOd < 0.5 && BiezacyPrzedzialDo >= 0 && BiezacyPrzedzialDo < 0.5)
                    {
                        if (numberOfBits == 0) bits = "";
                        else if (numberOfBits == 1) bits = "1";
                        else if (numberOfBits == 2) bits = "11";
                        else if (numberOfBits == 3) bits = "111";
                        else if (numberOfBits == 4) bits = "1111";
                        CodeStr = CodeStr + "0" + bits;
                        numberOfBits = 0;
                    }
                    else if (BiezacyPrzedzialOd >= 0.5 && BiezacyPrzedzialOd < 1 && BiezacyPrzedzialDo >= 0.5 && BiezacyPrzedzialDo < 1)
                    {
                        if (numberOfBits == 0) bits = "";
                        else if (numberOfBits == 1) bits = "0";
                        else if (numberOfBits == 2) bits = "00";
                        else if (numberOfBits == 3) bits = "000";
                        else if (numberOfBits == 4) bits = "0000";
                        CodeStr = CodeStr + "1" + bits;
                        numberOfBits = 0;
                        BiezacyPrzedzialOd -= 0.5;
                        BiezacyPrzedzialDo -= 0.5;
                    }
                    else break;
                    BiezacyPrzedzialOd *= 2;
                    BiezacyPrzedzialDo *= 2;
                }
            }
            return CodeStr;
        }
        public double BinaryToDoubleConverter(string codeStr)
        {
            int n = codeStr.Length;
            char[] bufor = new char[n];
            dblNumber = 0.0;
            for (int i = 0; i < codeStr.Length; i++)
            {
                bufor[i] = codeStr[i];
            }
            for (int i = 0; i < bufor.Length; i++)
            {
                if (bufor[i] == '1')
                {
                    double j = (i + 1) * (-1);
                    dblNumber += Math.Pow(2.0, j);
                }
            }
            return dblNumber;
        }

        public override string Dekodowanie1(string codeStr)
        {
            Word = "";
            BiezacyPrzedzialOd = 0.0;
            BiezacyPrzedzialDo = 1.0;
            CodeDbl = BinaryToDoubleConverter(codeStr);
            while (true)
            {
                while (true)
                {
                    if (BiezacyPrzedzialOd >= 0 && BiezacyPrzedzialOd < 0.5 && BiezacyPrzedzialDo >= 0 && BiezacyPrzedzialDo < 0.5)
                    {
                        continue;
                    }
                    else if (BiezacyPrzedzialOd >= 0.5 && BiezacyPrzedzialOd < 1 && BiezacyPrzedzialDo >= 0.5 && BiezacyPrzedzialDo < 1)
                    {
                        BiezacyPrzedzialOd -= 0.5;
                        BiezacyPrzedzialDo -= 0.5;
                        CodeDbl -= 0.5;
                    }
                    else if (BiezacyPrzedzialOd >= 16 && BiezacyPrzedzialOd <= 48 && BiezacyPrzedzialDo >= 16 && BiezacyPrzedzialDo <= 48)
                    {
                        BiezacyPrzedzialOd -= 0.25;
                        BiezacyPrzedzialDo -= 0.25;
                        CodeDbl -= 0.25;
                    }
                    else break;
                    BiezacyPrzedzialOd *= 2;
                    BiezacyPrzedzialDo *= 2;
                    CodeDbl *= 2;
                }


                UstawPodPrzedzialy(BiezacyPrzedzialOd, BiezacyPrzedzialDo);
                if (przedzial1Od <= CodeDbl && CodeDbl <= przedzial1Do)
                {
                    Word += "A";
                    BiezacyPrzedzialOd = przedzial1Od;
                    BiezacyPrzedzialDo = przedzial1Do;
                }
                else if (przedzial2Od <= CodeDbl && CodeDbl <= przedzial2Do)
                {
                    Word += "B";
                    BiezacyPrzedzialOd = przedzial2Od;
                    BiezacyPrzedzialDo = przedzial2Do;
                }
                else if (przedzial3Od <= CodeDbl && CodeDbl <= przedzial3Do)
                {
                    Word += "C";
                    BiezacyPrzedzialOd = przedzial3Od;
                    BiezacyPrzedzialDo = przedzial3Do;

                }
                else if (przedzial4Od <= CodeDbl && CodeDbl <= przedzial4Do)
                {
                    Word += "#";
                    break;
                }
            }
            return Word;
        }

        public override double Kodowanie(string word)
        {
            return 0;
        }

        public override string Dekodowanie(double codeDbl)
        {
            return "0";
        }
    }
}
