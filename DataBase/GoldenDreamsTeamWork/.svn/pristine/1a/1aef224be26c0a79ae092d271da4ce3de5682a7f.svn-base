using System;
using System.Collections.Generic;

namespace Sales.Models.Excel
{
    public class SupermarketData
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public ICollection<Record> Items { get; set; }

        public SupermarketData()
        {
            this.Items = new List<Record>();
        }

        public void Add(Record record)
        {
            this.Items.Add(record);
        }
    }
}
