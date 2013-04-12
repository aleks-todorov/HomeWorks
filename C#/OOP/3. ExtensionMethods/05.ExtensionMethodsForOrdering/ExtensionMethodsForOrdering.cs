using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethod.CommonClasses;

namespace _05.ExtensionMethodsForOrdering
{
    class ExtensionMethodsForOrdering
    {
        static void Main(string[] args)
        {
            Students[] studentsArray = new Students[5];
            studentsArray[0] = new Students("Aaaaaa", "Bbbbbb");
            studentsArray[1] = new Students("Aaaaaa", "Aaaaaa");
            studentsArray[2] = new Students("Aaaaaa", "Gggggg");
            studentsArray[3] = new Students("Aaaaaa", "Hhhhhh");
            studentsArray[4] = new Students("Aaaaaa", "Yyyyyy");

            //Using Lambda Expressions
            OrderWithLambda(studentsArray);

            //Using LINQ 
            OrderWithLINQ(studentsArray);

            //First one is using Array of type Students and the second one is using list => PrintResult method was not worthed
        }

        private static void OrderWithLINQ(Students[] studentsArray)
        {
            var students = from student in studentsArray
                           orderby student.FirstName descending, student.LastName descending
                           select student;

            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }

        private static void OrderWithLambda(Students[] studentsArray)
        {
            studentsArray = studentsArray.OrderByDescending(t => t.FirstName).ThenByDescending(t => t.LastName).ToArray();
            foreach (var student in studentsArray)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
