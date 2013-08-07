using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Sales.Data.MSSQL;

namespace Sales
{
    public static class SalesReportsByVendors
    {
        private const string FilePath = "../../../Data/Sales-by-Vendors-report.xml";

        public static void Generate()
        {
            using (var db = new SalesContext())
            {
                var sales = new XElement("sales");

                foreach (var supermarket in db.Supermarkets)
                {
                    var sale = new XElement("sale");
                    sale.SetAttributeValue("vendor", supermarket.Name);

                    var records = db.Records
                        .Where(x => x.Supermarket.Id == supermarket.Id)
                        .GroupBy(x => x.Date)
                        .OrderBy(x => x.Key)
                        .Select(x => new { Date = x.Key, Sum = x.Sum(y => y.Quantity * y.UnitPrice) });

                    foreach (var record in records)
                    {
                        var summary = new XElement("summary");

                        summary.SetAttributeValue("date", record.Date.ToShortDateString());
                        summary.SetAttributeValue("total-sum", record.Sum.ToString("00"));

                        sale.Add(summary);
                    }

                    sales.Add(sale);
                }

                sales.Save(FilePath);
                //Console.WriteLine(File.ReadAllText(FilePath));
            }
        }
    }
}