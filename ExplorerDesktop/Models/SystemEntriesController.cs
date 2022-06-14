using System;
using System.Collections.Generic;

namespace ExplorerDesktop;

public class SystemEntriesController : IEntriesController
{
    public event Action? Changed;

    public Directory Current { get; private set; }

    public IEnumerable<BaseEntry> Entries => Current.GetEntries();
    
    public SystemEntriesController()
    {
        Current = new Directory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile,
            Environment.SpecialFolderOption.None));
    }

    public void Open(BaseEntry entry)
    {
        if (entry is Directory directory)
        {
            Current = directory;
        }
        else if (entry is File file)
        {
            file.Execute();
        }
        
        Changed?.Invoke();
    }

    public void Create(BaseEntry entry)
    {
        entry.Create();
        Changed?.Invoke();
    }

    public void Delete(BaseEntry entry)
    {
        entry.Delete();
        Changed?.Invoke();
    }
}