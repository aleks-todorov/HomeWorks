using System;
using _1.ScoolStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class StudnetTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_CreatingStudentWithNullName()
        {
            var student = new Student(10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_CreatingStudentWithNoName()
        {
            var student = new Student(string.Empty, 10001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Student_CreatingStudentWithSmallerNumber()
        {
            var student = new Student("TEST", 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Student_CreatingStudentWithBiggerNumber()
        {
            var student = new Student("TEST", 1000000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Student_CreatingStudentWithSameNumber()
        {
            var student = new Student("TEST", 10002);
            var student2 = new Student("TEST", 10002);
        }

        [TestMethod]
        public void Student_CreateNormalStudent()
        {
            var student = new Student("Gosho", 12344);
            var isStudent = student is Student;
            Assert.IsTrue(isStudent);
        }
    }
}
