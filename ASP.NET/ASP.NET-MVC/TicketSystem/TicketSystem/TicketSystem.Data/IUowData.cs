using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Models;

namespace TicketSystem.Data
{
    public interface IUowData
    {
        IRepository<Comment> Comments { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<Category> Categories { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
