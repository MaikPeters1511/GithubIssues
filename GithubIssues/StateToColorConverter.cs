using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace GithubIssues;

public class StateToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string state)
        {
            return state switch
            {
                "open" => Brushes.Green,
                "closed" => Brushes.Red,
                _ => Brushes.Gray,
            };
        }
        return Brushes.Gray;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}