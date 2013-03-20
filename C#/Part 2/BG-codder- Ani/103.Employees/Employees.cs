using System;
using System.Collections.Generic;
using System.Text;

//100/100
class Employees
{
    static void Main()
    {
        int numberPositions = Int32.Parse(Console.ReadLine());
        Dictionary<string, int> positionsList = new Dictionary<string, int>();
        string line;
        string[] splitLine;
        for (int i = 0; i < numberPositions; i++)
        {
            line = Console.ReadLine();
            splitLine = line.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            string positionName = splitLine[0].Trim();
            int rank = Int32.Parse(splitLine[1].Trim());
            if (!positionsList.ContainsKey(positionName))
            {
                positionsList.Add(positionName, rank);
            }
        }

        int numberEmployees = Int32.Parse(Console.ReadLine());
        Employee[] listEmployees = new Employee[numberEmployees];
        string[] secondSplitLine;
        for (int i = 0; i < numberEmployees; i++)
        {
            line = Console.ReadLine();
            splitLine = line.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            secondSplitLine = splitLine[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstName = secondSplitLine[0].Trim();
            string secondName = secondSplitLine[1].Trim();
            string position = splitLine[1].Trim();

            listEmployees[i] = new Employee(firstName, secondName, position, positionsList[position]);
        }

        Array.Sort(listEmployees);

        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < listEmployees.Length; i++)
        {
            builder.Append(listEmployees[i].FirstName);
            builder.Append(" ");
            builder.Append(listEmployees[i].LastName);
            builder.Append("\n");
        }
        builder.Remove(builder.Length - 1, 1);

        Console.WriteLine(builder.ToString());
    }
}

class Employee : IComparable
{
    private string firstName;
    private string lastName;
    private Position position;

    public Employee(string firstName, string lastName, string positionName, int rank)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.position = new Position(positionName, rank);
    }

    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }

    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }

    public Position Position
    {
        get { return this.position; }
        set { this.position = value; }
    }

    public int CompareTo(object obj)
    {
        Employee otherEmployee = (Employee)obj;

        if (this.Position.CompareTo(otherEmployee.Position) < 0)
        {
            return -1;
        }
        else if (this.Position.CompareTo(otherEmployee.Position) > 0)
        {
            return 1;
        }
        else
        {
            if (this.lastName.CompareTo(otherEmployee.LastName) < 0)
            {
                return -1;
            }
            else if (this.lastName.CompareTo(otherEmployee.LastName) > 0)
            {
                return 1;
            }
            else
            {
                if (this.firstName.CompareTo(otherEmployee.FirstName) < 0)
                {
                    return -1;
                }
                else if (this.firstName.CompareTo(otherEmployee.FirstName) > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}

class Position : IComparable
{
    private string name;
    private int rank;

    public Position(string name, int rank)
    {
        this.name = name;
        this.rank = rank;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Rank
    {
        get { return this.rank; }
        set { this.rank = value; }
    }

    public int CompareTo(object obj)
    {
        Position otherPosition = (Position)obj;
        if (this.rank < otherPosition.Rank)
        {
            return 1;
        }
        else if (this.rank > otherPosition.Rank)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}