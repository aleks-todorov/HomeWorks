using System;
using System.Data.OleDb;
using System.Linq;

class Program
{
    private const string CONNECTION_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= ..\\..\\Example.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";

    static void Main(string[] args)
    {
        ListContent();
        InsertRow("Pesho", 30);
        ListContent();
    }

    private static void ListContent()
    {
        /*6. Create an Excel file with 2 columns: name and score: 
         * Write a program that reads your MS Excel file through the OLE DB 
         * data provider and displays the name and score row by row.
         */

        OleDbConnection dbConn = new OleDbConnection(CONNECTION_STRING);
        dbConn.Open();
        using (dbConn)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Results$]", dbConn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var name = (string)reader["Name"];
                var score = (double)reader["Score"];
                Console.WriteLine("{0} - {1}", name, score);
            }
        }
    }

    static void InsertRow(string name, double score)
    {
        /*7. Implement appending new rows to the Excel file. */

        OleDbConnection dbConn = new OleDbConnection(CONNECTION_STRING);
        dbConn.Open();
        using (dbConn)
        {
            OleDbCommand insertIntoExcell = new OleDbCommand("INSERT INTO [Results$] (Name,Score) VALUES (@Name,@Score)", dbConn);

            insertIntoExcell.Parameters.AddWithValue("@Name", name);
            insertIntoExcell.Parameters.AddWithValue("@Score", score);
            insertIntoExcell.ExecuteNonQuery();

        }

    }
}

