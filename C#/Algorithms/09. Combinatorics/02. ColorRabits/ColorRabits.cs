using System;

class ColorRabits
{
    /*Logic info: 
     First we read the input from the console. After that we check each answer. If for example it is 2: 
     * we ignore the next 2 answers which have 2 for value as well
     * (assigning them value -1). Then we go again and just sum the answer + 1;
     */

    //BgCodder: 100/100

    static void Main(string[] args)
    {
        var numberOfRabbitsAsked = int.Parse(Console.ReadLine());
        int[] rabitAnswers = new int[numberOfRabbitsAsked];

        for (int i = 0; i < numberOfRabbitsAsked; i++)
        {
            rabitAnswers[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < rabitAnswers.Length; i++)
        {
            var currentNumberOfSameColor = rabitAnswers[i];
            var counter = 0;

            for (int j = i + 1; j < rabitAnswers.Length; j++)
            {
                if (counter == currentNumberOfSameColor)
                {
                    break;
                }

                if (rabitAnswers[j] == currentNumberOfSameColor)
                {
                    rabitAnswers[j] = -1;
                    counter++;
                }
            }
        }

        var minNumberOfRabits = 0;

        for (int i = 0; i < rabitAnswers.Length; i++)
        {
            if (rabitAnswers[i] >= 0)
            {
                minNumberOfRabits += rabitAnswers[i] + 1;
            }
        }

        Console.WriteLine(minNumberOfRabits);
    }
}
