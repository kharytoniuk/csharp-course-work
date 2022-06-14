using System.Collections.Generic;
using System.IO;

namespace ExplorerDesktop;

public class Directory : BaseEntry
{
    public Directory(string name, string path) 
        : base(name, path)
    {
    }

    public Directory(string path)
        : base(System.IO.Path.GetDirectoryName(path) ?? string.Empty, path)
    {
        
    }
    
    public IEnumerable<IEntry> GetEntries()
    {
        var entries = new List<IEntry>();
        var directoryInfo = new DirectoryInfo(Path);

        foreach (var directory in directoryInfo.GetDirectories())
        {
            entries.Add(new Directory(directory.Name, directory.FullName));
        }

        foreach (var file in directoryInfo.GetFiles())
        {
            entries.Add(new File(file.Name, file.FullName));
        }
        
        return entries;
    }
}