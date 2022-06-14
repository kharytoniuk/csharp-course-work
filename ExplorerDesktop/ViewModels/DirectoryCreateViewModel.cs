using System.Windows.Input;

namespace ExplorerDesktop;

public class DirectoryCreateViewModel : BaseViewModel
{
    public string Name { get; set; }

    public ICommand NavigateEntriesCommand { get; }
    
    public ICommand DirectoryCreateCommand { get; }

    public DirectoryCreateViewModel(NavigationStore navigationStore, IEntriesController controller)
    {
        NavigateEntriesCommand =
            new NavigateCommand<EntriesViewModel>(navigationStore,
                () => new EntriesViewModel(navigationStore, controller));
        
        DirectoryCreateCommand = new DirectoryCreateCommand(navigationStore, controller);
    }
}