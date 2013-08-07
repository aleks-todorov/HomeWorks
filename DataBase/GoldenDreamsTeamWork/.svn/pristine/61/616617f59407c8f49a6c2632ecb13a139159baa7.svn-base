using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Sales.Data.PDF;
using SupermarketEntities;
using Sales.Data.MSSQL;
using Sales.Models.MSSQL;
using Sales.Data.MSSQL.Migrations;
using Sales.Data.XML;
using System.Data.SQLite;
using System.Globalization;
using System.Threading;
using System.Data;

namespace Sales
{
    public static class ParseReports
    {
        public static void PassToSql(
            IEnumerable<Sales.Models.Excel.SupermarketData> results, 
            SalesContext db, 
            SupermarketModel sql)
        {
            using (db)
            {
                foreach (var result in results)
                {
                    foreach (var row in result.Items)
                    {
                        var productName = sql.Products.Where(x => x.ID == row.Id).First().ProductName;
                        var product = db.Products.Where(x => x.Name == productName).First();
                        var supermarket = db.Supermarkets.Where(x => x.Name == result.Name).FirstOrDefault();
                        if (supermarket == null)
                        {
                            supermarket = new Supermarket();
                            supermarket.Name = result.Name;
                        }

                        db.Records.Add(new Models.MSSQL.Record
                        {
                            Quantity = row.Quantity,
                            UnitPrice = row.UnitPrice,
                            Product = product,
                            Date = result.Date,
                            Supermarket = supermarket
                        });

                        db.SaveChanges();
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
