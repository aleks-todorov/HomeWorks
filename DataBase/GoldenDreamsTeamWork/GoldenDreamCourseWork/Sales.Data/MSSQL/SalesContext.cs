﻿using System.Data.Entity;
using Sales.Models.MSSQL;

namespace Sales.Data.MSSQL
{
    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Record> Records { get; set; }

        public DbSet<Supermarket> Supermarkets { get; set; }

        public SalesContext()
            : base("SalesDB")
        {
        }
    }
}