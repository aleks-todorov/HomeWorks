using System;
using System.Threading;

class Program
{
    static void Main()
    {
        string[,] topPivotChar = new string[6, 3];//The pivot above the legs
        string[,] downPivotChar = new string[3, 3];//The legs of the pivot
        string[] colors = new string[8] { "Green", "Blue", "Yellow", "Magenta", "Gray", "Cyan", "Red", "White", };

        while (true)
        {
            //Generating positions
            Random twoHands = new Random();
            int gettingRandomNumberForTwoHands = twoHands.Next(0, 5);
            Random twoLegs = new Random();
            int gettingRandomNumberForTwoLegs = twoLegs.Next(0, 4);
            Random color = new Random();//Gettig random number which I will use as an indexer at the array of colors
            int number = color.Next(0, 9);

            //Moving the two hands

            if (gettingRandomNumberForTwoHands == 0)
            {
                topPivotChar = new string[6, 3]
                        {
                            { " -", "-", "-" },
                            { "|", "*.*", "|" },
                            { " -", "-", "-" },
                            { " \\", "|", "/" },
                            { "  ", "|", " " },
                            { "  ", "|", " " },
                        };
            }
            if (gettingRandomNumberForTwoHands == 1)
            {
                topPivotChar = new string[6, 3]
                        {
                            { " -", "-", "-" },
                            { "|", "*.*", "|" },
                            { " -", "-", "-" },
                            { "--", "|", "--" },
                            { "  ", "|", " " },
                            { "  ", "|", " " },
                        };
            }
            if (gettingRandomNumberForTwoHands == 2)
            {
                topPivotChar = new string[6, 3]
                        {
                            { " -", "-", "-" },
                            { "|", "*.*", "|" },
                            { " -", "-", "-" },
                            { " /", "|", "\\" },
                            { "  ", "|", " " },
                            { "  ", "|", " " },
                        };
            }
            if (gettingRandomNumberForTwoHands == 3)
            {
                topPivotChar = new string[6, 3]
                        {
                            { " -", "-", "-" },
                            { "|", "*.*", "|" },
                            { " -", "-", "-" },
                            { " \\", "|", "--" },
                            { "  ", "|", " " },
                            { "  ", "|", " " },
                        };
            }
            if (gettingRandomNumberForTwoHands == 4)
            {

                topPivotChar = new string[6, 3]
                        {
                            { " -", "-", "-" },
                            { "|", "*.*", "|" },
                            { " -", "-", "-" },
                            { "--", "|", "/" },
                            { "  ", "|", " " },
                            { "  ", "|", " " },
                        };
            }

            //Moving the two legs
            if (gettingRandomNumberForTwoLegs == 0)
            {
                downPivotChar = new string[3, 3]
                        {
                            { " -", "-", "-" },
                            { " | ", "", "|" },
                            { " |",  " ", "|" },
                        };
            }
            if (gettingRandomNumberForTwoLegs == 1)
            {
                downPivotChar = new string[3, 3]
                        {
                            { " -", "-", " " },
                            { " |", " ", "\\" },
                            { " |", " ", " \\" },
                        };
            }
            if (gettingRandomNumberForTwoLegs == 2)
            {
                downPivotChar = new string[3, 3]
                        {
                            { " ", " -", "-" },
                            { " /", "", " |" },
                            { "/  ", "", "|" },
                        };
            }
            if (gettingRandomNumberForTwoLegs == 3)
            {
                downPivotChar = new string[3, 3]
                        {
                            { "  ", "- ", " " },
                            { " /", " ", "\\" },
                            { "/  ", " ", "\\" },
                        };
            }

            //Printing the pivot
            for (int row = 0; row < 16; row++)
            {
                if (row < 10)
                {
                    Console.SetCursorPosition(row, 15);
                }
                else
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (number == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        if (number == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        if (number == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        if (number == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        if (number == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        if (number == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        if (number == 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        if (number == 7)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        if (number == 8)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                        }
                        Console.Write(topPivotChar[row % 10, col]);
                    }
                }
                Console.WriteLine();
            }

            for (int rows = 0; rows < 3; rows++)
            {
                for (int cols = 0; cols < 3; cols++)
                {
                    Console.Write(downPivotChar[rows, cols]);
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.DarkRed;

            Thread.Sleep(500);
            Console.Clear();
        }
    }
}

