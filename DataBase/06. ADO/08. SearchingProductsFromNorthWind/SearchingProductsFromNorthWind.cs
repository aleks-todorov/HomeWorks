using System;
using System.Data.SqlClient;

class Program
{
    /*8. Write a program that reads a string from the console and finds all products that 
     * contain this string. Ensure you handle correctly characters like ', %, ", \ and _.
     */

    private const string CONECTION_STRING = "Server=ALEKS-PC; " +
           "Database=NORTHWND; Integrated Security=true";

    static void Main()
    {
        Console.WriteLine("Enter search criteria");
        var searchCriteria = Console.ReadLine().Replace("%", "[%]").Replace("_", "[_]");

        SqlConnection dbCon = new SqlConnection(CONECTION_STRING);

        dbCon.Open();
        using (dbCon)
        {
            SqlCommand searchCmd = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName like @searchCriteria GROUP BY ProductName", dbCon);
            searchCmd.Parameters.AddWithValue("@searchCriteria", "%" + searchCriteria + "%");

            var reader = searchCmd.ExecuteReader();

            while (reader.Read())
            {
                var productName = (string)reader["ProductName"];
                Console.WriteLine(productName);
            }
        }
    }
}
