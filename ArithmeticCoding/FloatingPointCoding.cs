using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArithmeticCoding.ABSCoding;

namespace ArithmeticCoding.FPCoding
{
    public class FloatingPointCoding : Coding
    {
        public FloatingPointCoding()
        {
            this.Word = "0";
        }
        public FloatingPointCoding(string slowo)
        {
            this.Word = slowo;
        }
        public override double Kodowanie(string Slowo)
        {
            BiezacyPrzedzialOd = 0.0;
            BiezacyPrzedzialDo = 1.0;
            for (int i = 0; i <= Slowo.Length; i++)
            {
                if (Slowo[i] == 'A')
                {
                    PrzedzialOd = BiezacyPrzedzialOd;
                    PrzedzialDo = BiezacyPrzedzialOd + (BiezacyPrzedzialDo - BiezacyPrzedzialOd) * 0.4;
                    BiezacyPrzedzialOd = PrzedzialOd;
                    BiezacyPrzedzialDo = PrzedzialDo;
                }
                else if (Slowo[i] == 'B')
                {
                    PrzedzialOd = BiezacyPrzedzialOd + (BiezacyPrzedzialDo - BiezacyPrzedzialOd) * 0.4;
                    PrzedzialDo = BiezacyPrzedzialOd + (BiezacyPrzedzialDo - BiezacyPrzedzialOd) * 0.7;
                    BiezacyPrzedzialOd = PrzedzialOd;
                    BiezacyPrzedzialDo = PrzedzialDo;
                }
                else if (Slowo[i] == 'C')
                {
                    PrzedzialOd = BiezacyPrzedzialOd + (BiezacyPrzedzialDo - BiezacyPrzedzialOd) * 0.7;
                    PrzedzialDo = BiezacyPrzedzialOd + (BiezacyPrzedzialDo - BiezacyPrzedzialOd) * 0.9;
                    BiezacyPrzedzialOd = PrzedzialOd;
                    BiezacyPrzedzialDo = PrzedzialDo;
                }
                else if (Slowo[i] == '#')
                {
                    PrzedzialOd = BiezacyPrzedzialOd + (BiezacyPrzedzialDo - BiezacyPrzedzialOd) * 0.9;
                    PrzedzialDo = BiezacyPrzedzialOd + (BiezacyPrzedzialDo - BiezacyPrzedzialOd) * 1;
                    BiezacyPrzedzialOd = PrzedzialOd;
                    BiezacyPrzedzialDo = PrzedzialDo;
                    CodeDbl = PrzedzialOd;
                    break;
                }
            }

            return CodeDbl;
        }
        public override string Dekodowanie(double codeDbl)
        {
            Word = "";
            BiezacyPrzedzialOd = 0.0;
            BiezacyPrzedzialDo = 1.0;
            while (true)
            {
                UstawPodPrzedzialy(BiezacyPrzedzialOd, BiezacyPrzedzialDo);
                if (przedzial1Od < codeDbl && codeDbl < przedzial1Do)
                {
                    Word += "A";
                    BiezacyPrzedzialOd = przedzial1Od;
                    BiezacyPrzedzialDo = przedzial1Do;
                }
                else if (przedzial2Od <= codeDbl && codeDbl < przedzial2Do)
                {
                    Word += "B";
                    BiezacyPrzedzialOd = przedzial2Od;
                    BiezacyPrzedzialDo = przedzial2Do;
                }
                else if (przedzial3Od <= codeDbl && codeDbl < przedzial3Do)
                {
                    Word += "C";
                    BiezacyPrzedzialOd = przedzial3Od;
                    BiezacyPrzedzialDo = przedzial3Do;
                }
                else if (przedzial4Od <= codeDbl && codeDbl < przedzial4Do)
                {
                    Word += "#";
                    break;
                }
            }

            return Word;
        }
        public override string Kodowanie1(string word)
        {
            return "0";
        }
        public override string Dekodowanie1(string codeStr)
        {
            return "0";
        }
    }
}
