using System.Collections.Generic;

namespace University.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Materials { get; set; }
        private ICollection<Student> studentsInCourse;
        private ICollection<Homework> homeworks;

        public Course()
        {
            this.studentsInCourse = new List<Student>();
            this.homeworks = new List<Homework>();
        }

        public virtual ICollection<Student> StudentsInCourse
        {
            get { return studentsInCourse; }
            set { studentsInCourse = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return homeworks; }
            set { homeworks = value; }
        }
    }
}
