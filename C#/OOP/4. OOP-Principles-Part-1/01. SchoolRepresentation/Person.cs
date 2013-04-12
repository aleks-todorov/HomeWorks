using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolRepresentation
{
    abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comment { get; set; }

        protected Person(string firstName, string lastName, string comment)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Comment = comment;
        }

        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
