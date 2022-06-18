using System.Windows.Input;
using ExplorerDesktop.Domain;

namespace ExplorerDesktop;

public class CreateDirectoryViewModel : BaseViewModel
{
    public ICommand CancelCommand { get; }
    
    public ICommand CreateCommand { get; }
    
    public CreateDirectoryViewModel(ViewStore store,
        HistoryNavigationService service, 
        IRepository<BaseEntry> repository,
        ViewModelFactory<EntriesViewModel> factory)
    {
        CreateCommand =
            new CreateCommand<Directory>(store, service, repository, (name, path) => new Directory(name, path), factory);

        CancelCommand = new NavigateCommand<EntriesViewModel>(store, factory);
    }
}

public class CreateFileViewModel : BaseViewModel
{
    public ICommand CancelCommand { get; }
    
    public ICommand CreateCommand { get; }
    
    public CreateFileViewModel(ViewStore store,
        HistoryNavigationService service, 
        IRepository<BaseEntry> repository,
        ViewModelFactory<EntriesViewModel> factory)
    {
        CreateCommand =
            new CreateCommand<File>(store, service, repository, (name, path) => new File(name, path), factory);

        CancelCommand = new NavigateCommand<EntriesViewModel>(store, factory);
    }
}