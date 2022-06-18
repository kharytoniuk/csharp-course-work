namespace ExplorerDesktop;

public class NavigateCommand<TViewModel> : BaseCommand
    where TViewModel : BaseViewModel
{
    private readonly ViewStore _store;
    private readonly ViewModelFactory<TViewModel> _factory;

    public NavigateCommand(ViewStore store, ViewModelFactory<TViewModel> factory)
    {
        _store = store;
        _factory = factory;
    }
    
    public override void Execute(object? parameter)
    {
        _store.CurrentViewModel = _factory();
    }
}