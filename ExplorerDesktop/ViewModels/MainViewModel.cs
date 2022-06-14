namespace ExplorerDesktop;

public class MainViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly IEntriesController _controller;

    public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        
    public MainViewModel(NavigationStore navigationStore, IEntriesController controller)
    {
        _navigationStore = navigationStore;
        _controller = controller;

        navigationStore.Changed += () => OnPropertyChanged(nameof(CurrentViewModel));
        navigationStore.CurrentViewModel = new EntriesViewModel(navigationStore, controller);
    }
}