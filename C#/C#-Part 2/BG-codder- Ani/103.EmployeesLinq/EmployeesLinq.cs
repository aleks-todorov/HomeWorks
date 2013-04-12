using System;
using System.Collections.Generic;
using System.Linq;

//100/100
class EmployeesLinq
{
    static void Main()
    {
        Dictionary<string, int> positions = new Dictionary<string, int>();
        int positionsNumber = Int32.Parse(Console.ReadLine());

        for (int i = 0; i < positionsNumber; i++)
        {
            string line = Console.ReadLine();
            string[] splitLine = line.Split(new string[] { " – ", " - " }, StringSplitOptions.RemoveEmptyEntries);

            if (!positions.ContainsKey(splitLine[0]))
            {
                positions.Add(splitLine[0], Int32.Parse(splitLine[1]));
            }
        }

        int employeesNumber = Int32.Parse(Console.ReadLine());

        List<Employee> listOfEmployees = new List<Employee>();
        for (int i = 0; i < employeesNumber; i++)
        {
            string line = Console.ReadLine();
            string[] splitLine = line.Split(new string[] { " – ", " - " }, StringSplitOptions.RemoveEmptyEntries);
            listOfEmployees.Add(new Employee { name = splitLine[0], position = splitLine[1] });
        }

        listOfEmployees = listOfEmployees.OrderByDescending(x => positions[x.position]).ThenBy(
        x =>
        {
            string[] splitName = x.name.Split();
            return splitName[1];
        }).ThenBy(
        x =>
        {
            string[] splitName = x.name.Split();
            return splitName[0];
        }).ToList();

        foreach (Employee empl in listOfEmployees)
        {
            Console.WriteLine(empl.name);
        }
    }
}

struct Employee
{
    public string name;
    public string position;
}