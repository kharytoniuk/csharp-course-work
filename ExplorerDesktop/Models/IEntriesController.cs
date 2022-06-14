using System;
using System.Collections.Generic;

namespace ExplorerDesktop;

public interface IEntriesController
{
    public event Action? Changed;
    
    public Directory Current { get; }
    
    public IEnumerable<IEntry> Entries { get; }
    
    public void Open(IEntry entry);
    
    public void Create(IEntry entry);

    public void Delete(IEntry entry);
}