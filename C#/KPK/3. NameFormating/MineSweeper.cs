namespace MineSweeper
{
    using System;
    using System.Collections.Generic;
    using Minesweeper;

    public class MineSweeper
    {
        static void Main(string[] args)
        {
            const int MAX = 35;
            string command = string.Empty;
            char[,] field = CreateGameField();
            char[,] bombs = PlaceBombs();
            int counter = 0;
            bool hasExploded = false;
            List<Point> champions = new List<Point>(6);
            int row = 0;
            int col = 0;
            bool isNewGame = true;
            bool hasWon = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Let's play \"MineSweeper\".Test your skills in finding all fiels without mines. ");
                    Console.WriteLine("'Top' command shows ranking, 'restart' starts a new game, 'exit' ends game.");
                    PrintingFieldFrame(field);
                    isNewGame = false;
                }

                Console.Write("Please enter row and col: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Ranking(champions);
                        break;
                    case "restart":
                        field = CreateGameField();
                        bombs = PlaceBombs();
                        PrintingFieldFrame(field);
                        hasExploded = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                PlayersMove(field, bombs, row, col);
                                counter++;
                            }
                            if (MAX == counter)
                            {
                                hasWon = true;
                            }
                            else
                            {
                                PrintingFieldFrame(field);
                            }
                        }
                        else
                        {
                            hasExploded = true;
                        }
                        break;
                    default:
                        Console.WriteLine("Error! Wrong command ");
                        break;
                }

                if (hasExploded)
                {
                    PrintingFieldFrame(bombs);
                    Console.WriteLine(" You died like a hero, with {0} points. Please enter your nickname: ", counter);
                    string nickName = Console.ReadLine();
                    Point point = new Point(nickName, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(point);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < point.Points)
                            {
                                champions.Insert(i, point);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Point resultOne, Point resultTwo) => resultTwo.Name.CompareTo(resultOne.Name));
                    champions.Sort((Point resultOne, Point resultTwo) => resultTwo.Points.CompareTo(resultOne.Points));
                    Ranking(champions);
                    field = CreateGameField();
                    bombs = PlaceBombs();
                    counter = 0;
                    hasExploded = false;
                    isNewGame = true;
                }

                if (hasWon)
                {
                    Console.WriteLine("Congratz!!! You have opened 35 fields! ");
                    PrintingFieldFrame(bombs);
                    Console.WriteLine("Please provide nickname: ");
                    string name = Console.ReadLine();
                    Point points = new Point(name, counter);
                    champions.Add(points);
                    Ranking(champions);
                    field = CreateGameField();
                    bombs = PlaceBombs();
                    counter = 0;
                    hasWon = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.Read();
        }

        private static void Ranking(List<Point> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, points[i].Name, points[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty score!\n");
            }
        }

        private static void PlayersMove(char[,] gameField, char[,] bombsArr, int boardRow, int boardCol)
        {
            char numberOfBombs = CalculatingBombsLeft(bombsArr, boardRow, boardCol);
            bombsArr[boardRow, boardCol] = numberOfBombs;
            gameField[boardRow, boardCol] = numberOfBombs;
        }

        private static void PrintingFieldFrame(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardColls = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < boardColls; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] gameField = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> bombMap = new List<int>();
            while (bombMap.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!bombMap.Contains(randomNumber))
                {
                    bombMap.Add(randomNumber);
                }
            }

            foreach (int bobmLocation in bombMap)
            {
                int col = (bobmLocation / boardColumns);
                int row = (bobmLocation % boardColumns);
                if (row == 0 && bobmLocation != 0)
                {
                    col--;
                    row = boardColumns;
                }
                else
                {
                    row++;
                }
                gameField[col, row - 1] = '*';
            }

            return gameField;
        }

        private static char CalculatingBombsLeft(char[,] gameField, int row, int col)
        {
            int counter = 0;
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (gameField[row - 1, col] == '*')
                {
                    counter++;
                }
            }
            if (row + 1 < rows)
            {
                if (gameField[row + 1, col] == '*')
                {
                    counter++;
                }
            }
            if (col - 1 >= 0)
            {
                if (gameField[row, col - 1] == '*')
                {
                    counter++;
                }
            }
            if (col + 1 < cols)
            {
                if (gameField[row, col + 1] == '*')
                {
                    counter++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (gameField[row - 1, col - 1] == '*')
                {
                    counter++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (gameField[row - 1, col + 1] == '*')
                {
                    counter++;
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (gameField[row + 1, col - 1] == '*')
                {
                    counter++;
                }
            }
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (gameField[row + 1, col + 1] == '*')
                {
                    counter++;
                }
            }
            return char.Parse(counter.ToString());
        }

        public static char[,] gameField { get; set; }
    }
}
