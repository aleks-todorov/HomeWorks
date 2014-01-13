using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TicketSystem.Models;

namespace TicketSystem.Web.Models
{
    public class SubtmitTicketViewModel
    {
        [Required]
        public string CategoryName { get; set; }

        [Required]
        public Priority Priority { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        [Required]
        [ShouldNotContainBugAttribute(Word = "Bug", ErrorMessage = "Title should not contain the word Bug!")]
        public string Title { get; set; }
    }
}