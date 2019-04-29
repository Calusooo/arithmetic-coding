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
        // dołożyć dla wielu języków i18n
        public static string wordToCode, binaryCode, integerCode, integerDecode, binaryDecode, floatingPointWord, integerWord, binaryWord;
        public static double floatingPointCode, floatingPointDecode;

        static void Main(string[] args)
        {
            
            Console.WriteLine("KODOWANIE: ");
            Console.WriteLine("Podaj slowo do zakodowania składające się z 5 znakow (P = {0,4;0,3;0.2;0.1)");
            Console.WriteLine("Bank znaków: A,B,C - jako 5 znak wprowadz #");
            ReadData word = new ReadData();
            wordToCode = word.ReadWord();

            Coding fpCode = new FloatingPointCoding();
            floatingPointCode = fpCode.Kodowanie(wordToCode);
            Console.WriteLine($"Kod zmiennoprzecinkowy dla slowa {wordToCode} = {floatingPointCode}");

            Coding binCode = new BinaryCoding();
            binaryCode = binCode.Kodowanie(wordToCode);
            Console.WriteLine($"Kod binarny dla slowa {wordToCode} = {binaryCode}");

            Coding intCode = new IntegerCoding();
            integerCode = intCode.Kodowanie(wordToCode);
            Console.WriteLine($"Kod calkowitoliczbowy dla slowa {wordToCode} = {floatingPointCode}");

            Console.WriteLine();
            Console.WriteLine("DEKODOWANIE: ");
            ReadData code = new ReadData();
            floatingPointDecode = code.ReadFloatingPointCodeToDecode();
            Coding slowo10 = new FloatingPointCoding();
            floatingPointWord = slowo10.Dekodowanie(floatingPointDecode);
            Console.WriteLine($"Zdekodowanie slowo (zmiennoprzecinkowe) brzmi: {floatingPointWord}");
            

            ReadData kod3 = new ReadData();
            binaryDecode = kod3.ReadBinaryCodeToDecode();
            Coding slowo30 = new BinaryCoding();
            binaryWord = slowo30.Dekodowanie1(binaryDecode);
            Console.WriteLine($"Zdekodowanie slowo (binarne) brzmi: {binaryWord}");

            ReadData kod2 = new ReadData();
            integerDecode = kod2.ReadIntegerCodeToDecode();
            Coding slowo20 = new IntegerCoding();
            integerWord = slowo20.Dekodowanie1(integerDecode);
            Console.WriteLine($"Zdekodowanie slowo (calkowitoliczbowe) brzmi: {integerWord}");


            Console.ReadLine();
        }
    }
}