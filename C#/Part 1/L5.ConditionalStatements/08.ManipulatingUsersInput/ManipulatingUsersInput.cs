using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ManipulatingUsersInput
{
    class ManipulatingUsersInput
    {
        static void Main(string[] args)
        {
            //Write a program that, depending on the user's choice inputs int, double or string variable.
            //If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its 
            //end. The program must show the value of that variable as a console output. Use switch statement.
            Console.WriteLine("For Integer Please enter 1");
            Console.WriteLine("For Double Please enter 2");
            Console.WriteLine("For String Please enter 3");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your input here: ");
            string usersInput = Console.ReadLine(); 
            int intNumber;
            double doubleNumber;
                                
            switch (input)
            {
                case 1:
                    {
                        if (int.TryParse(usersInput, out intNumber))
                        {
                            Console.WriteLine("Input is Int and value is: {0}", intNumber + 1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter proper int value");
                            break; 
                        }
                    }
                case 2:
                    {
                        if (double.TryParse(usersInput, out doubleNumber))
                        {
                            Console.WriteLine("Input is Double and value is: {0}", doubleNumber + 1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter proper double value");
                            break;
                        }
                    }
                case 3:
                    {
                        Console.WriteLine("Input is String and value is: {0}", usersInput + "*");
                        break;
                    }
        }
    
    }
    }
}