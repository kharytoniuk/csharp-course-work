using System;
using System.Collections.Generic;
using System.IO;
using ExplorerDesktop.Domain;

namespace ExplorerDesktop;

public class EntriesRepository : IRepository<BaseEntry>
{
    private readonly EntryStore _store;
    
    public EntriesRepository(EntryStore store)
    {
        _store = store;
    }
    
    public IEnumerable<BaseEntry> GetAll()
    {
        var entries = new List<BaseEntry>();
        var directoryInfo = new DirectoryInfo(_store.Current.Path);
        
        foreach (var directory in directoryInfo.EnumerateDirectories())
        {
            if ((directory.Attributes & FileAttributes.ReparsePoint) == 0)
            {
                entries.Add(new Directory(directory.Name, directory.FullName));
            }
        }
        
        foreach (var file in directoryInfo.EnumerateFiles())
        {
            if ((file.Attributes & FileAttributes.ReparsePoint) == 0)
            {
                entries.Add(new File(file.Name, file.FullName));
            }
        }

        return entries;
    }

    public BaseEntry Get(string key)
    {
        throw new NotImplementedException();
    }

    public void Create(BaseEntry entry)
    {
        if (entry is Directory)
        {
            System.IO.Directory.CreateDirectory(entry.Path);
        }
        else if (entry is File)
        {
            System.IO.File.Create(entry.Path).Close();
        }
    }

    public void Delete(BaseEntry entry)
    {
        if (entry is Directory)
        {
            System.IO.Directory.Delete(entry.Path);
        }
        else if (entry is File)
        {
            System.IO.File.Delete(entry.Path);
        }
    }

    public void Update(string key, BaseEntry entry)
    {
        throw new NotImplementedException();
    }
}