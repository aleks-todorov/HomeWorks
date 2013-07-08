using System;
using System.Collections.Generic;
using System.Linq;

class Divider
{ 
     //BgCodder: 100/100

    static List<int> numbers = new List<int>();
    static int[] possibleNumbers;
    static int minDivider = int.MaxValue;

    static void Main(string[] args)
    {
        var N = int.Parse(Console.ReadLine());
        possibleNumbers = new int[N];
        var number = new int[N];

        for (int i = 0; i < N; i++)
        {
            possibleNumbers[i] = int.Parse(Console.ReadLine());
        }

        //Creating all possible combinations(without repetition) of numbers 

        GenerateNumbers(0, number);

        //Finding number of Dividers for each number
        SortedDictionary<int, SortedSet<int>> numberOfDividers = new SortedDictionary<int, SortedSet<int>>();

        foreach (var num in numbers)
        {
            var dividers = 0;

            //There must be easier way to find out the number of dividers(not only simple), but for the moment this is the only way I can tink of. 
            for (int i = 1; i < num; i++)
            {
                if (num % i == 0)
                {
                    dividers++;

                    //making small optimization, in order ot avoid 3 timeLimits
                    if (dividers > minDivider)
                    {
                        break;
                    }
                }
            }

            if (dividers < minDivider)
            {
                minDivider = dividers;
            }

            if (numberOfDividers.ContainsKey(dividers))
            {
                numberOfDividers[dividers].Add(num);
            }
            else
            {
                var sortedSet = new SortedSet<int>();
                sortedSet.Add(num);
                numberOfDividers.Add(dividers, sortedSet);
            }
        }

        var result = numberOfDividers.First();

        Console.WriteLine(result.Value.First());
    }

    private static void GenerateNumbers(int possition, int[] number)
    {
        if (possition >= possibleNumbers.Length)
        {
            ParseNumber(number);
            return;
        }

        GenerateNumbers(possition + 1, possibleNumbers);
        for (int i = possition + 1; i < possibleNumbers.Length; i++)
        {
            Swap(ref possibleNumbers[possition], ref possibleNumbers[i]);
            GenerateNumbers(possition + 1, possibleNumbers);
            Swap(ref possibleNumbers[possition], ref possibleNumbers[i]);
        }
    }

    static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }

    private static void ParseNumber(int[] number)
    {
        var numberAsString = string.Empty;

        for (int i = 0; i < number.Length; i++)
        {
            numberAsString += number[i];
        }

        numbers.Add(int.Parse(numberAsString));
    }
}

