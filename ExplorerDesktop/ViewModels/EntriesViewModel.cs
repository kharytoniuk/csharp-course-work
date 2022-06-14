using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors.Core;

namespace ExplorerDesktop;

public class EntriesViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly IEntriesController _controller;
    
    public ICommand OpenCommand { get; }

    public ICommand DeleteCommand { get; }
    
    public ICommand NavigateDirectoryCreateCommand { get; }
    
    public IEnumerable<IEntry> Entries => _controller.Entries;

    public EntriesViewModel(NavigationStore navigationStore, IEntriesController controller)
    {
        _navigationStore = navigationStore;
        _controller = controller;
        _controller.Changed += () => OnPropertyChanged(nameof(Entries));
        
        OpenCommand = new ActionCommand(o => _controller.Open((IEntry)o));
        DeleteCommand = new ActionCommand(o => _controller.Open((IEntry)o));

        NavigateDirectoryCreateCommand = new NavigateCommand<DirectoryCreateViewModel>(navigationStore,
            () => new DirectoryCreateViewModel(navigationStore, controller));
    }
}