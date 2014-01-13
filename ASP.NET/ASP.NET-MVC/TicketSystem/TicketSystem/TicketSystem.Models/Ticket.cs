using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TicketSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual Category Category { get; set; }

        public string AuthorId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [ShouldNotContainBugAttribute(Word = "Bug", ErrorMessage = "Title should not contain the word Bug!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ticket Title should be between 3 and 50 symbols")]
        public string Title { get; set; }

        [Required]
        public Priority Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Ticket()
        {
            this.Comments = new HashSet<Comment>();
            this.Priority = Priority.Medium;
        }
    }
}
