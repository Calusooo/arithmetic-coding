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
            this.WordToCode = "0";
            this.FloatingPointCodeToDecode = 0;
        }

        public ReadData(string word)
        {
            this.WordToCode = word;
        }

        public ReadData(double code)
        {
            this.FloatingPointCodeToDecode = code;
        }

        public string WordToCode
        {
            get;
            protected set;
        }

        public string IntegerCodeToDecode
        {
            get;
            protected set;
        }

        public string BinaryCodeToDecode
        {
            get;
            protected set;
        }

        public double FloatingPointCodeToDecode
        {
            get;
            protected set;
        }

        public string ReadWord()
        {
            Console.Write("Podaj slowo: ");
            WordToCode = Console.ReadLine();
            return WordToCode;
        }

        public double ReadFloatingPointCodeToDecode()
        {
            Console.Write("Wprowadz wygenerowany kod zmiennoprzecinkowy: ");
            FloatingPointCodeToDecode = Convert.ToDouble(Console.ReadLine());
            return FloatingPointCodeToDecode;
        }

        public string ReadBinaryCodeToDecode()
        {
            Console.Write("Wprowadz wygenerowany kod binarny: ");
            BinaryCodeToDecode = Console.ReadLine();
            return BinaryCodeToDecode;
        }

        public string ReadIntegerCodeToDecode()
        {
            Console.Write("Wprowadz wygenerowany kod calkowity: ");
            IntegerCodeToDecode = Console.ReadLine();
            return IntegerCodeToDecode;
        }
    }
}
