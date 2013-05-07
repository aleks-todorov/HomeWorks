using System;

namespace _3.ComparePerformanceOfComplicatedMathOperations
{
    static class CalculateLog
    {
        public static void ForFloats(float startValue, float endValue)
        {
            for (float i = startValue; i <= endValue; i++)
            {
                Math.Log(i);
            }
        }

        public static void ForDoubles(double startValue, double endValue)
        {
            for (double i = startValue; i <= endValue; i++)
            {
                Math.Log(i);
            }
        }

        public static void ForDecimals(decimal startValue, decimal endValue)
        {
            for (decimal i = startValue; i <= endValue; i++)
            {
                Math.Log((double)i);
            }
        }
    }
}
