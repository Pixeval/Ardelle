using Avalonia.Markup.Xaml;
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
    
    public override object ProvideValue(IServiceProvider serviceProvider) => Name switch
    {
        ColorToken.Primary => ColorScheme.Default.PrimaryPalette.Baseline,
        ColorToken.Secondary => ColorScheme.Default.SecondaryPalette.Baseline,
        ColorToken.Tertiary => ColorScheme.Default.TertiaryPalette.Baseline,
        ColorToken.Error => ColorScheme.Default.ErrorPalette.Baseline,
        ColorToken.Neutral => ColorScheme.Default.NeutralPalette.Baseline,
        ColorToken.OnPrimary => ColorScheme.Default.PrimaryPalette.OnBaseline,
        ColorToken.OnSecondary => ColorScheme.Default.SecondaryPalette.OnBaseline,
        ColorToken.OnTertiary => ColorScheme.Default.TertiaryPalette.OnBaseline,
        ColorToken.OnError => ColorScheme.Default.ErrorPalette.OnBaseline,
        ColorToken.OnNeutral => ColorScheme.Default.NeutralPalette.OnBaseline,
        _ => throw new InvalidOperationException($"Unknown color token: {Name}")
    };
}