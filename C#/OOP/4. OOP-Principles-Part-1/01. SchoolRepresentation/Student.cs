using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolRepresentation
{
    class Student : Person
    {
        private int classNumber;

        public int ClassNumber
        {
            get { return classNumber; }
            set { classNumber = value; }
        }

        public Student(string firstName, string lastName, int classNumber)
            : base(firstName, lastName)
        {
            this.classNumber = classNumber;
        }

        public Student(string firstName, string lastName, int classNumber, string comment)
            : base(firstName, lastName, comment)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ClassNumber = classNumber;
            this.Comment = comment;
        }

        public override string ToString()
        {
            return "Student: \n FirstName: " + this.FirstName + "Last Name: " + this.LastName + "Class Number: " + this.ClassNumber;
        }
    }
}
