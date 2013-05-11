using System;
using System.Collections.Generic;
using StudentsList;

namespace _1.ScoolStructure
{
    public class Student
    {
        private int number;
        private string name;

        public int Number
        {
            get { return number; }
            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("Invalid student's number");
                }
                if (!ListOfStudents.CheckIfUniqueNumber(value))
                {
                    throw new ArgumentOutOfRangeException("Invalid student's number");
                }
                this.number = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == string.Empty || value == null)
                {
                    throw new ArgumentNullException("Name cannot have empty value!");
                }
                name = value;
            }
        }

        public Student(int number)
        {
            this.Name = null;
            this.Number = number;
            ListOfStudents.AddStudent(this);
        }

        public Student(string name, int number)
        {
            this.Name = name;
            this.Number = number;
            ListOfStudents.AddStudent(this);
        }
    }
}
