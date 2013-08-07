using Sales.Data.MSSQL;
using Sales.Models.MSSQL;
using SupermarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sales.Data.Excel
{
    public static class ParseExcelReport
    {
        public static void ReadExcel(SalesContext db, SupermarketModel sql)
        {
            var results =
                new ReadExcelReports("../../../Data/Sample-Sales-Reports.zip", "../../../Temp/ExcelReports/").Extract().Read();

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
            Directory.Delete("../../../Temp/", true);
        }
    }
}
