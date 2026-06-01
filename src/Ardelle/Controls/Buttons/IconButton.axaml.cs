using Avalonia;
using Avalonia.Controls;
using AButton = Avalonia.Controls.Button;

namespace Ardelle.Controls.Buttons;

public class IconButton : AButton
{
    public static readonly StyledProperty<IconElement> IconProperty =
        AvaloniaProperty.Register<IconButton, IconElement>(nameof(Icon));

    public IconElement Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
}