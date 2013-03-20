using System;

//90/100
class AcademyTasks
{
    static void Main()
    {
        string line = Console.ReadLine();
        string[] lineSplit = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int[] pleasantness = new int[lineSplit.Length];

        for (int i = 0; i < pleasantness.Length; i++)
        {
            pleasantness[i] = Int32.Parse(lineSplit[i]);

        }

        int variety = Int32.Parse(Console.ReadLine());

        int minElement = pleasantness[0];
        int earliestMinIndexEnd = pleasantness.Length - 1;
        int earliestMinIndexStart = 0;
        bool varietyReachedWithMin = false;
        for (int i = 0; i < pleasantness.Length; i++)
        {
            if (pleasantness[i] < minElement)
            {
                minElement = pleasantness[i];
                earliestMinIndexStart = i;
            }
            else if (pleasantness[i] >= minElement + variety)
            {
                earliestMinIndexEnd = i;
                varietyReachedWithMin = true;
                break;
            }
        }

        int maxElement = pleasantness[0];
        int earliestMaxIndexEnd = pleasantness.Length - 1;
        int earliestMaxIndexStart = 0;
        bool varietyReachedWithMax = false;
        for (int i = 0; i < pleasantness.Length; i++)
        {
            if (pleasantness[i] > maxElement)
            {
                maxElement = pleasantness[i];
                earliestMaxIndexStart = i;
            }
            else if (pleasantness[i] <= maxElement - variety)
            {
                earliestMaxIndexEnd = i;
                varietyReachedWithMax = true;
                break;
            }
        }

        int countTasks = 0;
        int earliestIndexEnd = 0;
        int earliestIndexStart = 0;

        if (varietyReachedWithMin && varietyReachedWithMax)
        {
            if (earliestMaxIndexEnd < earliestMinIndexEnd)
            {
                earliestIndexEnd = earliestMaxIndexEnd;
                earliestIndexStart = earliestMaxIndexStart;
            }
            else
            {
                earliestIndexEnd = earliestMinIndexEnd;
                earliestIndexStart = earliestMinIndexStart;
            }
        }
        else if (varietyReachedWithMin)
        {
            earliestIndexEnd = earliestMinIndexEnd;
            earliestIndexStart = earliestMinIndexStart;
        }
        else if (varietyReachedWithMax)
        {
            earliestIndexEnd = earliestMaxIndexEnd;
            earliestIndexStart = earliestMaxIndexStart;
        }

        if (!varietyReachedWithMin && !varietyReachedWithMax)
        {
            countTasks = pleasantness.Length;
        }
        else
        {
            countTasks += ((earliestIndexStart + 1) / 2) + 1;
            countTasks += (earliestIndexEnd - earliestIndexStart + 1) / 2;
        }

        Console.WriteLine(countTasks);
    }
}