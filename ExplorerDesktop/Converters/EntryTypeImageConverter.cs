using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ExplorerDesktop;

public class EntryTypeImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var image = new DrawingImage();

        if (value is Directory directory)
        {
            if (Application.Current.TryFindResource("DirectoryImage") is DrawingImage directoryImage)
            {
                image = directoryImage;
            }
        }
        else if (value is File)
        {
            if (Application.Current.TryFindResource("FileImage") is DrawingImage drawingImage)
            {
                image = drawingImage;
            }
        }
        
        return image;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}