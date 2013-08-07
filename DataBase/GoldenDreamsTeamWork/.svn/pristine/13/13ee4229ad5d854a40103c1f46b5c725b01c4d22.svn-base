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
using Sales.Data.Excel;
using Sales.Data.DatabaseClone;
namespace Sales
{
    public class Program
    {
        static void Main()
        {
            Debug.Listeners.Add(new ConsoleTraceListener());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SalesContext, Configuration>());
            var sqlContext = new SalesContext();
            var mySqlContext = new SupermarketModel();
            using (sqlContext)
            {
                //Problem #1 – Load Excel Reports from ZIP File
                MySqlToSql.ReadMySQL(sqlContext, mySqlContext);

                ParseExcelReport.ReadExcel(sqlContext, mySqlContext);

                //Problem #2 – Generate PDF Aggregated Sales Reports
                Generator.GetPdfReport(new SalesContext());

                //Problem #3 – Generate XML Sales Report by Vendors
                SalesReportsByVendors.Generate();

                //Problem #4 – Product Reports
                ProductReports.Generate();

                //Problem #5 – Load Vendor Expenses from XML
                SaveExpenses.Save();

                //Problem #6 – Vendors Total Report
                VendorsTotalReport.Generate();
            }
        }

        

        
    }
}
