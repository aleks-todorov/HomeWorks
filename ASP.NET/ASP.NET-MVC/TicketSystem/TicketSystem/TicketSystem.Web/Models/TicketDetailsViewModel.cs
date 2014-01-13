using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketSystem.Models;

namespace TicketSystem.Web.Models
{
    public class TicketDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Category { get; set; }

        public string AuthorName { get; set; }

        public Priority Priority { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

    }
}