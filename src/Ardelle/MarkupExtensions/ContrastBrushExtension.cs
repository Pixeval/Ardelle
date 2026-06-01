#region Copyright (c) Ardelle/Ardelle
// GPL v3 License
// 
// Ardelle/Ardelle
// Copyright (c) 2026 Ardelle/ContrastColorExtension.cs
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
using Ardelle.Tokens;

namespace Ardelle.MarkupExtensions;

public sealed class ContrastBrushConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return TryGetBrush(value)?.Color.Palette.OnBaseline;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException();

    internal static ISolidColorBrush? TryGetBrush(object? value) => value switch
    {
        ISolidColorBrush brush => brush,
        Color color => color.Brush,
        _ => null
    };
}

public static class ArdelleConverters
{
    public static ContrastBrushConverter ContrastBrush { get; } = new();

    public static ShiftedColorBrushConverter ShiftedColorBrush { get; } = new();
}
