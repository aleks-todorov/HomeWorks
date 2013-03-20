using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanRepresentation
{
    public class Student : Human
    {
        private double grade;

        public double Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public Student(string firstName, string lastName, double grade)
            : base(firstName, lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return "Student - First Name: " + this.FirstName + " Last Name: " + this.LastName + " Grade: " + this.Grade;
        }
    }
}
