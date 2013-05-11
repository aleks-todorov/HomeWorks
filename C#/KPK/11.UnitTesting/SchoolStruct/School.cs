using System.Collections.Generic;

namespace _1.ScoolStructure
{
    public class School
    {
        private IList<Course> Courses { get; set; }

        public School()
        {
            this.Courses = new List<Course>();
        }

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }

        public bool CheckIfCourseExists(Course subject)
        {
            bool isCourseExists = false;

            foreach (var course in Courses)
            {
                if (subject.CourseName == course.CourseName)
                {
                    isCourseExists = true;
                    break;
                }
            }
            return isCourseExists;
        }
    }
}
