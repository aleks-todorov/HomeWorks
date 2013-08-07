using System.Collections.Generic;

namespace SchoolDB.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public Student()
        {
            this.Homeworks = new List<Homework>();
            this.Courses = new List<Course>();
        }
    }
}
