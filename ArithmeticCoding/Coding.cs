using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticCoding.ABSCoding
{
    public abstract class Coding
    {
        public static double przedzial1Od, przedzial2Od, przedzial3Od, przedzial4Od;
        public static double przedzial1Do, przedzial2Do, przedzial3Do, przedzial4Do;
        public Coding()
        {
            this.CodeDbl = 0;
            this.CodeStr = "";
        }

        public Coding(double code)
        {
            this.CodeDbl = code;
        }

        public Coding(string code)
        {
            this.CodeStr = code;
        }

        public double CodeDbl
        {
            get;
            protected set;
        }

        public string CodeStr
        {
            get;
            protected set;
        }

        public string Word
        {
            get;
            protected set;
        }

        public double BiezacyPrzedzialOd
        {
            get;
            protected set;
        }

        public double BiezacyPrzedzialDo
        {
            get;
            protected set;
        }

        public double PrzedzialOd
        {
            get;
            protected set;
        }

        public double PrzedzialDo
        {
            get;
            protected set;
        }

        public void UstawPodPrzedzialy(double biezacyPrzedzialOd, double biezacyPrzedzialDo)
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
        abstract public double Kodowanie(string word);
        abstract public string Kodowanie1(string word);
        abstract public string Dekodowanie(double codeDbl);
        abstract public string Dekodowanie1(string codeSrt);
    }
}
