namespace ExplorerDesktop;

public class ShowPropertiesCommand : BaseCommand
{
    private readonly ViewStore _store;
    private readonly ViewModelFactory<FilePropertiesViewModel> _filePropertyViewFactory;
    private readonly ViewModelFactory<DirectoryPropertiesViewModel> _directoryPropertyViewFactory;

    public ShowPropertiesCommand(ViewStore store, 
        ViewModelFactory<FilePropertiesViewModel> filePropertyViewFactory, 
        ViewModelFactory<DirectoryPropertiesViewModel> directoryPropertyViewFactory)
    {
        _store = store;
        _filePropertyViewFactory = filePropertyViewFactory;
        _directoryPropertyViewFactory = directoryPropertyViewFactory;
    }

    public override void Execute(object? parameter)
    {
        if (parameter is Directory)
        {
            _store.CurrentViewModel = _directoryPropertyViewFactory();
        }
        else if (parameter is File)
        {
            _store.CurrentViewModel = _filePropertyViewFactory();
        }
    }
}