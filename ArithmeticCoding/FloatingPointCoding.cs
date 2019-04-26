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
            this.Slowo = "0";
        }
        public FloatingPointCoding(string slowo)
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
}
