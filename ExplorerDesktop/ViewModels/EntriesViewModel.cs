using System.Collections.ObjectModel;
using System.Windows.Input;
using ExplorerDesktop.Domain;

namespace ExplorerDesktop;

public class EntriesViewModel : BaseViewModel
{
    private readonly ViewStore _viewStore;
    private readonly HistoryNavigationService _historyNavigationService;
    private readonly IRepository<BaseEntry> _entriesRepository;
    private readonly ViewModelFactory<CreateDirectoryViewModel> _createDirectoryViewModelFactory;
    private readonly ViewModelFactory<CreateFileViewModel> _createFileViewModelFactory;
    private readonly ViewModelFactory<FilePropertiesViewModel> _filePropertiesViewModelFactory;
    private readonly ViewModelFactory<DirectoryPropertiesViewModel> _directoryPropertiesViewModelFactory;
    
    public ICommand OpenCommand { get; }

    public ICommand DeleteCommand { get; }
    
    public BaseCommand MoveBackCommand { get; }
    
    public BaseCommand MoveForwardCommand { get; }
    
    public ICommand CreateDirectoryCommand { get; }
    
    public ICommand CreateFileCommand { get; }
    
    public ICommand ShowPropertiesCommand { get; }

    public ObservableCollection<BaseEntry> Entries => new(_entriesRepository.GetAll());

    public EntriesViewModel(ViewStore viewStore,
        HistoryNavigationService historyNavigationService, 
        IRepository<BaseEntry> entriesRepository, 
        ViewModelFactory<CreateDirectoryViewModel> createDirectoryViewModelFactory, 
        ViewModelFactory<CreateFileViewModel> createFileViewModelFactory,
        ViewModelFactory<FilePropertiesViewModel> filePropertiesViewModelFactory,
        ViewModelFactory<DirectoryPropertiesViewModel> directoryPropertiesViewModelFactory)
    {
        _viewStore = viewStore;
        _historyNavigationService = historyNavigationService;
        _entriesRepository = entriesRepository;
        _createDirectoryViewModelFactory = createDirectoryViewModelFactory;
        _createFileViewModelFactory = createFileViewModelFactory;
        _filePropertiesViewModelFactory = filePropertiesViewModelFactory;
        _directoryPropertiesViewModelFactory = directoryPropertiesViewModelFactory;

        OpenCommand = new ActionCommand<BaseEntry>(Open);
        DeleteCommand = new ActionCommand<BaseEntry>(Delete);
        MoveBackCommand = new DelegateCommand(_ => MoveBack(), _ => historyNavigationService.CanMoveBack());
        MoveForwardCommand = new DelegateCommand(_ => MoveForward(), _ => historyNavigationService.CanMoveForward());

        CreateDirectoryCommand = new NavigateCommand<CreateDirectoryViewModel>(viewStore, createDirectoryViewModelFactory);
        CreateFileCommand = new NavigateCommand<CreateFileViewModel>(viewStore, createFileViewModelFactory);

        ShowPropertiesCommand = new ShowPropertiesCommand(viewStore, filePropertiesViewModelFactory,
            directoryPropertiesViewModelFactory);
    }
    
    private void RaiseCanExecuteChanged()
    {
        MoveBackCommand.RaiseCanExecuteChanged();
        MoveForwardCommand.RaiseCanExecuteChanged();
    }
    
    private void Open(BaseEntry entry)
    {
        if (entry is Directory directory)
        {
            _historyNavigationService.Add(directory);
            OnPropertyChanged(nameof(Entries));
        }
        else if (entry is File file)
        {
            file.Execute();
        }
        
        RaiseCanExecuteChanged();
    }

    private void Delete(BaseEntry entry)
    {
        _entriesRepository.Delete(entry);
        OnPropertyChanged(nameof(Entries));
        RaiseCanExecuteChanged();
    }

    private void MoveBack()
    {
        _historyNavigationService.MoveBack();
        OnPropertyChanged(nameof(Entries));
        RaiseCanExecuteChanged();
    }
    
    private void MoveForward()
    {
        _historyNavigationService.MoveForward();
        OnPropertyChanged(nameof(Entries));
        RaiseCanExecuteChanged();
    }
}