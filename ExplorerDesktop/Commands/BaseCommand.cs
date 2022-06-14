using System;
using System.Windows.Input;

namespace ExplorerDesktop;

public class BaseCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public virtual bool CanExecute(object? parameter)
    {
        return true;
    }

    public virtual void Execute(object? parameter)
    {
        
    }

    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}