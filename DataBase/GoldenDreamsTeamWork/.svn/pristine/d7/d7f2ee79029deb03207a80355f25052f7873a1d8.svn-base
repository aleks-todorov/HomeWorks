using Sales.Data.MSSQL;
using Sales.Data.MSSQL.Migrations;
using SupermarketEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Data.DatabaseClone
{
    public static class MySqlToSql
    {
        public static void ReadMySQL(SalesContext SqlDatabase, SupermarketModel mySqlTest)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SalesContext, Configuration>());


            foreach (var vendor in mySqlTest.Vendors)
            {
                if (!SqlDatabase.Vendors.Any(x => x.Name == vendor.VendorName))
                {
                    SqlDatabase.Vendors.Add(new Models.MSSQL.Vendor
                    {
                        Name = vendor.VendorName,
                    });
                }
            }

            SqlDatabase.SaveChanges();

            foreach (var product in mySqlTest.Products.Include("Vendors").Include("Measures"))
            {
                SqlDatabase.Products.Add(new Sales.Models.MSSQL.Product
                {
                    Name = product.ProductName,
                    Vendor = SqlDatabase.Vendors.Where(x => x.Name == product.Vendor.VendorName).First(),
                    BasePrice = (decimal)product.BasePrice,
                    Measure = (Models.MSSQL.Measure)Enum.Parse(typeof(Models.MSSQL.Measure), product.Measure.MeasureName)
                });
            }

            SqlDatabase.SaveChanges();
        }
    }
}
