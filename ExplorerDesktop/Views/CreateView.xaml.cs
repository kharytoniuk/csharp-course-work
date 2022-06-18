using System.Windows;
using System.Windows.Media;

namespace ExplorerDesktop;

public partial class CreateView
{
    public static readonly DependencyProperty EntryImageProperty = DependencyProperty.Register(
        "EntryImage", typeof(ImageSource), typeof(CreateView), new PropertyMetadata(default(ImageSource)));

    public ImageSource EntryImage
    {
        get => (ImageSource)GetValue(EntryImageProperty);
        set => SetValue(EntryImageProperty, value);
    }
    
    public CreateView()
    {
        InitializeComponent();
    }
}