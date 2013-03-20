using System;

//100/100
class ThreeDSlices
{
    static void Main(string[] args)
    {
        string input1 = Console.ReadLine();
        string[] splitInput = input1.Split();
        int w = Int32.Parse(splitInput[0]);
        int h = Int32.Parse(splitInput[1]);
        int d = Int32.Parse(splitInput[2]);
        int[, ,] cube = new int[w, h, d];

        for (int u = 0; u < h; u++)
        {
            string[] splitInput2 = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.None);
            for (int o = 0; o < d; o++)
            {
                string[] splitInput3 = splitInput2[o].Split();
                for (int i = 0; i < w; i++)
                {
                    cube[i, u, o] = Int32.Parse(splitInput3[i]);
                }
            }
        }

        if (w == 1 && h == 1 & d == 1)
        {
            Console.WriteLine(0);
            return;
        }

        int result = 0;

        //cut in depth;
        int firstHalf = 0;
        for (int o = 0; o < 1; o++)
        {
            for (int i = 0; i < w; i++)
            {
                for (int u = 0; u < h; u++)
                {
                    firstHalf += cube[i, u, o];
                }
            }
        }

        int secondHalf = 0;
        for (int o = 1; o < d; o++)
        {
            for (int i = 0; i < w; i++)
            {
                for (int u = 0; u < h; u++)
                {
                    secondHalf += cube[i, u, o];
                }
            }
        }

        if (firstHalf == secondHalf)
        {
            result++;
        }

        for (int cut = 1; cut < d - 1; cut++)
        {
            int currentCut = 0;
            for (int i = 0; i < w; i++)
            {
                for (int u = 0; u < h; u++)
                {
                    currentCut += cube[i, u, cut];
                }
            }

            firstHalf += currentCut;
            secondHalf -= currentCut;

            if (firstHalf == secondHalf)
            {
                result++;
            }
        }

        //cut according to width
        firstHalf = 0;
        for (int i = 0; i < 1; i++)
        {
            for (int o = 0; o < d; o++)
            {
                for (int u = 0; u < h; u++)
                {
                    firstHalf += cube[i, u, o];
                }
            }
        }

        secondHalf = 0;
        for (int i = 1; i < w; i++)
        {
            for (int o = 0; o < d; o++)
            {
                for (int u = 0; u < h; u++)
                {
                    secondHalf += cube[i, u, o];
                }
            }
        }

        if (firstHalf == secondHalf)
        {
            result++;
        }

        for (int cut = 1; cut < w - 1; cut++)
        {
            int currentCut = 0;

            for (int o = 0; o < d; o++)
            {
                for (int u = 0; u < h; u++)
                {
                    currentCut += cube[cut, u, o];
                }
            }

            firstHalf += currentCut;
            secondHalf -= currentCut;

            if (firstHalf == secondHalf)
            {
                result++;
            }
        }

        //cut in height
        firstHalf = 0;
        for (int u = 0; u < 1; u++)
        {
            for (int o = 0; o < d; o++)
            {
                for (int i = 0; i < w; i++)
                {
                    firstHalf += cube[i, u, o];
                }
            }
        }

        secondHalf = 0;
        for (int u = 1; u < h; u++)
        {
            for (int o = 0; o < d; o++)
            {
                for (int i = 0; i < w; i++)
                {
                    secondHalf += cube[i, u, o];
                }
            }
        }

        if (firstHalf == secondHalf)
        {
            result++;
        }

        for (int cut = 1; cut < h - 1; cut++)
        {
            int currentCut = 0;

            for (int o = 0; o < d; o++)
            {
                for (int i = 0; i < w; i++)
                {
                    currentCut += cube[i, cut, o];
                }
            }

            firstHalf += currentCut;
            secondHalf -= currentCut;

            if (firstHalf == secondHalf)
            {
                result++;
            }
        }

        Console.WriteLine(result);
    }
}