using System;
using System.Data.SQLite;

class Program
{
    /*10. Re-implement the previous task with SQLite embedded DB (see http://sqlite.phxsoftware.com).*/
     
    private const string CONNECTION_STRING = "Data Source= ..\\..\\Books.db; Version=3";

    static void Main(string[] args)
    {
        ListBooks();
        FindBook("Intro to Programming wiht C#");
        AddABook("Earle Castledine", "jQuery: Novice To Ninja");
        ListBooks();
    }

    private static void AddABook(string author, string title)
    {
        SQLiteConnection dbConnection = new SQLiteConnection(CONNECTION_STRING);

        dbConnection.Open();
        using (dbConnection)
        {
            SQLiteCommand addBook = new SQLiteCommand("INSERT INTO booksinfo (title,author) VALUES (@title, @author)", dbConnection);
            addBook.Parameters.AddWithValue("@title", title);
            addBook.Parameters.AddWithValue("@author", author);
            addBook.ExecuteNonQuery();
        }
    }

    private static void FindBook(string bookName)
    {
        SQLiteConnection dbConnection = new SQLiteConnection(CONNECTION_STRING);

        dbConnection.Open();
        using (dbConnection)
        {
            SQLiteCommand listBooks = new SQLiteCommand("SELECT * FROM booksinfo WHERE Title = '" + bookName + "';", dbConnection);
            var reader = listBooks.ExecuteReader();

            while (reader.Read())
            {
                string author = (string)reader["Author"];
                Console.WriteLine("{0} - {1}", bookName, author);
            }
        }
    }

    private static void ListBooks()
    {
        SQLiteConnection dbConnection = new SQLiteConnection(CONNECTION_STRING);

        dbConnection.Open();
        using (dbConnection)
        {
            SQLiteCommand listBooks = new SQLiteCommand("SELECT Title FROM booksinfo;", dbConnection);
            var reader = listBooks.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
        }
    }
}

