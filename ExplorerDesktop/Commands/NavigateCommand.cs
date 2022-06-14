using System;

namespace ExplorerDesktop;

public class NavigateCommand<TViewModel> : BaseCommand
    where TViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly Func<TViewModel> _instance;
    
    public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> instance)
    {
        _navigationStore = navigationStore;
        _instance = instance;
    }
    
    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = _instance();
    }
}