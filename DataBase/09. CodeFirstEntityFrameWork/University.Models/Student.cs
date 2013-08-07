using System.Collections.Generic;

namespace University.Models
{
    public class Student
    {
        private ICollection<Homework> homeworks;
        private ICollection<Course> courses;

        public int StudentID { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public Student()
        {
            this.homeworks = new List<Homework>();
            this.Courses = new List<Course>();
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return homeworks; }
            set { homeworks = value; }
        }

        public virtual ICollection<Course> Courses
        {
            get { return courses; }
            set { courses = value; }
        }
    }
}
