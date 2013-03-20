using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolRepresentation
{
    class Teacher : Person, IAddable<DisciplineName>
    {
        private List<DisciplineName> discipline;

        public List<DisciplineName> Discipline
        {
            get { return discipline; }
            set { discipline = value; }
        }

        public Teacher(string firstName, string lastName)
            : base(firstName, lastName)
        {
            this.Discipline = new List<DisciplineName>();
        }

        public Teacher(string firstName, string lastName, string comment)
            : base(firstName, lastName, comment)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Discipline = new List<DisciplineName>();
            this.Comment = comment;
        }

        public void AddElement(DisciplineName element)
        {
            this.Discipline.Add(element);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("\n Teacher: ");
            result.Append("First Name: " + this.FirstName + "\n");
            result.Append("Last Name: " + this.LastName + "\n");

            foreach (var discipline in Discipline)
            {
                result.Append("Discipline: " + discipline);
                result.Append("\n");
            }

            return result.ToString();
        }
    }
}
