using System;
using System.Diagnostics;

namespace _3.ComparePerformanceOfComplicatedMathOperations
{
    class Application
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            CalculateSQRT.OfFloats(2f, 500000f);
            timer.Stop();
            PrintResult("SQRT", "Floats", timer.Elapsed);
            timer.Reset();
            timer.Start();
            CalculateSQRT.OfDoubles(2d, 500000d);
            timer.Stop();
            PrintResult("SQRT", "Doubles", timer.Elapsed);
            timer.Reset();
            timer.Start();
            CalculateSQRT.OfDecimals(2m, 500000m);
            timer.Stop();
            PrintResult("SQRT", "Decimals", timer.Elapsed);

            Console.WriteLine();

            timer.Reset();
            timer.Start();
            CalculateLog.ForFloats(2f, 500000f);
            timer.Stop();
            PrintResult("Log", "Floats", timer.Elapsed);
            timer.Reset();
            timer.Start();
            CalculateLog.ForDoubles(2d, 500000d);
            timer.Stop();
            PrintResult("Log", "Doubles", timer.Elapsed);
            timer.Reset();
            timer.Start();
            CalculateLog.ForDecimals(2m, 500000m);
            timer.Stop();
            PrintResult("Log", "Decimals", timer.Elapsed);

            Console.WriteLine();

            timer.Reset();
            timer.Start();
            CalculateSin.OfFloats(2f, 500000f);
            timer.Stop();
            PrintResult("Sin", "Floats", timer.Elapsed);
            timer.Start();
            CalculateSin.OfDoubles(2d, 500000d);
            timer.Stop();
            PrintResult("Sin", "Doubles", timer.Elapsed);
            timer.Reset();
            timer.Start();
            CalculateSin.OfDecimals(2m, 500000m);
            timer.Stop();
            PrintResult("Sin", "Decimals", timer.Elapsed);
            //See also screenshot with the results from JustTrace in the solution file
        }

        private static void PrintResult(string operation, string typeOfData, TimeSpan timer)
        {
            Console.WriteLine("Time required for performing of {0} for {1} is: {2}", operation, typeOfData, timer);
        }
    }
}
