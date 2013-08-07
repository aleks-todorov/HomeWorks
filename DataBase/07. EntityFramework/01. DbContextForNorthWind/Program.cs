using System;
using System.Linq;
using Northwind.Data;

class Program
{
    /* 1. Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database*/

    static void Main(string[] args)
    {
        using (var db = new NorthwindEntities())
        {
            var customers = db.Customers
                                .Where(c => c.Country == "UK")
                                .OrderBy(x => x.ContactName)
                                .Select(x => x.ContactName);

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}

