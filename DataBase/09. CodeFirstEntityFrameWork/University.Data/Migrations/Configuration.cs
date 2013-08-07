namespace University.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using University.Models;

    public sealed class Configuration : DbMigrationsConfiguration<University.Data.UniversityContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(University.Data.UniversityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Courses.AddOrUpdate(
             new Course { Name = "C#", Description = "Introduction to programming with C#", Materials = "Introduction to C# " },
             new Course { Name = "JavaScript", Description = "Introduction to programming with  JavaScript", Materials = "JavaScript for Dummies" },
             new Course { Name = "C# 2", Description = "Advanced part of programming", Materials = "Introduction to C#, Intro to Algorithms" }
           );

            context.Homeworks.AddOrUpdate(
                new Homework { Content = "Entity Framework Code First" },
                new Homework { Content = "Entity Framework Database First" },
                new Homework { Content = "XML Tasks" }
                );
        }
    }
}
