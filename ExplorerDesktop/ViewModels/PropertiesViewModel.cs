using System.Windows.Input;

namespace ExplorerDesktop;

public class FilePropertiesViewModel : BaseViewModel
{
    public ICommand CancelCommand { get; }
    
    public ICommand ApplyCommand { get; }
    
    public FilePropertiesViewModel(ViewStore store, ViewModelFactory<EntriesViewModel> factory)
    {
        ApplyCommand = new NavigateCommand<EntriesViewModel>(store, factory);
        CancelCommand = new NavigateCommand<EntriesViewModel>(store, factory);
    }
}

public class DirectoryPropertiesViewModel : BaseViewModel
{
    public ICommand CancelCommand { get; }
    
    public ICommand ApplyCommand { get; }
    
    public DirectoryPropertiesViewModel(ViewStore store, ViewModelFactory<EntriesViewModel> factory)
    {
        ApplyCommand = new NavigateCommand<EntriesViewModel>(store, factory);
        CancelCommand = new NavigateCommand<EntriesViewModel>(store, factory);
    }
}