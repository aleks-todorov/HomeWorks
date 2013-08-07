using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using SupermarketEntities;
using Sales.Data.MSSQL;
using Sales.Models.MSSQL;
using Sales.Data.MSSQL.Migrations;
using System.Data.SQLite;
using System.Globalization;
using System.Threading;
using System.Data;

public static class MySqlToSql
{
    public static void Clone(SalesContext SqlDatabase, SupermarketModel mySqlTest)
    {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<SalesContext, Configuration>());
        using (SqlDatabase)
        {
            foreach (var vendor in mySqlTest.Vendors)
            {
                if (!SqlDatabase.Vendors.Any(x => x.Name == vendor.VendorName))
                {
                    SqlDatabase.Vendors.Add(new Sales.Models.MSSQL.Vendor
                    {
                        Name = vendor.VendorName,
                    });
                }
            }

            SqlDatabase.SaveChanges();
            foreach (var product in mySqlTest.Products.Include("Vendors").Include("Measures"))
            {
                if (!SqlDatabase.Products.Any(x => x.Name == product.ProductName))
                {
                    SqlDatabase.Products.Add(new Sales.Models.MSSQL.Product
                    {
                        Name = product.ProductName,
                        Vendor = SqlDatabase.Vendors.Where(x => x.Name == product.Vendor.VendorName).First(),
                        BasePrice = (decimal)product.BasePrice,
                        Measure = (Sales.Models.MSSQL.Measure)Enum.Parse(typeof(Sales.Models.MSSQL.Measure), product.Measure.MeasureName)
                    });
                }
            }

            SqlDatabase.SaveChanges();
        }
    }
}
