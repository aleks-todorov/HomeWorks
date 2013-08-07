using System;
using System.Data.Objects;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Sales.Data.MSSQL;
using Newtonsoft.Json;
using Sales.Models.JSON;

namespace Sales
{
    public static class ProductReports
    {
        private const string DirectoryPath = "../../../Data/Product-Reports/";

        public static void Generate()
        {
            using (var db = new SalesContext())
            {
                foreach (var product in db.Products)
                {
                    var path = DirectoryPath + product.Id + ".json";

                    Debug.WriteLine("Processing: " + path);
                    using (var output = new StreamWriter(path))
                    {
                        var records = db.Records.Where(x => x.Product.Id == product.Id);

                        if (!records.Any())
                        {
                            Debug.WriteLine("  Skipping...");
                            continue;
                        }

                        var quantity = records.Sum(x => x.Quantity);

                        var serializedProduct = new Product
                        {
                            ProductId = product.Id,
                            ProductName = product.Name,
                            VendorName = product.Vendor.Name,
                            TotalQuantitySold = quantity,
                            TotalIncomes = quantity * product.BasePrice
                        };

                        var result = JsonConvert.SerializeObject(serializedProduct, Formatting.Indented);

                        output.WriteLine(result);
                        Debug.WriteLine(result);

                        // TODO: Decouple
                        Save(serializedProduct);
                    }
                }
            }
        }

        // TODO: Optimize connections
        private static void Save(Product product)
        {
            var server = new MongoClient("mongodb://localhost").GetServer();
            var db = server.GetDatabase("salesDB");
            var sales = db.GetCollection<Product>("productReports");

            sales.Insert(product);
        }
    }
}
