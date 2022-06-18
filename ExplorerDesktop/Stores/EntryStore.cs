using System;

namespace ExplorerDesktop;

public class EntryStore
{
    private Directory _current;
    public Action? Changed;

    public Directory Current
    {
        get => _current;
        set
        {
            _current = value;
            Changed?.Invoke();
        }
    }
}