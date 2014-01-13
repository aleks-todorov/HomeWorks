using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketSystem.Models;

namespace TicketSystem.Web.Models
{
    public class ListPageTicketViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }

        public string Author { get; set; }

        public Priority PriorityName { get; set; }

        public string PriorityToString { get { return this.PriorityName.ToString(); } }
    }
}