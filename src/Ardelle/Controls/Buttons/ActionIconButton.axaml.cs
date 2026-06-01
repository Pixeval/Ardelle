#region Copyright (c) Ardelle/Ardelle
// GPL v3 License
// 
// Ardelle/Ardelle
// Copyright (c) 2026 Ardelle/ActionIconButton.axaml.cs
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

using Avalonia;
using Avalonia.Controls;
using AButton = Avalonia.Controls.Button;

namespace Ardelle.Controls.Buttons;

public class ActionIconButton : AButton
{
    public static readonly StyledProperty<IconElement> IconProperty =
        AvaloniaProperty.Register<IconButton, IconElement>(nameof(Icon));

    public static readonly StyledProperty<bool> IsLabelCollapsedProperty =
        AvaloniaProperty.Register<ActionIconButton, bool>(nameof(IsLabelCollapsed), defaultValue: false);
    
    public IconElement Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
    
    public bool IsLabelCollapsed
    {
        get => GetValue(IsLabelCollapsedProperty);
        set => SetValue(IsLabelCollapsedProperty, value);
    }
}