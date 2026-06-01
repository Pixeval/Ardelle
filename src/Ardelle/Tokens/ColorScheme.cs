using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace Ardelle.Tokens;

public record ColorScheme(
    Color PrimaryColor,
    Color SecondaryColor,
    Color TertiaryColor,
    Color ErrorColor,
    Color NeutralColor)
{
    private static readonly Lazy<ColorScheme> _default = new(GetDefaultColorScheme);
    
    public static ColorScheme Default => _default.Value;
    
    public ColorPalette PrimaryPalette { get; } = PrimaryColor.Palette;
    
    public ColorPalette SecondaryPalette { get; } = SecondaryColor.Palette;
    
    public ColorPalette TertiaryPalette { get; } = TertiaryColor.Palette;
    
    public ColorPalette ErrorPalette { get; } = ErrorColor.Palette;
    
    public ColorPalette NeutralPalette { get; } = NeutralColor.Palette;

    public SolidColorBrush Primary => PrimaryPalette.Baseline;
    
    public SolidColorBrush Secondary => SecondaryPalette.Baseline;
    
    public SolidColorBrush Tertiary => TertiaryPalette.Baseline;
    
    public SolidColorBrush Error => ErrorPalette.Baseline;
    
    public SolidColorBrush Neutral => NeutralPalette.Baseline;

    public SolidColorBrush OnPrimary => PrimaryPalette.OnBaseline;
    
    public SolidColorBrush OnSecondary => SecondaryPalette.OnBaseline;
        
    public SolidColorBrush OnTertiary => TertiaryPalette.OnBaseline;
    
    public SolidColorBrush OnError => ErrorPalette.OnBaseline;
    
    public SolidColorBrush OnNeutral => NeutralPalette.OnBaseline;
    
    public static ColorScheme GetDefaultColorScheme() => new(
        PrimaryColor: Application.Current!.TryFindResource("Pixeval.Color.Primary", out var primary)
            ? (Color) primary!
            : throw new InvalidOperationException("Primary color resource not found."),
        SecondaryColor: Application.Current!.TryFindResource("Pixeval.Color.Secondary", out var secondary)
            ? (Color) secondary!
            : throw new InvalidOperationException("Secondary color resource not found."),
        TertiaryColor: Application.Current!.TryFindResource("Pixeval.Color.Tertiary", out var tertiary)
            ? (Color) tertiary!
            : throw new InvalidOperationException("Tertiary color resource not found."),
        ErrorColor: Application.Current!.TryFindResource("Pixeval.Color.Error", out var error)
            ? (Color) error!
            : throw new InvalidOperationException("Error color resource not found."),
        NeutralColor: Application.Current!.TryFindResource("Pixeval.Color.Neutral", out var neutral)
            ? (Color) neutral!
            : throw new InvalidOperationException("Neutral color resource not found."));
}

