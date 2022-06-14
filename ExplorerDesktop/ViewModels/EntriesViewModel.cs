using System.Collections.Generic;
using System.Windows.Input;

namespace ExplorerDesktop;

public class EntriesViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly IEntriesController _controller;
    
    public ICommand OpenCommand { get; }

    public ICommand DeleteCommand { get; }
    
    public ICommand CreateDirectoryCommand { get; }
    
    public ICommand CreateFileCommand { get; }
    
    public IEnumerable<BaseEntry> Entries => _controller.Entries;

    public EntriesViewModel(NavigationStore navigationStore, IEntriesController controller)
    {
        _navigationStore = navigationStore;
        _controller = controller;
        _controller.Changed += () => OnPropertyChanged(nameof(Entries));

        OpenCommand = new ActionCommand<BaseEntry>(_controller.Open);
        DeleteCommand = new ActionCommand<BaseEntry>(_controller.Delete);
        
        CreateDirectoryCommand = new NavigateCommand<CreateDirectoryViewModel>(navigationStore,
            () => new CreateDirectoryViewModel(navigationStore, controller));
        
        CreateFileCommand = new NavigateCommand<CreateFileViewModel>(navigationStore,
            () => new CreateFileViewModel(navigationStore, controller));
    }
}