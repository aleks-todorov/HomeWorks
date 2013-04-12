using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolRepresentation
{
    class Discipline
    {
        private DisciplineName name;
        private int numberOfLectures;
        private int numberOfExercies;
        private string comment;

        public DisciplineName Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NumberOfLectures
        {
            get { return numberOfLectures; }
            set { numberOfLectures = value; }
        }

        public int NumberOfExercies
        {
            get { return numberOfExercies; }
            set { numberOfExercies = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public Discipline(DisciplineName name, int numberOfLectures, int numberOfExercies)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercies = numberOfExercies;
            this.Comment = comment;
        }

        public Discipline(DisciplineName name, int numberOfLectures, int numberOfExercies, string comment)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercies = numberOfExercies;
        }

        public override string ToString()
        {
            return "Discipline: " + this.Name + "Number of lectures: " + this.NumberOfLectures + " Number of Exercises " + this.NumberOfExercies;
        }
    }
}
