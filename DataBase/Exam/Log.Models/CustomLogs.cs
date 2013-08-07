using System;
using System.ComponentModel.DataAnnotations;

namespace Log.Models
{
    public class CustomLogs
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string QueryXML { get; set; }
    }
}
