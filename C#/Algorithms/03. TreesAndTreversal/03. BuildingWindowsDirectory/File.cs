public class CustomFile
{
    public string Name { get; set; }
    public long Size { get; set; }

    public CustomFile(string name, long size)
    {
        this.Name = name;
        this.Size = size;
    }
}

