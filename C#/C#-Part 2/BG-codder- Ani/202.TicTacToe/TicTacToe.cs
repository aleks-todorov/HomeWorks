using System;
using System.Collections.Generic;

//90/100; The first test "bombs" because it is actually an invalid game: 
//OOX
//XXO
//O--
//there is no a way a valid tictactoe game to reach a state like that

class TicTacToe
{
    static char[,] matrix;
    static int countWinO = 0;
    static int countWinX = 0;
    static int countTied = 0;
    static List<int[]> availableSlots;

    static void Main()
    {
        matrix = new char[3, 3];
        string line = Console.ReadLine();
        matrix[0, 0] = line[0];
        matrix[0, 1] = line[1];
        matrix[0, 2] = line[2];
        line = Console.ReadLine();
        matrix[1, 0] = line[0];
        matrix[1, 1] = line[1];
        matrix[1, 2] = line[2];
        line = Console.ReadLine();
        matrix[2, 0] = line[0];
        matrix[2, 1] = line[1];
        matrix[2, 2] = line[2];

        availableSlots = GetAvailableSlots();
        MakeRecursiveTurnInGame(IsXTurn());
        Console.WriteLine(countWinX);
        Console.WriteLine(countTied);
        Console.WriteLine(countWinO);
    }

    static void MakeRecursiveTurnInGame(bool isXTurn)
    {
        if (CheckIfGameIsWon() == 1)
        {
            countWinX++;
            return;
        }
        if (CheckIfGameIsWon() == -1)
        {
            countWinO++;
            return;
        }
        if (CheckIfGameIsTied())
        {
            countTied++;
            return;
        }

        for (int i = 0; i < availableSlots.Count; i++)
        {
            if (availableSlots[i][2] == 1) //already taken
            {
                continue;
            }
            availableSlots[i][2] = 1;
            matrix[availableSlots[i][0], availableSlots[i][1]] = isXTurn ? 'X' : 'O';
            MakeRecursiveTurnInGame(!isXTurn);
            matrix[availableSlots[i][0], availableSlots[i][1]] = '-';
            availableSlots[i][2] = 0;
        }
    }

    static bool IsXTurn()
    {
        int countX = 0;
        int countO = 0;
        for (int u = 0; u < 3; u++)
        {
            for (int i = 0; i < 3; i++)
            {
                if (matrix[u, i] == 'X')
                {
                    countX++;
                }
                else if ((matrix[u, i] == 'O'))
                {
                    countO++;
                }
            }
        }

        if (countX == countO)
        {
            return true;
        }
        else if (countX == countO + 1)
        {
            return false;
        }
        else
        {
            throw new ArgumentException("The game is not valid");
        }

    }

    static List<int[]> GetAvailableSlots()
    {
        List<int[]> result = new List<int[]>();
        for (int u = 0; u < 3; u++)
        {
            for (int i = 0; i < 3; i++)
            {
                if (matrix[u, i] == '-')
                {
                    result.Add(new int[3] { u, i, 0 }); //0 means that the slot is available; 1 currently being used by the recursion
                }
            }
        }
        return result;
    }

    static int CheckIfGameIsWon()
    {
        if ((matrix[0, 0] == 'X' && matrix[0, 0] == matrix[0, 1] && matrix[0, 1] == matrix[0, 2]) ||
            (matrix[1, 0] == 'X' && matrix[1, 0] == matrix[1, 1] && matrix[1, 1] == matrix[1, 2]) ||
            (matrix[2, 0] == 'X' && matrix[2, 0] == matrix[2, 1] && matrix[2, 1] == matrix[2, 2]) ||
            (matrix[0, 0] == 'X' && matrix[0, 0] == matrix[1, 0] && matrix[1, 0] == matrix[2, 0]) ||
            (matrix[0, 1] == 'X' && matrix[0, 1] == matrix[1, 1] && matrix[1, 1] == matrix[2, 1]) ||
            (matrix[0, 2] == 'X' && matrix[0, 2] == matrix[1, 2] && matrix[1, 2] == matrix[2, 2]) ||
            (matrix[0, 0] == 'X' && matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2]) ||
            (matrix[2, 0] == 'X' && matrix[2, 0] == matrix[1, 1] && matrix[1, 1] == matrix[0, 2]))
        {
            return 1;
        }
        if ((matrix[0, 0] == 'O' && matrix[0, 0] == matrix[0, 1] && matrix[0, 1] == matrix[0, 2]) ||
            (matrix[1, 0] == 'O' && matrix[1, 0] == matrix[1, 1] && matrix[1, 1] == matrix[1, 2]) ||
            (matrix[2, 0] == 'O' && matrix[2, 0] == matrix[2, 1] && matrix[2, 1] == matrix[2, 2]) ||
            (matrix[0, 0] == 'O' && matrix[0, 0] == matrix[1, 0] && matrix[1, 0] == matrix[2, 0]) ||
            (matrix[0, 1] == 'O' && matrix[0, 1] == matrix[1, 1] && matrix[1, 1] == matrix[2, 1]) ||
            (matrix[0, 2] == 'O' && matrix[0, 2] == matrix[1, 2] && matrix[1, 2] == matrix[2, 2]) ||
            (matrix[0, 0] == 'O' && matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2]) ||
            (matrix[2, 0] == 'O' && matrix[2, 0] == matrix[1, 1] && matrix[1, 1] == matrix[0, 2]))
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    static bool CheckIfGameIsTied()
    {
        for (int u = 0; u < 3; u++)
        {
            for (int i = 0; i < 3; i++)
            {
                if (matrix[u, i] == '-')
                {
                    return false;
                }
            }
        }
        return true;
    }
}