using System;
using System.Collections.Generic;

namespace ExplorerDesktop;

/*public class GDriveEntriesController : IEntriesController
{
    private readonly GoogleServiceStore _store;
    private string _path;

    public string DefaultPath { get; }

    public GDriveEntriesController(GoogleServiceStore store)
    {
        _store = store;
        DefaultPath = string.Empty;
        _path = DefaultPath;
    }
    
    public IEnumerable<BaseEntry> ReceiveAsync(string path)
    {
        var entries = new List<BaseEntry>();
        
        var filesRequest = _store.DriveService.Files.List();
        var filesRequestExecuted = filesRequest.Execute();
        
        foreach (var file in filesRequestExecuted.Files)
        {
            entries.Add(new File(file.Name, file.Id));
        }

        return entries;
    }

    public IEnumerable<BaseEntry> Receive(string path)
    {
        throw new NotImplementedException();
    }

    public void OpenAsync(BaseEntry parameter)
    {
        throw new NotImplementedException();
    }

    public void Open(BaseEntry parameter)
    {
        if (parameter is Directory)
        {
            _path = parameter.Path;
            entries = ReceiveAsync(_path);
        }
        else if (parameter is File)
        {
            
        }
    }

    public void Delete(BaseEntry parameter)
    {
        throw new NotImplementedException();
    }
}*/