using System.Collections.Generic;

namespace Sales.Models.MSSQL
{
    public class Supermarket
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Record> Records { get; set; }

        public Supermarket()
        {
            this.Records = new List<Record>();
        }
    }
}
