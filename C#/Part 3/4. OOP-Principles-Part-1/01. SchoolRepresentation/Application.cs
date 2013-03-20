using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolRepresentation
{
    class Application
    {
        static void Main(string[] args)
        {
            //Defining Student
            Student student = new Student("John", "Smith", 1234322);
            //Console.WriteLine(student.ToString());
            //Defining Teacher
            Teacher teacher = new Teacher("John", "Doe");
            teacher.AddElement(DisciplineName.Biology);
            teacher.AddElement(DisciplineName.Science);
            //Console.WriteLine(teacher.ToString());

            //Defining Class
            Classes newClass = new Classes("143A");
            newClass.AddElement(student);
            newClass.AddElement(teacher);
            //Console.WriteLine(newClass.ToString());
            //Defining School
            School school = new School();
            school.AddElement(newClass);
            Console.WriteLine(school.ToString());
        }
    }
}
