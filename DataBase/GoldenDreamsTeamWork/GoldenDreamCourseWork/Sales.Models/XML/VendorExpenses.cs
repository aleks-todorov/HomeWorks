using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Models.XML
{
    public class Expense
    {
        public string Vendor { get; set; }

        public IList<KeyValuePair<DateTime, decimal>> List { get; set; }

        public Expense()
        {
            this.List = new List<KeyValuePair<DateTime, decimal>>();
        }
    }
}
