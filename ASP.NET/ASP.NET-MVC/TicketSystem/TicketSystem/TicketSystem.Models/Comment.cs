using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual Ticket Ticket { get; set; }

        [Required]
        public string Content { get; set; }
         
        public string AuthorID { get; set; }

        public int TicketId { get; set; }
    }
}
