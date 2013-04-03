using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethod.CommonClasses;

//Write a method that from a given array of students finds all students whose 
//first name is before its last name alphabetically. Use LINQ query operators.

namespace _03.FindingStudentsBasedOnName
{
    class FindingStudentsBasedOnName
    {
        static void Main(string[] args)
        {
            Students[] studentArray = new Students[5];
            studentArray[0] = new Students("Aaaaaa", "Bbbbbb");
            studentArray[1] = new Students("Cccccc", "Aaaaaa");
            studentArray[2] = new Students("Zzzzzz", "Ggggggg");
            studentArray[3] = new Students("Cccccc", "Hhhhhhh");
            studentArray[4] = new Students("Vvvvvv", "Yyyyyyy");

            var students = from student in studentArray
                           where student.FirstName.CompareTo(student.LastName) == -1
                           select student;

            foreach (Students student in students)
            {
                //Will Return Age(value = 0), because it is needed for the next task. 
                Console.WriteLine(student.ToString());
            }
        }
    }
}
