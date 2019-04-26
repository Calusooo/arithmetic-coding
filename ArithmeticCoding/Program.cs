using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArithmeticCoding.ReadingData;
using ArithmeticCoding.ABSCoding;
using ArithmeticCoding.FPCoding;
using ArithmeticCoding.BCoding;
using ArithmeticCoding.IntCoding;

namespace ArithmeticCoding
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
            ReadData slowo1 = new ReadData();
            slowo = slowo1.czytajSlowo();

            Coding kod10 = new FloatingPointCoding();
            kodZ = kod10.kodowanie(slowo);
            Console.WriteLine("Kod zmiennoprzecinkowy dla slowa " + slowo + " = " + kodZ);

            Coding kod20 = new BinaryCoding();
            kodB = kod20.kodowanie1(slowo);
            Console.WriteLine("Kod binarny dla slowa " + slowo + " = " + kodB);

            Coding kod30 = new IntegerCoding();
            kodC = kod30.kodowanie1(slowo);
            Console.WriteLine("Kod calkowitoliczbowy dla slowa " + slowo + " = " + kodC);

            Console.WriteLine();
            Console.WriteLine("DEKODOWANIE: ");
            ReadData kod1 = new ReadData();
            kodZM = kod1.czytajKod();
            Coding slowo10 = new FloatingPointCoding();
            slowoZ = slowo10.dekodowanie(kodZM);
            Console.WriteLine("Zdekodowanie slowo (zmiennoprzecinkowe) brzmi: " + slowoZ);

            ReadData kod3 = new ReadData();
            kodBin = kod3.czytajKod2();
            Coding slowo30 = new BinaryCoding();
            slowoB = slowo30.dekodowanie1(kodBin);
            Console.WriteLine("Zdekodowanie slowo (binarne) brzmi: " + slowoZ);

            ReadData kod2 = new ReadData();
            kodCal = kod2.czytajKod1();
            Coding slowo20 = new IntegerCoding();
            slowoC = slowo20.dekodowanie1(kodCal);
            Console.WriteLine("Zdekodowanie slowo (calkowitoliczbowe) brzmi: " + slowoC);
            
            Console.ReadLine();
        }
    }
}