#region Copyright (c) Pixeval.Controls.Ardelle/Pixeval.Controls.Ardelle
// GPL v3 License
// 
// Pixeval.Controls.Ardelle/Pixeval.Controls.Ardelle
// Copyright (c) 2026 Pixeval.Controls.Ardelle/ContrastColorExtension.cs
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
#endregion

using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Pixeval.Controls.Ardelle.Tokens;

namespace Pixeval.Controls.Ardelle.MarkupExtensions;

public sealed record ShiftedColorBrushConversion(
    int Index,
    IValueConverter? BaseConverter = null,
    object? BaseConverterParameter = null);

public static class ArdelleConverterParameters
{
    public static ShiftedColorBrushConversion Contrast3 { get; } = new(3, ArdelleConverters.ContrastBrush);

    public static ShiftedColorBrushConversion Contrast4 { get; } = new(4, ArdelleConverters.ContrastBrush);
}

public sealed class ShiftedColorBrushConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var conversion = ResolveConversion(parameter);

        if (conversion.BaseConverter is not null)
        {
            value = conversion.BaseConverter.Convert(
                value,
                typeof(object),
                conversion.BaseConverterParameter,
                culture);
        }

        var brush = ContrastBrushConverter.TryGetBrush(value);
        return brush is null ? null : ShiftBrush(brush, conversion.Index);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException();

    private static ShiftedColorBrushConversion ResolveConversion(object? parameter)
    {
        if (parameter is ShiftedColorBrushConversion conversion)
        {
            return conversion;
        }

        if (TryGetIndex(parameter, out var index))
        {
            return new ShiftedColorBrushConversion(index);
        }

        throw new ArgumentOutOfRangeException(
            nameof(parameter),
            "ConverterParameter must be an integer index or a ShiftedColorBrushConversion.");
    }

    private static bool TryGetIndex(object? parameter, out int index)
    {
        switch (parameter)
        {
            case int value:
                index = value;
                return true;
            case string text when int.TryParse(text, CultureInfo.InvariantCulture, out var parsed):
                index = parsed;
                return true;
            default:
                index = 0;
                return false;
        }
    }

    private static ISolidColorBrush ShiftBrush(ISolidColorBrush brush, int index)
    {
        return index switch
        {
            0 => brush,
            >= -5 and < 0 => brush.Color.Palette.Dimmed[index + 5].original,
            > 0 and <= 5 => brush.Color.Palette.Brightened[index - 1].original,
            _ => throw new ArgumentOutOfRangeException(nameof(index), "Index must be between -5 and 5 inclusive.")
        };
    }
}
