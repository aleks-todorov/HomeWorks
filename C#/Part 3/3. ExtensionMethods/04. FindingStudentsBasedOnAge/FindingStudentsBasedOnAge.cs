using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.FindingStudentsBasedOnAge;
using ExtensionMethod.CommonClasses;

//Task 4: 
//Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

namespace _04.FindingStudentsBasedOnAge
{
    class FindingStudentsBasedOnAge
    {
        static void Main(string[] args)
        {
            Students[] studentsArray = new Students[5];
            studentsArray[0] = new Students("Aaaaaa", "Bbbbbb", 20);
            studentsArray[1] = new Students("Cccccc", "Aaaaaa", 25);
            studentsArray[2] = new Students("Zzzzzz", "Ggggggg", 18);
            studentsArray[3] = new Students("Cccccc", "Hhhhhhh", 22);
            studentsArray[4] = new Students("Vvvvvv", "Yyyyyyy", 28);

            var students = from student in studentsArray
                           where (student.Age <= 24 && student.Age >= 18)
                           orderby (student.Age)
                           select student;

            foreach (Students student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
