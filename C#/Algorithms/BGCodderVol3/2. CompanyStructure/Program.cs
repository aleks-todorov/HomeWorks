using System;
using System.Collections.Generic;

class Firm
{
    static long allSalaries = 0;

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());

        var employees = new Dictionary<string, Employee>();
        string bossName = Console.ReadLine();
        var bigBoss = new Employee(bossName);

        employees.Add(bigBoss.Name, bigBoss);

        for (int i = 1; i < N; i++)
        {
            string name = Console.ReadLine();
            var employee = new Employee(name);
            employees.Add(name, employee);
        }

        for (int i = 0; i < M; i++)
        {
            string line = Console.ReadLine();
            string[] names = line.Split(' ');
            string supperior = names[0];

            for (int j = 1; j < names.Length; j++)
            {
                employees[supperior].Subordinates.Add(employees[names[j]]);
            }
        }

        DFS(bigBoss);

        Console.WriteLine(allSalaries);
    }

    public static void DFS(Employee root)
    {
        if (root.Subordinates.Count == 0)
        {
            allSalaries += root.Salary;
            return;
        }

        int salary = 0;

        foreach (var employee in root.Subordinates)
        {
            DFS(employee);
            salary += employee.Salary;
        }

        root.Salary = salary;
        allSalaries += root.Salary;
    }
}

class Employee
{
    public List<Employee> Subordinates { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }

    public Employee(string name)
    {
        this.Name = name;
        this.Subordinates = new List<Employee>();
        this.Salary = 1;
    }
}

