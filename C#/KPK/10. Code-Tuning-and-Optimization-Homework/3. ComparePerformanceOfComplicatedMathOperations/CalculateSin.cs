using System;

namespace _3.ComparePerformanceOfComplicatedMathOperations
{
    class CalculateSin
    {
        public static void OfFloats(float startValue, float endValue)
        {
            for (float i = startValue; i <= endValue; i++)
            {
                Math.Sin(i);
            }
        }

        public static void OfDoubles(double startValue, double endValue)
        {
            for (double i = startValue; i <= endValue; i++)
            {
                Math.Sin(i);
            }
        }

        public static void OfDecimals(decimal startValue, decimal endValue)
        {
            for (decimal i = startValue; i <= endValue; i++)
            {
                Math.Sin((double)i);
            }
        }
    }
}
