using System;
using System.Linq;
using Northwind.Data;

class Program
{
    /* 5. Write a method that finds all the sales by specified region and period (start / end dates).*/

    static void Main(string[] args)
    {
        // Use this if you want to read the input from the console
        //var startDate = DateTime.Parse(Console.ReadLine());
        //var endDate = DateTime.Parse(Console.ReadLine());
        //var region = Console.ReadLine();

        // Use this if you want to use the hardcoded values
        var startDate = new DateTime(1996, 1, 12);
        var endDate = new DateTime(1996, 12, 31);
        var region = "RJ";
        FindOrders(startDate, endDate, region);
    }

    private static void FindOrders(DateTime startDate, DateTime endDate, string region)
    {
        var db = new NorthwindEntities();
        var sales = from o in db.Orders
                    where o.OrderDate > startDate && o.OrderDate < endDate && o.ShipRegion == region
                    select o;

        PrintResults(sales);
    }

    private static void PrintResults(IQueryable<Order> sales)
    {
        foreach (var sale in sales)
        {
            Console.WriteLine("Order ID: {0}", sale.OrderID);
        }
    }
}

