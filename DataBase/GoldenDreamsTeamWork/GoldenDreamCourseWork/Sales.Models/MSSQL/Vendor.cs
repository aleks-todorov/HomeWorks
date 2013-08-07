﻿using System.Collections.Generic;

namespace Sales.Models.MSSQL
{
    public class Vendor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Expenses> Expenses { get; set; }

        public Vendor()
        {
            this.Products = new List<Product>();
        }
    }
}