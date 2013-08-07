using System;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using Sales.Data.MSSQL;
using Sales.Data.XML;
using Sales.Models.JSON;

namespace Sales
{
    public static class SaveExpenses
    {
        public static void Save()
        {
            var expenses = ParseExpenses.Read("../../../Data/expenses.xml");

            {
                var server = new MongoClient("mongodb://localhost").GetServer();
                var db = server.GetDatabase("salesDB");
                var sales = db.GetCollection<Expenses>("vendorExpenses");

                sales.InsertBatch(expenses);
            }

            using (var db = new SalesContext())
            {
                foreach (var expense in expenses)
                {
                    var vendor = db.Vendors.FirstOrDefault(x => x.Name == expense.Vendor);

                    if (vendor == null)
                    {
                        continue;
                    }

                    foreach (var item in expense.List)
                    {
                        vendor.Expenses.Add(new Models.MSSQL.Expenses
                        {
                            DateTime = item.Key,
                            Money = item.Value
                        });
                    }
                }

                db.SaveChanges();
            }
        }
    }
}
