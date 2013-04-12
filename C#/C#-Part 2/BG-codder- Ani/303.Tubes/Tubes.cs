using System;

//100/100
class Tubes
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        int m = Int32.Parse(Console.ReadLine());
        long[] tubesLengths = new long[n];
        for (int i = 0; i < n; i++)
        {
            tubesLengths[i] = Int64.Parse(Console.ReadLine());
        }

        long maxsize = 0;
        foreach (long tubeLength in tubesLengths)
        {
            maxsize += tubeLength;
        }
        if (maxsize < m)
        {
            Console.WriteLine(-1);
            return;
        }
        if (CheckIfDivisionIsPossible(ref tubesLengths, m, maxsize))
        {
            Console.WriteLine(maxsize);
            return;
        }

        long minsize = 1;

        long median;
        do
        {
            median = (minsize + maxsize) / 2 + 1;
            if (CheckIfDivisionIsPossible(ref tubesLengths, m, median))
            {
                minsize = median;
            }
            else
            {
                maxsize = median - 1;
            }
        }
        while (minsize != maxsize);

        Console.Write(maxsize);
    }

    static bool CheckIfDivisionIsPossible(ref long[] tubesLengths, int m, long sizeToTest)
    {
        long totalTubesAfterCut = 0;

        foreach (long tubeLength in tubesLengths)
        {
            totalTubesAfterCut += tubeLength / sizeToTest;
        }

        if (totalTubesAfterCut < m)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}