using System;
using _1.ScoolStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void Course_CreatingCourse()
        {
            var course = new Course("Math");
            var isCreateadCorrect = course is Course;
            Assert.IsTrue(isCreateadCorrect);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Course_CreatingCourseWithExtraStudents()
        {
            var course = new Course("Math");

            for (int i = 1; i < 50; i++)
            {
                var student = new Student(i.ToString(), 10000 + i);
                course.AddStudent(student);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Course_DeletingNonPresentStudent()
        {
            var course = new Course("Math");
            var student = new Student("Pesho", 19872);
            course.RemoveStudent(student);
        }

        [TestMethod]
        public void Course_DeletingPresentStudent()
        {
            var course = new Course("Math");
            var student = new Student("Pesho", 19834);
            course.AddStudent(student);
            course.RemoveStudent(student);
            bool studentIsRemoved = course.CheckIfStudentExists(student);
            Assert.IsFalse(studentIsRemoved);
        }
    }
}
