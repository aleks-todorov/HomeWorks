﻿using System.Linq;
using Sales.Data.MSSQL;

namespace Sales.Data.PDF
{
    public static class Generator
    {
        public static void GetPdfReport(SalesContext SqlDatabase)
        {
            var creator = new PDFCreator(@"../../../Data/Reports/");
            creator.CreatePDF("report");

            var data = (from table in SqlDatabase.Records
                join supermarkets in SqlDatabase.Supermarkets
                    on table.Supermarket.Id equals supermarkets.Id
                select table).GroupBy(x => x.Date).OrderBy(x => x.Key);

            foreach (var date in data)
            {
                creator.CreateTable(5);
                creator.AddTableHeader(date.Key.ToShortDateString(), 5);
                creator.AddColumnNames(new string[] { "Product", "Unit Price", "Quantity", "Location", "Sum" });

                foreach (var item in date)
                {

                    creator.AddContent(new string[] { item.Product.Name.ToString(), item.UnitPrice.ToString(), (item.Quantity.ToString() + " " + item.Product.Measure.ToString()), item.Supermarket.Name, (item.UnitPrice * item.Quantity).ToString() });
                }
                creator.AddCurrentSum(date.Key.ToShortDateString());
                creator.AddTable();
            }

            creator.CloseFile();
        }
    }
}