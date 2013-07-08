using System;

class BitPasswords
{
    //No need to calculate every variation. The formula 2^n will do the trick.

    //BgCodder: 100/100

    static void Main(string[] args)
    {
        var password = Console.ReadLine();
        var occurence = 0;
        for (int i = 0; i < password.Length; i++)
        {
            if (password[i] == '*')
            {
                occurence++;
            }
        }

        int result = 1;

        for (int i = 0; i < occurence; i++)
        {
            result *= 2;
        }
        Console.WriteLine(result);
    }
}

