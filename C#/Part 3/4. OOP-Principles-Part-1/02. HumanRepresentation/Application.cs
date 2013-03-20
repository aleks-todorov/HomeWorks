using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanRepresentation
{
    class Application
    {
        static void Main(string[] args)
        {
            //Defining 10 Students and adding them to list: 
            List<Student> studentGroup = new List<Student>();

            studentGroup.Add(new Student("Brat", "Smalls", 5.50));
            studentGroup.Add(new Student("Max", "Jones", 2.50));
            studentGroup.Add(new Student("Tom", "Lee", 5.30));
            studentGroup.Add(new Student("Bon", "Chin", 3.50));
            studentGroup.Add(new Student("Vin", "Willis", 5.50));
            studentGroup.Add(new Student("Mike", "Void", 4.80));
            studentGroup.Add(new Student("John", "Smith", 4.10));
            studentGroup.Add(new Student("Peter", "Jackson", 3.90));
            studentGroup.Add(new Student("Alex", "Raider", 3.76));
            studentGroup.Add(new Student("Eddy", "Smith", 5.80));

            //Showing sorted Students List with labda expression: 
            studentGroup = studentGroup.OrderBy(t => t.Grade).ToList();
            foreach (var element in studentGroup)
            {
                Console.WriteLine(element.ToString());
            }

            //Defining 10 Workers and adding them to list: 
            List<Worker> workersGroup = new List<Worker>();

            workersGroup.Add(new Worker("Jerry", "Chin", 220.44m, 8));
            workersGroup.Add(new Worker("Vin", "Jones", 260.64m, 8));
            workersGroup.Add(new Worker("John", "Woo", 350.34m, 8));
            workersGroup.Add(new Worker("Max", "Lee", 230.65m, 8));
            workersGroup.Add(new Worker("Billy", "Smith", 140.12m, 8));
            workersGroup.Add(new Worker("John", "Smith", 254.83m, 8));
            workersGroup.Add(new Worker("Peter", "Willis", 223.14m, 8));
            workersGroup.Add(new Worker("Tom", "Void", 543.43m, 8));
            workersGroup.Add(new Worker("Alex", "Jackson", 234.18m, 8));
            workersGroup.Add(new Worker("Eddy", "Raider", 643.16m, 8));

            //Showing sorted Workers List with lambda expression: 
            workersGroup = workersGroup.OrderByDescending(t => t.MoneyPerHour).ToList();
            Console.WriteLine();
            foreach (var worker in workersGroup)
            {
                Console.WriteLine(worker.ToString());
            }

            //Merging both Lists and showing result. Using lambda expression for sorting.
            var mergedlists = studentGroup.Concat<Human>(workersGroup).ToList();
            mergedlists = mergedlists.OrderBy(t => t.FirstName).ThenBy(t => t.LastName).ToList();
            Console.WriteLine();
            foreach (var human in mergedlists)
            {
                Console.WriteLine(human.ToString());
            }

        }
    }
}
