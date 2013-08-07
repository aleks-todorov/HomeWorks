using System;
using Northwind.Data;

class Program
{
    /*4. Implement previous by using native SQL query and executing it through the DbContext.*/

    static void Main()
    {
        var db = new NorthwindEntities();

        using (db)
        {
            var query = @" SELECT
[Extent1].[ContactName] AS [ContactName]
FROM  [dbo].[Customers] AS [Extent1]
INNER JOIN [dbo].[Orders] AS [Extent2] ON [Extent1].[CustomerID] = [Extent2].[CustomerID]
WHERE ([Extent2].[OrderDate] > convert(datetime2, '1996-12-31 00:00:00.0000000', 121)) AND ([Extent2].[OrderDate] < convert(datetime2, '1998-01-01 00:00:00.0000000', 121)) AND (N'Canada' = [Extent2].[ShipCountry])";

            var customers = db.Database.SqlQuery<string>(query);

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}

