using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Pixeval.Controls.Ardelle.Tokens;

namespace Pixeval.Controls.Ardelle.MarkupExtensions;

public enum ColorToken
{
    Primary,
    Secondary,
    Tertiary,
    Error,
    Neutral,
    OnPrimary,
    OnSecondary,
    OnTertiary,
    OnError,
    OnNeutral
}

public class ColorTokenExtension : MarkupExtension
{
    public required ColorToken Name { get; set; }
    
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var resourceKey = Name switch
        {
            ColorToken.Primary => "Pixeval.Brush.Primary",
            ColorToken.Secondary => "Pixeval.Brush.Secondary",
            ColorToken.Tertiary => "Pixeval.Brush.Tertiary",
            ColorToken.Error => "Pixeval.Brush.Error",
            ColorToken.Neutral => "Pixeval.Brush.Neutral",
            ColorToken.OnPrimary => "Pixeval.Brush.OnPrimary",
            ColorToken.OnSecondary => "Pixeval.Brush.OnSecondary",
            ColorToken.OnTertiary => "Pixeval.Brush.OnTertiary",
            ColorToken.OnError => "Pixeval.Brush.OnError",
            ColorToken.OnNeutral => "Pixeval.Brush.OnNeutral",
            _ => throw new InvalidOperationException($"Unknown color token: {Name}")
        };
        return new DynamicResourceExtension(resourceKey);
    }
}