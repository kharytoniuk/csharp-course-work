using System;

namespace ExplorerDesktop;

public class DelegateCommand : DelegateCommand<object?>
{
    public DelegateCommand(Action<object?> onExecute, Predicate<object?> canExecute) 
        : base(onExecute, canExecute)
    {
    }
}

public class DelegateCommand<T> : BaseCommand
{
    private readonly Action<T> _onExecute;
    private readonly Predicate<T> _canExecute;

    public DelegateCommand(Action<T> onExecute, Predicate<T> canExecute)
    {
        _onExecute = onExecute;
        _canExecute = canExecute;
    }

    public override void Execute(object? parameter)
    {
        if (parameter == null)
        {
            return;
        }

        _onExecute((T)parameter);
    }

    public override bool CanExecute(object? parameter)
    {
        return parameter != null && _canExecute((T)parameter);
    }
}