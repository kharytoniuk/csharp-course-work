namespace ExplorerDesktop;

public class MainViewModel : BaseViewModel
{
    private readonly ViewStore _store;
    
    public BaseViewModel CurrentViewModel => _store.CurrentViewModel;
        
    public MainViewModel(ViewStore store, ViewModelFactory<EntriesViewModel> factory)
    {
        _store = store;
        
        store.Changed += () => OnPropertyChanged(nameof(CurrentViewModel));
        store.CurrentViewModel = factory();
    }
}