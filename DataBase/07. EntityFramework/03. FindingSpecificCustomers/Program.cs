using System;
using System.Linq;
using Northwind.Data;

class Program
{
    /* 3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.*/

    static void Main(string[] args)
    {
        var db = new NorthwindEntities();

        using (db)
        {
            var customers = from customer in db.Customers
                            join orders in db.Orders
                            on customer.CustomerID equals orders.CustomerID
                            where orders.OrderDate > new DateTime(1996, 12, 31) && orders.OrderDate < new DateTime(1998, 1, 1)
                            where orders.ShipCountry == "Canada" 
                            select customer.ContactName;

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }

        }
    }
}

