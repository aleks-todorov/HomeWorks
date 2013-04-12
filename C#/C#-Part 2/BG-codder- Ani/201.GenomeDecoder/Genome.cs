using System;
using System.Text;

//100/100
class Genome
{
    static void Main(string[] args)
    {
        string inputLine = Console.ReadLine();
        string[] splitInput = inputLine.Split();
        int n = Int32.Parse(splitInput[0]);
        int m = Int32.Parse(splitInput[1]);
        string encodedGenome = Console.ReadLine();

        StringBuilder numberBuilder = new StringBuilder();
        int number;
        StringBuilder decodedGenomeBuilder = new StringBuilder();
        for (int i = 0; i < encodedGenome.Length; i++)
        {
            if (Char.IsNumber(encodedGenome[i]))
            {
                numberBuilder.Append(encodedGenome[i]);
            }
            else if (Char.IsLetter(encodedGenome[i]) && (i == 0 || Char.IsLetter(encodedGenome[i - 1])))
            {
                decodedGenomeBuilder.Append(encodedGenome[i]);
            }
            else //if (Char.IsLetter(encodedGenome[i]) && Char.IsNumber(encodedGenome[i - 1]))
            {
                number = Int32.Parse(numberBuilder.ToString());
                decodedGenomeBuilder.Append(new string(encodedGenome[i], number));
                numberBuilder.Clear();
            }
        }

        string decodedGenome = decodedGenomeBuilder.ToString();
        int numberOfLines = (int)Math.Ceiling((decimal)decodedGenome.Length / n);
        int numberPadding = numberOfLines.ToString().Length;

        StringBuilder formattedGenomeBuilder = new StringBuilder();
        formattedGenomeBuilder.Append(1.ToString().PadLeft(numberPadding, ' '));
        formattedGenomeBuilder.Append(" ");
        int lineCount = 2;
        for (int i = 1, sectionCount = 1; i <= decodedGenome.Length; i++, sectionCount++)
        {
            formattedGenomeBuilder.Append(decodedGenome[i - 1]);
            if (i % n == 0 && i != decodedGenome.Length)
            {
                formattedGenomeBuilder.AppendLine();
                formattedGenomeBuilder.Append(lineCount.ToString().PadLeft(numberPadding, ' '));
                formattedGenomeBuilder.Append(" ");
                lineCount++;
                sectionCount = 0;
            }
            if (sectionCount % m == 0 && sectionCount != 0)
            {
                formattedGenomeBuilder.Append(' ');
            }
        }

        Console.WriteLine(formattedGenomeBuilder.ToString().TrimEnd());
    }
}