using System;
using MongoDB.Driver;

class Program
{
    /* 01. Write a simple "Dictionary" application in C# or JavaScript to perform the following in MongoDB:
           Add a dictionary entry (word + translation)
           List all words and their translations
           Find the translation of given word*/

    static void Main(string[] args)
    {
        var connectionStr = "mongodb://localhost";
        var client = new MongoClient(connectionStr);
        var server = client.GetServer();
        var db = server.GetDatabase("MongoDictionary");
        MongoCollection<Word> dictionaryCollection = db.GetCollection<Word>("Words");

        MongoDictionary mongoDictionary = new MongoDictionary(dictionaryCollection);

        UI.DrawMenu();

        while (true)
        {
            Console.Write("Please enter a command: ");
            string command = Console.ReadLine().Trim();

            if (command == "Exit")
            {
                break;
            }

            Engine.ParseCommand(command, mongoDictionary);
        }
    }
}

