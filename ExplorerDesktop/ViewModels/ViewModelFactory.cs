namespace ExplorerDesktop;

public delegate TViewModel ViewModelFactory<TViewModel>() where TViewModel : BaseViewModel;