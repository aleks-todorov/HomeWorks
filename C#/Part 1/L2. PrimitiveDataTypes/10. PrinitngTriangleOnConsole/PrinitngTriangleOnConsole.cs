using System;

namespace _10.PrinitngTriangleOnConsole
{
    class PrinitngTriangleOnConsole
    {
        static void Main()
        {
            //In order to use create the tree with only 9 symbols, the height should be 3
            Console.WriteLine("Please enter the height of the triangle");
            int height = int.Parse(Console.ReadLine());
            Console.Clear();
            //Depending on the screen size and rezolution the height might be different. 39 is optimal for my laptop
            if (height > 0 && height <= 39)
            {
                string symbol = new string('\u00A9', 1);
                string space = new string(' ', 1);
                for (int i = 0; i < height; i++)
                {
                    symbol = new string('\u00A9', (i * 2) + 1);
                    space = new string(' ', (height - i));
                    Console.Write(space);
                    Console.Write(symbol);
                    Console.Write(space);
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Please enter height between 0 and 39");
                Main(); 
            }
        }
    }
}
