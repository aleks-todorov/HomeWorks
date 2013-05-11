using System;
using System.Collections.Generic;

namespace _1.ScoolStructure
{
    public class Course
    {
        public string CourseName { get; set; }
        public IList<Student> StudentsInCourse { get; set; }

        public Course(string courseName)
        {
            this.CourseName = courseName;
            this.StudentsInCourse = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            if (StudentsInCourse.Count < 30)
            {
                StudentsInCourse.Add(student);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Students in this Course should not be more than 30!");
            }
        }

        public void RemoveStudent(Student student)
        {
            if (StudentsInCourse.Contains(student))
            {
                StudentsInCourse.Remove(student);
            }
            else
            {
                throw new ArgumentOutOfRangeException("This student is not part of this course");
            }
        }

        public bool CheckIfStudentExists(Student subject)
        {
            var studentExists = false;

            foreach (var student in StudentsInCourse)
            {
                if (subject.Name == student.Name && subject.Number == student.Number)
                {
                    studentExists = true;
                    break;
                }
            }
            return studentExists;
        }
    }
}
