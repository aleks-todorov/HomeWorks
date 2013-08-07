using System.Collections.Generic;

namespace SchoolDB.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Materials { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public Course()
        {
            this.Homeworks = new List<Homework>();
            this.Students = new List<Student>();
        }
    }
}
