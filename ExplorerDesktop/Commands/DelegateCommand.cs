using System;

namespace ExplorerDesktop;

public class DelegateCommand : BaseCommand
{
    private readonly Action<object?> _onExecute;
    private readonly Predicate<object?> _canExecute;

    public DelegateCommand(Action<object?> onExecute, Predicate<object?> canExecute)
    {
        _onExecute = onExecute;
        _canExecute = canExecute;
    }

    public override void Execute(object? parameter)
    {
        _onExecute(parameter);
    }

    public override bool CanExecute(object? parameter)
    {
        return _canExecute(parameter);
    }
}