using Northwind.Data;

class Program
{
    /* 6. Create a database called NorthwindTwin with the same structure as 
     * Northwind using the features from DbContext. Find for the API for schema generation in MSDN or in Google.*/

    static void Main(string[] args)
    {
        var con = new NorthwindEntities();
        con.Database.CreateIfNotExists();
    }
}

