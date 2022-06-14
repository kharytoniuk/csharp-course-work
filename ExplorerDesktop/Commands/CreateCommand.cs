using System;
using System.IO;

namespace ExplorerDesktop;

public class CreateCommand<TEntry> : BaseCommand
    where TEntry : BaseEntry
{
    private readonly NavigationStore _navigationStore;
    private readonly IEntriesController _controller;
    private readonly Func<string, string, TEntry> _instance;
    
    public CreateCommand(NavigationStore navigationStore, IEntriesController controller, Func<string, string, TEntry> instance)
    {
        _navigationStore = navigationStore;
        _controller = controller;
        _instance = instance;
    }
    
    public override void Execute(object? parameter)
    {
        var name = (string)(parameter ?? string.Empty);
        var path = Path.Combine(_controller.Current.Path, name);
        
        _controller.Create(_instance(name, path));
        _navigationStore.CurrentViewModel = new EntriesViewModel(_navigationStore, _controller);
    }
}