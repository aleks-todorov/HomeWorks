using System;
using System.Diagnostics;

namespace _2.ComparePerformanceOfSimpleMathOperations
{
    class Application
    {
        static void Main(string[] args)
        {
            //Intentionally I did not separated the repeating code (timer.Reset, timer.Start, timer.Stop, because I did not wanted to add to the final result the time for invoking the function.
            var timer = new Stopwatch();

            timer.Start();
            PerformAddition.OfInts(1, 6000000);
            timer.Stop();
            PrintResult("Addition", "Ints", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformAddition.OfLongs(1L, 6000000L);
            timer.Stop();
            PrintResult("Addition", "Longs", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformAddition.OfFloats(1.01f, 6000000f);
            timer.Stop();
            PrintResult("Addition", "Floats", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformAddition.OfDoubles(1.01d, 6000000d);
            timer.Stop();
            PrintResult("Addition", "Doubles", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformAddition.OfDecimals(1.01m, 6000000m);
            timer.Stop();
            PrintResult("Addition", "Decimals", timer.Elapsed);
            Console.WriteLine();

            timer.Reset();
            timer.Start();
            PerformSubstraction.OfInts(6000000, 1);
            timer.Stop();
            PrintResult("Substraction", "Ints", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformSubstraction.OfLongs(6000000L, 1L);
            timer.Stop();
            PrintResult("Substraction", "Longs", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformSubstraction.OfFloats(6000000f, 1.01f);
            timer.Stop();
            PrintResult("Substraction", "Floats", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformSubstraction.OfDoubles(6000000d, 1.01d);
            timer.Stop();
            PrintResult("Substraction", "Doubles", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformSubstraction.OfDecimals(6000000m, 1.01m);
            timer.Stop();
            PrintResult("Substraction", "Decimals", timer.Elapsed);
            Console.WriteLine();

            timer.Reset();
            timer.Start();
            PerformMultiplication.OfInts(1, 6000000);
            timer.Stop();
            PrintResult("Multiplication", "Ints", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformMultiplication.OfLongs(1L, 6000000L);
            timer.Stop();
            PrintResult("Multiplication", "Longs", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformMultiplication.OfFloats(1.01f, 6000000f);
            timer.Stop();
            PrintResult("Multiplication", "Floats", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformMultiplication.OfDoubles(1.01d, 6000000d);
            timer.Stop();
            PrintResult("Multiplication", "Doubles", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformMultiplication.OfDecimals(1.01m, 6000000m);
            timer.Stop();
            PrintResult("Multiplication", "Decimals", timer.Elapsed);
            Console.WriteLine();

            timer.Reset();
            timer.Start();
            PerformDivision.OfInts(6000000, 1);
            timer.Stop();
            PrintResult("Division", "Ints", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformDivision.OfLongs(6000000L, 1L);
            timer.Stop();
            PrintResult("Division", "Longs", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformDivision.OfFloats(6000000f, 1.01f);
            timer.Stop();
            PrintResult("Division", "Floats", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformDivision.OfDoubles(6000000d, 1.01d);
            timer.Stop();
            PrintResult("Division", "Doubles", timer.Elapsed);
            timer.Reset();
            timer.Start();
            PerformDivision.OfDecimals(6000000m, 1.01m);
            timer.Stop();
            PrintResult("Division", "Decimals", timer.Elapsed);
            //See also screenshot with the results from JustTrace in the solution file
        }

        private static void PrintResult(string operation, string typeOfData, TimeSpan timer)
        {
            Console.WriteLine("Time required for performing of {0} for {1} is: {2}", operation, typeOfData, timer);
        }
    }
}
