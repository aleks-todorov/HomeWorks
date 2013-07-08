using System;
using System.Collections.Generic;
using System.Text;

class MessageInABottle
{
    static List<KeyValuePair<char, string>> ciphers = new List<KeyValuePair<char, string>>();
    static string message;

    static void Main(string[] args)
    {
        message = Console.ReadLine();
        string cipher = Console.ReadLine();

        char key = char.MinValue;
        var value = new StringBuilder();
        for (int i = 0; i < cipher.Length; i++)
        {
            if (cipher[i] >= 'A' && cipher[i] <= 'Z')
            {
                if (key != char.MinValue)
                {
                    ciphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                    value.Clear();
                }
                key = cipher[i];
            }
            else
            {
                value.Append(cipher[i]);
            }
        }

        if (key != char.MinValue)
        {
            ciphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
            value.Clear();
        }

        var sb = new StringBuilder();
        Solve(0, sb);

        Console.WriteLine(solution.Count);
        solution.Sort();

        foreach (var item in solution)
        {
            Console.WriteLine(item);
        }
    }

    static List<string> solution = new List<string>();

    static void Solve(int index, StringBuilder sb)
    {
        if (index == message.Length)
        {
            solution.Add(sb.ToString());

            return;
        }


        foreach (var cipher in ciphers)
        {

            if (message.Substring(index).StartsWith(cipher.Value))
            {
                sb.Append(cipher.Key);
                Solve(index + cipher.Value.Length, sb);
                sb.Length--;
            }
        }
    }
}

