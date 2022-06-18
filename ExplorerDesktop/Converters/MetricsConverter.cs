using System;
using System.Globalization;
using System.Windows.Data;

namespace ExplorerDesktop;

public class MetricsConverter : IValueConverter
{
    private readonly string[] _abbreviations = { "B", "KB", "MB", "GB", "TB" };
    
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        double length = System.Convert.ToDouble(value);
        int order = 0;

        while (length >= 1024 && order < _abbreviations.Length - 1)
        {
            length /= 1024;
            order++;
        }

        return $"{length:0.#} {_abbreviations[order]}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}