using System.Collections.Generic;
using System.IO;

class CustomFolder
{
    public string Name { get; set; }
    public List<CustomFile> Files { get; set; }
    public List<CustomFolder> ChildFolders { get; set; }
    public long Size { get; set; }

    public CustomFolder(string name)
    {
        this.Name = name;
        this.Files = new List<CustomFile>();
        this.ChildFolders = new List<CustomFolder>();
        this.Size = 0;
    }
     
    public void AddFile(CustomFile file)
    {
        this.Files.Add(file);
    }

    public void AddFolder(CustomFolder dir)
    {
        this.ChildFolders.Add(dir);
    }
}

