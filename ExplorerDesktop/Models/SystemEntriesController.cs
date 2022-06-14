using System;
using System.Collections.Generic;

namespace ExplorerDesktop;

public class SystemEntriesController : IEntriesController
{
    private Directory _current;
    public event Action? Changed;

    public Directory Current => _current;

    public IEnumerable<IEntry> Entries => _current.GetEntries();
    
    public SystemEntriesController()
    {
        _current = new Directory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile,
            Environment.SpecialFolderOption.None));
    }

    public void Open(IEntry entry)
    {
        if (entry is Directory directory)
        {
            _current = directory;
        }
        else if (entry is File file)
        {
            file.Execute();
        }
        
        Changed?.Invoke();
    }

    public void Create(IEntry entry)
    {
        if (entry is Directory directory)
        {
            System.IO.Directory.CreateDirectory(directory.Path);
        }
        else if (entry is File file)
        {
            System.IO.File.Create(file.Path);
        }
        
        Changed?.Invoke();
    }

    public void Delete(IEntry entry)
    {
        if (entry is Directory directory)
        {
            System.IO.Directory.Delete(directory.Path);
        }
        else if (entry is File file)
        {
            System.IO.File.Delete(file.Path);
        }
        
        Changed?.Invoke();
    }
}