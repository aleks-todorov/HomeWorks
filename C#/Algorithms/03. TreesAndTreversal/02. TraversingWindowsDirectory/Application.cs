using System;
using System.IO;


class Application
{
    /* Task 2: 
     * Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively
     * and to display all files matching the mask *.exe. Use the class System.IO.Directory.
     */

    static void Main(string[] args)
    {
        var startPath = @"C:\Windows";
        TreverseDirectories(new DirectoryInfo(startPath));
    }

    private static void TreverseDirectories(DirectoryInfo dir)
    {
        var folders = dir.GetDirectories();
        var files = dir.GetFiles();

        try
        {
            foreach (var file in files)
            {
                if (file.Name.EndsWith(".exe"))
                {
                    Console.WriteLine(file.Name);
                }
            }

            foreach (var child in folders)
            {
                TreverseDirectories(child);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Access denied! ");
        }
    }
}
