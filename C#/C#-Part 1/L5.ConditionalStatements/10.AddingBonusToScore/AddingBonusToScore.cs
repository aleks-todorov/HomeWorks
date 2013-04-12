using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.AddingBonusToScore
{
    class AddingBonusToScore
    {
        static void Main()
        {
            string numberAsText = Console.ReadLine();
            int score;
            bool parser =  int.TryParse(numberAsText, out score);
            switch (score)
            {
                case 1: score = score * 10; Console.WriteLine(score); break;
                case 2: score = score * 10; Console.WriteLine(score); break;
                case 3: score = score * 10; Console.WriteLine(score); break;
                case 4: score = score * 100; Console.WriteLine(score); break;
                case 5: score = score * 100; Console.WriteLine(score); break;
                case 6: score = score * 100; Console.WriteLine(score); break;
                case 7: score = score * 1000; Console.WriteLine(score); break;
                case 8: score = score * 1000; Console.WriteLine(score); break;
                case 9: score = score * 1000; Console.WriteLine(score); break;
                default: Console.WriteLine("Please provide valid number !"); break; 
            }

        }
    }
}
