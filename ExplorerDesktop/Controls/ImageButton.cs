using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExplorerDesktop;

public class ImageButton : Button
{
    public static readonly DependencyProperty ImageProperty =
        DependencyProperty.Register("Image", typeof(ImageSource), typeof(ImageButton),
            new PropertyMetadata(default(ImageSource)));
    
    static ImageButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton),
            new FrameworkPropertyMetadata(typeof(ImageButton)));
    }

    public ImageSource Image
    {
        get => (ImageSource)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }
}