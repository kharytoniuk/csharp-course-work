using System;

namespace ExplorerDesktop;

public class ActionCommand : ActionCommand<object?>
{
    public ActionCommand(Action<object?> onExecute) 
        : base(onExecute)
    {
    }
}

public class ActionCommand<T> : BaseCommand
{
    private readonly Action<T> _onExecute;

    public ActionCommand(Action<T> onExecute)
    {
        _onExecute = onExecute;
    }

    public override void Execute(object? parameter)
    {
        _onExecute((T)parameter);
    }
}