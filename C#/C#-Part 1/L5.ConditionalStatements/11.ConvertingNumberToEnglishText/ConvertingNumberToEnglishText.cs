using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ConvertingNumberToEnglishText
{
    class ConvertingNumberToEnglishText
    {
        static void Main()
        {
            string numberAsString = Console.ReadLine();
            int number;
            bool parser = int.TryParse(numberAsString, out number);
            if (parser = false || number < 0 || number > 999)
            {
                Console.WriteLine("Please enter valid number");
            }
            else
            {
                if (number > 99)
                {
                    Console.WriteLine("The number is: {0}{1}{2}", ProvideHundreds(number), ProvideTens(number), ProvideOnes(number));
                }
                else if (number > 20 && number < 100)
                {
                    Console.WriteLine("The number is:{0}{1}", ProvideTens(number), ProvideOnes(number));
                }
                else if (number < 20 && number != 0)
                {
                    Console.WriteLine("The number is:{0}", ProvideOnes(number));
                }
                else if (number == 0)
                {
                    Console.WriteLine("The number is: 0");
                }
            }
        }

        private static string ProvideOnes(int number)
        {
            string value;
            int valueAsNumber = number % 100;
            string andConnection = "";
            if (number > 20)
            {
                andConnection = " and ";
            }
            if (valueAsNumber < 10 || valueAsNumber > 20)
            {
                valueAsNumber = number % 10;
                switch (valueAsNumber)
                {
                    case 1: value = " one"; break;
                    case 2: value = " two"; break;
                    case 3: value = " three"; break;
                    case 4: value = " four"; break;
                    case 5: value = " five"; break;
                    case 6: value = " six"; break;
                    case 7: value = " seven"; break;
                    case 8: value = " eight"; break;
                    case 9: value = " nine"; break;
                    default: value = ""; break;
                }
                return value;
            }

            else
            {
                switch (valueAsNumber)
                {
                    case 10: value = andConnection + "ten"; break;
                    case 11: value = andConnection + "eleven"; break;
                    case 12: value = andConnection + "twelve"; break;
                    case 13: value = andConnection + "thirtheen"; break;
                    case 14: value = andConnection + "fourtheen"; break;
                    case 15: value = andConnection + "fiftheen"; break;
                    case 16: value = andConnection + "sixtheen"; break;
                    case 17: value = andConnection + "seventeen"; break;
                    case 18: value = andConnection + "eighteen"; break;
                    case 19: value = andConnection + "nineteen"; break;
                    default: value = ""; break;
                }
                return value;
            }
        }

        private static string ProvideTens(int number)
        {
            string value = "None";
            int result = number / 10;
            int valueAsNumber = result % 10;
            if (valueAsNumber == 0)
            {
                value = " and";
            }
            else
            {
                switch (valueAsNumber)
                {
                    case 2: value = " twenty"; break;
                    case 3: value = " thirthy"; break;
                    case 4: value = " forty"; break;
                    case 5: value = " fifty"; break;
                    case 6: value = " sixty"; break;
                    case 7: value = " seventhy"; break;
                    case 8: value = " eighty"; break;
                    case 9: value = " ninety"; break;
                    default: value = ""; break;
                }
            }
            return value;
        }

        private static string ProvideHundreds(int number)
        {
            string hundreds = "";
            int result = number / 100;
            switch (result)
            {
                case 1: hundreds = "One hundred"; break;
                case 2: hundreds = "Two hundred"; break;
                case 3: hundreds = "Three hundred"; break;
                case 4: hundreds = "Four hundred"; break;
                case 5: hundreds = "Five hundred"; break;
                case 6: hundreds = "Six hundred"; break;
                case 7: hundreds = "Seven hundred"; break;
                case 8: hundreds = "Eight hundred"; break;
                case 9: hundreds = "Nine hundred"; break;
                default: hundreds = ""; break;
            }
            return hundreds;
        }
    }
}
