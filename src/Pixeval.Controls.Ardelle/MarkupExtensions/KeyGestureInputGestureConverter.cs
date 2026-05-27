using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Input;

namespace Pixeval.Controls.Ardelle.MarkupExtensions;

public sealed class KeyGestureInputGestureConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value switch
        {
            null => string.Empty,
            KeyGesture keyGesture => keyGesture.ToString(),
            _ => value.ToString()
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}