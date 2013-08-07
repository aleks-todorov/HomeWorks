using MySql.Data.MySqlClient;
using System;

class Program
{
    /* 9. Download and install MySQL database, MySQL Connector/Net 
     * (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool . 
     * Create a MySQL database to store Books (title, author, publish date and ISBN).
     * Write methods for listing all books, finding a book by name and adding a book.
     */

    private const string CONNECTION_STRING = "Server=localhost; Port=3306; Database=books; Uid=root; Pwd=root; pooling=true";

    static void Main(string[] args)
    {
        ListBooks();
        FindBook("Intro to Programming wiht C#");
        AddABook("Earle Castledine", "jQuery: Novice To Ninja");
        ListBooks();
    }

    private static void AddABook(string author, string title)
    {
        MySqlConnection dbConnection = new MySqlConnection(CONNECTION_STRING);

        dbConnection.Open();
        using (dbConnection)
        {
            MySqlCommand addBook = new MySqlCommand("INSERT INTO booksinfo (title,author) VALUES (@title, @author)", dbConnection);
            addBook.Parameters.AddWithValue("@title", title);
            addBook.Parameters.AddWithValue("@author", author);
            addBook.ExecuteNonQuery();
        }
        
    }

    private static void FindBook(string bookName)
    {
        MySqlConnection dbConnection = new MySqlConnection(CONNECTION_STRING);

        dbConnection.Open();
        using (dbConnection)
        {
            MySqlCommand listBooks = new MySqlCommand("SELECT * FROM booksinfo WHERE Title = '" + bookName + "';", dbConnection);
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
        MySqlConnection dbConnection = new MySqlConnection(CONNECTION_STRING);

        dbConnection.Open();
        using (dbConnection)
        {
            MySqlCommand listBooks = new MySqlCommand("SELECT Title FROM booksinfo;", dbConnection);
            var reader = listBooks.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
        }
        
    }
}

