using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class ShouldNotContainBugAttribute : ValidationAttribute
    { 
        public string Word { get; set; }
        public override bool IsValid(object value)
        {

            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return false;
            }

            if (Regex.IsMatch(valueAsString, this.Word, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
