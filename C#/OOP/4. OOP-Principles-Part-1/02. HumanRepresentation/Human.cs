using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanRepresentation
{
    public abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
