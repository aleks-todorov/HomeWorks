using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Application
{
    /*Task 3: Define classes File { string name, int size } and 
     * Folder { string name, File[] files, Folder[] childFolders } and using them build a tree keeping 
     * all files and folders on the hard drive starting from C:\WINDOWS. Implement a method that calculates 
     * the sum of the file sizes in given subtree of the tree and test it accordingly. Use recursive DFS traversal.
     */

    static List<CustomFolder> folderStructure = new List<CustomFolder>();

    static void Main(string[] args)
    {
        var startPath = @"C:\Windows";
        TreverseDir(new DirectoryInfo(startPath));

        var programFiles = GetFolder("Windows");
        Console.WriteLine("\nThe size of {0} is: {1} bytes!\n", programFiles.Name, GetSize(programFiles));
    }

    public static long GetSize(CustomFolder folder)
    {
        foreach (var file in folder.Files)
        {
            folder.Size += file.Size;
        }

        foreach (var currentFolder in folder.ChildFolders)
        {
            GetSize(currentFolder);
        }

        return folder.Size;
    }

    private static CustomFolder GetFolder(string name)
    {
        foreach (var folder in folderStructure)
        {
            if (folder.Name == name)
            {
                return folder;
            }
        }

        throw new ArgumentException("Folder was not found");
    }

    private static void TreverseDir(DirectoryInfo dir)
    {

        var currentFolder = new CustomFolder(dir.Name);
        folderStructure.Add(currentFolder);
        var folders = dir.GetDirectories();
        var files = dir.GetFiles();

        try
        {
            foreach (var file in files)
            {
                var currentFile = new CustomFile(file.Name, file.Length);
                currentFolder.AddFile(currentFile);
            }

            foreach (var folder in folders)
            {
                var childFolder = new CustomFolder(folder.Name);

                currentFolder.AddFolder(childFolder);
                TreverseDir(folder);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Access denied! ");
        }
    }
}
