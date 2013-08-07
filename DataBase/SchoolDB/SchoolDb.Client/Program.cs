using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolDb.Data;
using SchoolDb.Data.Migrations;
using SchoolDB.Models;
using System.Data.Entity;

namespace SchoolDb.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion
        <SchoolContext, Configuration>());

            var dbCon = new SchoolContext();
            var student = new Student();
            student.Name = "Pesho";
            student.Number = "123456";
            var homework = new Homework();
            homework.Content = "Some Content";
            var course = new Course();
            course.Name = "Intro to Code First";
            course.Materials = "youtube";
            course.Students.Add(student);
            course.Description = "Practicing Code First Model";
            student.Courses.Add(course);
            //homework.StudentId = student.Id;
            //homework.CourseId = course.Id;
            dbCon.Students.Add(student);
            dbCon.Homeworks.Add(homework);
            dbCon.Courses.Add(course);
            dbCon.SaveChanges();
        }
    }
}
