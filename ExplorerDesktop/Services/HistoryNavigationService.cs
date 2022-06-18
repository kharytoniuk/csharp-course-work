using System.Collections.Generic;

namespace ExplorerDesktop;

public class HistoryNavigationService
{
    private readonly EntryStore _store;
    private readonly Stack<Directory> _previous = new();
    private readonly Stack<Directory> _next = new();

    public Directory Current => _store.Current;
    
    public HistoryNavigationService(EntryStore store)
    {
        _store = store;
        _store.Current = new Directory("Default", @"C:\");
    }

    public void Add(Directory directory)
    {
        _previous.Push(_store.Current);
        _store.Current = directory;
    }
    
    public bool CanMoveBack()
    {
        return _previous.Count != 0;
    }
    
    public bool CanMoveForward()
    {
        return _next.Count != 0;
    }
    
    public void MoveBack()
    {
        var previous = _previous.Pop();
        _next.Push(_store.Current);
        _store.Current = previous;
    }
    
    public void MoveForward()
    {
        var next = _next.Pop();
        _previous.Push(_store.Current);
        _store.Current = next;
    }
}