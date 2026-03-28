using Avalonia;
using Avalonia.Controls;

namespace Pixeval.Controls.Ardelle.Controls.Card;

public class Card : ContentControl
{
    public static readonly StyledProperty<bool> BrutalizedProperty =
        AvaloniaProperty.Register<Card, bool>(nameof(Brutalized));
    
    public bool Brutalized
    {
        get => GetValue(BrutalizedProperty);
        set => SetValue(BrutalizedProperty, value);
    }
}