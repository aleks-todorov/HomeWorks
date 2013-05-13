using System.Collections.Generic;
using _1.ScoolStructure;

namespace StudentsList
{
    public static class ListOfStudents
    {
        public static List<Student> ListOfAllStudents = new List<Student>();

        public static void AddStudent(Student student)
        {
            ListOfAllStudents.Add(student);
        }

        public static bool CheckIfUniqueNumber(int number)
        {
            bool isUniqueNumber = true;

            foreach (var student in ListOfAllStudents)
            {
                if (student.Number == number)
                {
                    isUniqueNumber = false;
                    break;
                }
            }
            return isUniqueNumber;
        }
    }
}
