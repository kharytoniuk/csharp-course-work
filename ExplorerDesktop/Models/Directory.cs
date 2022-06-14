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

    public override void Create()
    {
        System.IO.Directory.CreateDirectory(Path);
    }

    public override void Delete()
    {
        System.IO.Directory.Delete(Path);
    }

    public IEnumerable<BaseEntry> GetEntries()
    {
        var entries = new List<BaseEntry>();
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