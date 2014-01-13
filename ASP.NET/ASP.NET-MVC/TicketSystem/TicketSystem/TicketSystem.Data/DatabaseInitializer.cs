using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Data
{
    public class DatabaseInitializer : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DatabaseInitializer()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Tickets.Count() > 0)
            {
                return;
            }

            Random random = new Random();

            ApplicationUser user = new ApplicationUser() { UserName = "TestUser" };

            for (int i = 0; i < 10; i++)
            {
                var category = new Category() { Name = "Category" + (i + 1) };

                var ticketsCount = random.Next(1, 15);
                for (int j = 0; j < ticketsCount; j++)
                {
                    var ticket = new Ticket()
                    {
                        Author = user,
                        AuthorId = user.Id,
                        CategoryId = category.Id,
                        Priority = Priority.Medium,
                        Title = "Ticket for Issue number " + j,
                        Description = "Some Description",
                        ScreenshotUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRzykAHUnoqV8ukGki-fcC-LXT_ZBBsAXTyQpB4pOxwX4l-F_AA"
                    };

                    var commentsCount = random.Next(1, 5);
                    for (int k = 0; k < commentsCount; k++)
                    {
                        var comment = new Comment() { Author = user, Ticket = ticket, Content = "Some Content " + k };
                        ticket.Comments.Add(comment);
                    }

                    category.Tickets.Add(ticket);
                    user.Points++;
                }

                context.Categories.Add(category);
            }

            base.Seed(context);
        }
    }
}
