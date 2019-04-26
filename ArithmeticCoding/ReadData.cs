using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticCoding.ReadingData
{
    public class ReadData
    {
        public ReadData()
        {
            this.Slowo1 = "0";
            this.KodZM = 0;
        }

        public ReadData(string slowo)
        {
            this.Slowo1 = slowo;
        }

        public ReadData(double kod)
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
}
