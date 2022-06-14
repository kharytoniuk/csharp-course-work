using System;
using System.Windows.Input;

namespace ExplorerDesktop;

public class CreateViewModel<TEntry> : BaseViewModel
    where TEntry : BaseEntry
{
    public string Name { get; set; }

    public ICommand NavigateEntriesCommand { get; }
    
    public ICommand CreateCommand { get; }

    public CreateViewModel(NavigationStore navigationStore, IEntriesController controller, Func<string, string, TEntry> instance)
    {
        NavigateEntriesCommand =
            new NavigateCommand<EntriesViewModel>(navigationStore,
                () => new EntriesViewModel(navigationStore, controller));
        
        CreateCommand = new CreateCommand<TEntry>(navigationStore, controller, instance);
    }
}

public class CreateDirectoryViewModel : CreateViewModel<Directory>
{
    public CreateDirectoryViewModel(NavigationStore navigationStore, IEntriesController controller)
        : base(navigationStore, controller, (name, path) => new Directory(name, path))
    {
    }
}

public class CreateFileViewModel : CreateViewModel<File>
{
    public CreateFileViewModel(NavigationStore navigationStore, IEntriesController controller)
        : base(navigationStore, controller, (name, path) => new File(name, path))
    {
    }
}