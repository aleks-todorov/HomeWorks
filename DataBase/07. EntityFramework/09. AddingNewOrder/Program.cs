using System;
using Northwind.Data;
using System.Transactions;

class Program
{
    /* 9. Create a method that places a new order in the Northwind database.
     * The order should contain several order items. Use transaction to ensure the data consistency.*/

    static void Main(string[] args)
    {
        using (var scope = new TransactionScope())
        {
            InsertMultiple();

            scope.Complete();
        }
    }

    static void InsertOrder(
    string shipName, string shipAddress,
    string shipCity, string shipRegion,
    string shipPostalCode, string shipCountry,
    string customerID = null, int? employeeID = null,
    DateTime? orderDate = null, DateTime? requiredDate = null,
    DateTime? shippedDate = null, int? shipVia = null,
    decimal? freight = null)
    {
        using (var context = new NorthwindEntities())
        {
            Order newOrder = new Order
            {
                ShipAddress = shipAddress,
                ShipCity = shipCity,
                ShipCountry = shipCountry,
                ShipName = shipName,
                ShippedDate = shippedDate,
                ShipPostalCode = shipPostalCode,
                ShipRegion = shipRegion,
                ShipVia = shipVia,
                EmployeeID = employeeID,
                OrderDate = orderDate,
                RequiredDate = requiredDate,
                Freight = freight,
                CustomerID = customerID
            };

            context.Orders.Add(newOrder);

            context.SaveChanges();

            Console.WriteLine("Order performed");
        }
    }

    static void InsertMultiple()
    {
        for (int i = 0; i < 10; i++)
        {
            InsertOrder(null, null, null, null, null, null, null, null, null, DateTime.Now, null, null, null);
        }
    }
}
