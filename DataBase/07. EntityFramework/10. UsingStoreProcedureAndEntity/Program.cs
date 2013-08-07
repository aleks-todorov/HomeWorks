using System;
using System.Linq;
using Northwind.Data;

/* 10. Create a stored procedures in the Northwind database for finding the total 
 * incomes for given supplier name and period (start date, end date).
 * Implement a C# method that calls the stored procedure and returns the retuned record set. */

class Program
{
    static void Main(string[] args)
    {
        var supplierName = "Exotic Liquids";
        var startDate = new DateTime(1990, 1, 1);
        var endDate = new DateTime(1999, 1, 1);

        var supplierIncome = GetSupplierIncome(supplierName, startDate, endDate);

        Console.WriteLine("The total income for {0} \n in period {1} - {2} \n is: {3} USD", supplierName, startDate, endDate, supplierIncome);

    }

    static decimal? GetSupplierIncome(string supplierName, DateTime startDate, DateTime endDate)
    {
        using (var dbCon = new NorthwindEntities())
        {
            var supplierIncomes = dbCon.usp_GetSupplierIncome(supplierName, startDate, endDate);

            foreach (var supplierIncome in supplierIncomes)
            {
                return supplierIncome;
            }
        }

        return null;
    }
}


