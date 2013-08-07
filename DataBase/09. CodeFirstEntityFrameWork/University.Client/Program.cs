using System;
using System.Data.Entity;
using System.Linq;
using University.Data;
using University.Data.Migrations;
using University.Models;

namespace University.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UniversityContext, Configuration>());

            var db = new UniversityContext();
            var student = new Student { Name = "Pesho", Number = 11111 };
            var studentTwo = new Student { Name = "Misho", Number = 22222 };
            var studentThree = new Student { Name = "Gosho", Number = 33333 };
            var course = new Course { Name = "Programming 101", Description = "Introduction to Programming", Materials = "Youtube videos" };
            student.Homeworks.Add(new Homework { Student = student, Content = "Some content" });
            course.Homeworks.Add(new Homework { Course = course, Content = "Some content" });
            db.Students.Add(student);
            db.Students.Add(studentTwo);
            db.Students.Add(studentThree);
            db.Courses.Add(course);
            db.SaveChanges();
        }
    }
}
