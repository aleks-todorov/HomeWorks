static class PerformDivision
{
    public static void OfInts(int startValue, int endValue)
    {
        for (int i = startValue; i >= endValue; )
        {
            i = i / 2;
        }
    }

    public static void OfLongs(long startValue, long endValue)
    {
        for (long i = startValue; i >= endValue; )
        {
            i = i / 2;
        }
    }

    public static void OfFloats(float startValue, float endValue)
    {
        for (float i = startValue; i >= endValue; )
        {
            i = i / 2;
        }
    }

    public static void OfDoubles(double startValue, double endValue)
    {
        for (double i = startValue; i >= endValue; )
        {
            i = i / 2;
        }
    }

    public static void OfDecimals(decimal startValue, decimal endValue)
    {
        for (decimal i = startValue; i >= endValue; )
        {
            i = i / 2;
        }
    }
}
