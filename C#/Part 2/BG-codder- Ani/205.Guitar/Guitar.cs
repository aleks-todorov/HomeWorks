using System;

//100/100
class Guitar
{
    static void Main()
    {
        string line = Console.ReadLine();
        string[] lineSplit = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int c = lineSplit.Length;
        int[] volumeChanges = new int[c];
        for (int i = 0; i < c; i++)
        {
            volumeChanges[i] = Int32.Parse(lineSplit[i]);
        }
        int b = Int32.Parse(Console.ReadLine());
        int m = Int32.Parse(Console.ReadLine());

        int[,] dynamicMatrix = new int[c + 1, m + 1];
        dynamicMatrix[0, b] = 1;

        for (int u = 0; u < c; u++)
        {
            for (int i = 0; i <= m; i++)
            {
                if (dynamicMatrix[u, i] == 1)
                {
                    if (i + volumeChanges[u] <= m)
                    {
                        dynamicMatrix[u + 1, i + volumeChanges[u]] = 1;
                    }
                    if (i - volumeChanges[u] >= 0)
                    {
                        dynamicMatrix[u + 1, i - volumeChanges[u]] = 1;
                    }
                }
            }
        }

        int bestVolume = -1;
        for (int i = m; i >= 0; i--)
        {
            if (dynamicMatrix[c, i] == 1)
            {
                bestVolume = i;
                break;
            }
        }
        Console.WriteLine(bestVolume);
    }
}