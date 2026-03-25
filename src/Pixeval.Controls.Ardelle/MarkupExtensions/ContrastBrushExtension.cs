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

using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Pixeval.Controls.Ardelle.Tokens;

namespace Pixeval.Controls.Ardelle.MarkupExtensions;

public class ContrastBrushExtension : MarkupExtension
{
    public required object? BaseColor { get; set; }
    
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        switch (BaseColor)
        {
            case Binding binding:
                binding.Converter = new FuncValueConverter<object, SolidColorBrush>(brush => ((ISolidColorBrush) brush!).Color.Palette.OnBaseline);
                return binding;
            case ISolidColorBrush scb:
                return scb.Color.Palette.OnBaseline;
            default:
                throw new ArgumentOutOfRangeException(nameof(BaseColor));
        }
    }
}