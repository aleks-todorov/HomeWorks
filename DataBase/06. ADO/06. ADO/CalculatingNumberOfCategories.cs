using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;

class NorthWindActions
{
    //You have to edit the connection string to work for your machine and SQL Server
    private const string CONECTION_STRING = "Server=ALEKS-PC; " +
            "Database=NORTHWND; Integrated Security=true";

    static void Main(string[] args)
    {
        SqlConnection dbCon = new SqlConnection(CONECTION_STRING);

        dbCon.Open();
        using (dbCon)
        {

            /* 1. Write a program that retrieves from the Northwind sample database in
             * MS SQL Server the number of  rows in the Categories table.
             */

            SqlCommand cmdCount = new SqlCommand(
                "SELECT COUNT(*) FROM Categories", dbCon);
            int categoriesCount = (int)cmdCount.ExecuteScalar();
            Console.WriteLine("Categories count: {0} ", categoriesCount);
            Console.WriteLine();

            /* 2. Write a program that retrieves the name and description of all categories in the Northwind DB.*/

            Console.WriteLine("CategoryName - Description");
            SqlCommand cmdAllCategoriesInfo = new SqlCommand(
              "SELECT c.CategoryName, c.Description FROM Categories c", dbCon);
            SqlDataReader reader = cmdAllCategoriesInfo.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    Console.WriteLine("{0} - {1}", name, description);
                }
            }
            Console.WriteLine();

            /* 3. Write a program that retrieves from the Northwind database 
             * all product categories and the names of the products in each category. 
             * Can you do this with a single SQL query (with table join)? */

            Console.WriteLine("CategoryName - ProductName");
            SqlCommand cmdProductsAndCategories = new SqlCommand(
"SELECT p.ProductName, c.CategoryName" +
" FROM Products p" +
" JOIN Categories c" +
" ON p.CategoryID=c.CategoryID", dbCon);
            reader = cmdProductsAndCategories.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("{0} - {1}", categoryName, productName);
                }
            }

            /* 4. Write a method that adds a new product in the products table in
             * the Northwind database. Use a parameterized SQL command.*/

            SqlCommand cmdInsertProducts = new SqlCommand(
           "INSERT INTO Products(ProductName, Discontinued) " +
           "VALUES (@name, @discontinued)", dbCon);
            cmdInsertProducts.Parameters.AddWithValue("@name", "Musaka");
            cmdInsertProducts.Parameters.AddWithValue("@discontinued", "false");
            cmdInsertProducts.ExecuteNonQuery();

            /* 5. Write a program that retrieves the images for all categories in the 
             * Northwind database and stores them as JPG files in the file system.*/

            int[] imageIds = ListImageIdsFromDB();

            for (int i = 0; i < imageIds.Length; i++)
            {
                int firstImageId = imageIds[0];
                byte[] imageFromDB;
                ExtractImageFromDB(firstImageId,
                    out imageFromDB);
                var picDest = @"..\..\Images\pic" + i + "-from-db.png";
                WriteBinaryFile(picDest, imageFromDB);
            }

            Console.WriteLine("\nExtracted images from the DB.");
        }
    }


    private static string GetImageFormat(string fileName)
    {
        FileInfo fileInfo = new FileInfo(fileName);
        string fileExtenstion = fileInfo.Extension;
        string imageFormat = fileExtenstion.ToLower().Substring(1);
        return imageFormat;
    }

    private static int[] ListImageIdsFromDB()
    {
        SqlConnection dbCon = new SqlConnection(CONECTION_STRING);
        dbCon.Open();
        using (dbCon)
        {
            SqlCommand cmd = new SqlCommand(
                 "Select c.Picture, c.CategoryID From Categories c", dbCon);
            ArrayList imageIds = new ArrayList();
            SqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    int imageId = (int)reader["CategoryID"];
                    imageIds.Add(imageId);
                }
            }

            int[] imageIdArray = (int[])imageIds.
                ToArray(typeof(int));
            return imageIdArray;
        }
    }

    private static void ExtractImageFromDB(
        int imageId, out byte[] image)
    {
        SqlConnection dbCon = new SqlConnection(CONECTION_STRING);
        dbCon.Open();
        using (dbCon)
        {
            SqlCommand cmd = new SqlCommand(
                "Select c.Picture, c.CategoryID From Categories c", dbCon);
            SqlParameter paramId = new SqlParameter(
                "@id", SqlDbType.Int);
            paramId.Value = imageId;
            cmd.Parameters.Add(paramId);
            SqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    image = (byte[])reader["Picture"];

                }
                else
                {
                    throw new Exception(
                        String.Format("Invalid image ID={0}.", imageId));
                }
            }
        }
    }

    private static void WriteBinaryFile(string fileName,
       byte[] fileContents)
    {
        FileStream stream = File.OpenWrite(fileName);
        using (stream)
        {
            stream.Write(fileContents, 0, fileContents.Length);
        }
    }
}