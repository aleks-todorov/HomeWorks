using System;
using _1.ScoolStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void School_CreateNewSchool()
        {
            var school = new School();
            bool isSchoolAdded = school is School;
            Assert.IsTrue(isSchoolAdded);
        }

        [TestMethod]
        public void School_AddNewCourse()
        {
            var school = new School();
            var course = new Course("Math");
            school.AddCourse(course);
            bool isCourseAdded = school.CheckIfCourseExists(course);
            Assert.IsTrue(isCourseAdded);
        }
    }
}
