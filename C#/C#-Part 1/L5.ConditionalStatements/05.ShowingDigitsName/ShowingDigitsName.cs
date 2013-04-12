using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ShowingDigitsName
{
    class ShowingDigitsName
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
           
                switch (number)
                {
                    case 1: Console.WriteLine("One"); break;
                    case 2: Console.WriteLine("Two"); break;
                    case 3: Console.WriteLine("Three"); break;
                    case 4: Console.WriteLine("Four"); break;
                    case 5: Console.WriteLine("Five"); break;
                    case 6: Console.WriteLine("Six"); break;
                    case 7: Console.WriteLine("Seven"); break;
                    case 8: Console.WriteLine("Eight"); break;
                    case 9: Console.WriteLine("Nine"); break;
                    default: Console.WriteLine("Please enter number between 1 and 9"); break;
                }
            }
    }
}

