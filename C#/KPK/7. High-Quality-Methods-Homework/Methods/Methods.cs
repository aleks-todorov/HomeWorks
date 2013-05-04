using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Sides should be possitive. Please enter new ones");
            }
            double halfPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
            return area;
        }

        static string ConvertNumberToWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid number!");
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Provided number array is not valid. Please check!");
            }

            var maxValue = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxValue)
                {
                    maxValue = elements[i];
                }
            }
            return maxValue;
        }

        public static void PrintAsFloatNumber(decimal number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintAsPercent(decimal number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintRightAlignedNumber(decimal number)
        {
            Console.WriteLine("{0,8}", number);
        }

        public static bool CheckIfLineIsHorizontal(double x1, double x2)
        {
            bool isHorizontal = (x1 == x2);
            return isHorizontal;
        }

        public static bool CheckifLineIsVertical(double y1, double y2)
        {
            bool isVertical = (y1 == y2);
            return isVertical;
        }

        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static void Main()
        {

            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            Console.WriteLine(ConvertNumberToWord(5));
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsFloatNumber(1.3m);
            PrintAsPercent(0.75m);
            PrintRightAlignedNumber(2.30m);

            bool horizontal = CheckIfLineIsHorizontal(3, 3);
            bool vertical = CheckifLineIsVertical(-1, 2.5);
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            var peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 25), "From Sofia");

            var stella = new Student("Stella", "Markova", new DateTime(1993, 3, 11), "From Vidin, gamer, high results");

            Console.WriteLine("{0} is older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
