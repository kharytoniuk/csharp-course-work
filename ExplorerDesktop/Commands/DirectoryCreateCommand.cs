using System.IO;

namespace ExplorerDesktop;

public class DirectoryCreateCommand : BaseCommand
{
    private readonly NavigationStore _navigationStore;
    private readonly IEntriesController _controller;
    
    public DirectoryCreateCommand(NavigationStore navigationStore, IEntriesController controller)
    {
        _navigationStore = navigationStore;
        _controller = controller;
    }
    
    public override void Execute(object? parameter)
    {
        var name = (string)(parameter ?? string.Empty);
        var directory = new Directory(name, Path.Combine(_controller.Current.Path, name));
        
        _controller.Create(directory);
        _navigationStore.CurrentViewModel = new EntriesViewModel(_navigationStore, _controller);
    }
}