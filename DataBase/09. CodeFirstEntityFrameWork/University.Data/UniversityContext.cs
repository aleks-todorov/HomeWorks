using System;
using System.Linq;
using System.Data.Entity;
using University.Models;

namespace University.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> Homeworks { get; set; }

        public UniversityContext()
            : base("UniversityDB")
        {
        }
    }
}
