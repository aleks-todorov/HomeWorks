using System;
using System.Linq;
using System.IO;
using Northwind.Data;

namespace PDFCreator.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var creator = new PDFCreator.Classes.PDFCreator(Directory.GetCurrentDirectory());
            creator.CreatePDF("testPDF");

            var dbCon = new NorthwindEntities();

            using (dbCon)
            {
                var products = from product in dbCon.Products
                               join supplier in dbCon.Suppliers
                               on product.SupplierID equals supplier.SupplierID
                               where product.ProductID < 25
                               select product;

                creator.CreateTable(5);
                creator.AddTableHeader(DateTime.Now.ToString(), 5);
                creator.AddColumnNames(new string[] { "ProductID", "ProductName", "Price", "Quantity", "SuplierName" });

                foreach (var product in products)
                {
                    creator.AddContent(new string[] { product.ProductID.ToString(), product.ProductName, product.UnitPrice.ToString(), product.QuantityPerUnit, product.Supplier.CompanyName });
                }

                creator.AddTable();

                creator.CreateTable(5);
                creator.AddTableHeader(DateTime.Now.ToString(), 5);
                creator.AddColumnNames(new string[] { "ProductID", "ProductName", "Price", "Quantity", "SuplierName" });

                foreach (var product in products)
                {
                    creator.AddContent(new string[] { product.ProductID.ToString(), product.ProductName, product.UnitPrice.ToString(), product.QuantityPerUnit, product.Supplier.CompanyName });
                }

                creator.AddTable();

                creator.CloseFile();
            }
        }
    }
}
