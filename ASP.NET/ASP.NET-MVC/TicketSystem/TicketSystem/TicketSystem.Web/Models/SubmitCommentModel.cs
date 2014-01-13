using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketSystem.Web.Models
{
    public class SubmitCommentModel
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public int TicketId { get; set; }
    }
}