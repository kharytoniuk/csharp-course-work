namespace ExplorerDesktop;

public abstract class BaseEntry
{
    public string Name { get; }
    
    public string Path { get; }

    protected BaseEntry(string name, string path)
    {
        Name = name;
        Path = path;
    }

    public abstract void Create();
    
    public abstract void Delete();
}