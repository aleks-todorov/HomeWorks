using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolRepresentation
{
    class School : IAddable<Classes>
    {
        private List<Classes> classes;

        public List<Classes> Classes
        {
            get { return classes; }
            set { classes = value; }
        }

        public School()
        {
            this.Classes = new List<Classes>(); ;
        }

        public void AddElement(Classes element)
        {
            this.Classes.Add(element);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var course in Classes)
            {
                result.Append(course.ToString());
            }
            return result.ToString();
        }
    }
}
