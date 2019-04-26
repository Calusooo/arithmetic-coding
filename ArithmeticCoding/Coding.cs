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
            this.Kod = 0;
            this.Kod2 = "";
        }

        public Coding(double kod)
        {
            this.Kod = kod;
        }

        public Coding(string kod)
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
}
