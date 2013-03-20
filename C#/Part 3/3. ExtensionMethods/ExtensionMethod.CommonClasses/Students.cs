using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod.CommonClasses
{
    public class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Students(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = 0;
        }

        public Students(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public override string ToString()
        {
            string student = "Student First Name: " + this.FirstName + " Student Last Name: " + this.LastName + " Age: " + this.Age;
            return student;
        }
    }
}
