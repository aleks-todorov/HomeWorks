using System.Data.Entity;
using SchoolDB.Models;

namespace SchoolDb.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("SchoolDb")
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
    }
}
