using System;
using System.IO;
using ExplorerDesktop.Domain;

namespace ExplorerDesktop;

public class CreateCommand<TEntry> : BaseCommand
    where TEntry : BaseEntry
{
    private readonly ViewStore _store;
    private readonly HistoryNavigationService _service;
    private readonly IRepository<BaseEntry> _repository;
    private readonly Func<string, string, TEntry> _instance;
    private readonly ViewModelFactory<EntriesViewModel> _factory;

    public CreateCommand(ViewStore store,
        HistoryNavigationService service, 
        IRepository<BaseEntry> repository, 
        Func<string, string, TEntry> instance, 
        ViewModelFactory<EntriesViewModel> factory)
    {
        _store = store;
        _service = service;
        _repository = repository;
        _instance = instance;
        _factory = factory;
    }
    
    public override void Execute(object? parameter)
    {
        var name = (string)(parameter ?? string.Empty);
        var path = Path.Combine(_service.Current.Path, name);
        
        _repository.Create(_instance(name, path));
        _store.CurrentViewModel = _factory();
    }
}