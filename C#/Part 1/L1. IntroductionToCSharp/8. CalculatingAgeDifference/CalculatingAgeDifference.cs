using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatingAgeDifference
{
    class CalculatingAgeDifference
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Your are after 10 years will be: " + (age + 10)); 
        }
    }
}
