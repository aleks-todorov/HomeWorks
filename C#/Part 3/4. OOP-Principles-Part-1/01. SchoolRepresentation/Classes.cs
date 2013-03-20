using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolRepresentation
{
    class Classes : IAddable<Teacher>
    {
        private string textIdentifier;
        private List<Teacher> teachers;
        private List<Student> students;
        private string comment;

        public string TextIdentifier
        {
            get { return textIdentifier; }
            set { textIdentifier = value; }
        }

        public List<Teacher> Teachers
        {
            get { return teachers; }
            set { teachers = value; }
        }

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public Classes(string textIdentifier)
        {
            this.TextIdentifier = textIdentifier;
            this.Teachers = new List<Teacher>();
            this.Students = new List<Student>();
        }

        public Classes(string textIdentifier, string comment)
        {
            this.TextIdentifier = textIdentifier;
            this.Teachers = new List<Teacher>();
            this.Students = new List<Student>();
            this.Comment = comment;
        }

        //Overloading AddElelemt method. When Creating instances look the constructor requested parameters!!!
        public void AddElement(Teacher element)
        {
            this.Teachers.Add(element);
        }

        public void AddElement(Student element)
        {
            this.Students.Add(element);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(textIdentifier);

            foreach (var teacher in Teachers)
            {
                result.Append(teacher.ToString());
            }

            foreach (var student in Students)
            {
                result.Append(student.ToString());
            }
            result.Append("\n");
            return result.ToString();
        }
    }
}
