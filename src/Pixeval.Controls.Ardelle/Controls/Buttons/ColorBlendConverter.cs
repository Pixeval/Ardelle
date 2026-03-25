using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Pixeval.Controls.Ardelle.Tokens;

namespace Pixeval.Controls.Ardelle.Controls.Buttons;

public class ColorBlendConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var original = (ISolidColorBrush) value!;
        var mask = (ISolidColorBrush) parameter!;
        return new SolidColorBrush(original.Color.Blend(mask.Color, 0.7));
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}