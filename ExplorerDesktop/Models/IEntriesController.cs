using System;
using System.Collections.Generic;

namespace ExplorerDesktop;

public interface IEntriesController
{
    public event Action? Changed;
    
    public Directory Current { get; }
    
    public IEnumerable<BaseEntry> Entries { get; }

    public void Open(BaseEntry entry);
    
    public void Create(BaseEntry entry);

    public void Delete(BaseEntry entry);

}