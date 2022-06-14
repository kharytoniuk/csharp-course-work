namespace ExplorerDesktop;

public abstract class BaseEntry : IEntry
{
    public string Name { get; }
    
    public string Path { get; }

    protected BaseEntry(string name, string path)
    {
        Name = name;
        Path = path;
    }
}