using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PersonRepresentation
{
    class Person
    {
        private string name;
        private int? age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int? Age
        {
            get { return age; }
            set { age = value; }
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name)
        {
            this.Name = name;
            this.Age = null;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Person:");
            sb.AppendLine("Name: " + this.Name);
            if (this.age != null)
            {
                sb.AppendLine("Age: " + this.Age);
            }
            else
            {
                sb.AppendLine("Age is not specified");
            }
            return sb.ToString();
        }
    }
}
