using System.Windows;
using System.Windows.Input;

namespace ExplorerDesktop;

public partial class EntriesView
{
    public static readonly DependencyProperty EntryDropCommandProperty =
        DependencyProperty.Register("PropertyType", typeof(ICommand), typeof(EntriesView),
            new PropertyMetadata(null));

    public ICommand EntryDropCommand
    {
        get => (ICommand)GetValue(EntryDropCommandProperty);
        set => SetValue(EntryDropCommandProperty, value);
    }
    
    public EntriesView()
    {
        InitializeComponent();
    }

    private void OnDrop(object sender, DragEventArgs e)
    {
        EntryDropCommand.Execute(e);
    }
}