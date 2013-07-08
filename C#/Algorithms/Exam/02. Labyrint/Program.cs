using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Player
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public Player(int x, int y, int z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }
}

class Program
{
    static List<char[,]> gameField = new List<char[,]>();
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var x = int.Parse(input[0]);
        var y = int.Parse(input[1]);
        var z = int.Parse(input[2]);

        var player = new player(x, y, z);
        input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var floors = int.Parse(input[0]);
        var col = int.Parse(input[1]);
        var row = int.Parse(input[2]);

        for (int f = 0; f < floors; f++)
        {
            var gameFloor = new char[row, col];

            for (int i = 0; i < row; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < col; j++)
                {
                    gameFloor[row, col] = line[j];
                }
            }

            gameField.Add(gameFloor);
        }
        Console.WriteLine();
    }
}

