using Avalonia.Media;

namespace Pixeval.Controls.Ardelle.Tokens;

public class ColorPalette(Color baseline)
{
    private readonly Lazy<List<Color>> _palette = new(() => GenerateAnchoredPalette(baseline));
    
    public SolidColorBrush Baseline => baseline.Brush;
    
    public SolidColorBrush OnBaseline => GetContrastColor(baseline).Brush;

    public List<(SolidColorBrush original, SolidColorBrush contrast)> Dimmed =>
        _palette.Value[..(_palette.Value.Count / 2)]
            .Select(color => color.Brush)
            .Zip(_palette.Value[..(_palette.Value.Count / 2)].Select(color => GetContrastColor(color).Brush)).ToList();

    public List<(SolidColorBrush original, SolidColorBrush contrast)> Brightened =>
        _palette.Value[(_palette.Value.Count / 2)..]
            .Select(color => color.Brush)
            .Zip(_palette.Value[(_palette.Value.Count / 2)..].Select(color => GetContrastColor(color).Brush)).ToList();
    
    public static List<Color> GenerateAnchoredPalette(Color baseColor)
    {
        const int paletteSize = 11;
        var palette = new List<Color>();
        var hsl = baseColor.ToHsl();
        const int midIndex = paletteSize / 2;

        for (var i = 0; i < paletteSize; i++)
        {
            double lightness;
            var saturation = hsl.S;

            switch (i)
            {
                case < midIndex:
                {
                    var t = (double) i / midIndex; 
                    lightness = t * hsl.L;
                    saturation = hsl.S * (0.8 + 0.2 * t);
                    break;
                }
                case midIndex:
                    lightness = hsl.L;
                    break;
                default:
                {
                    var t = (double) (i - midIndex) / (paletteSize - 1 - midIndex);
                    lightness = hsl.L + t * (1.0 - hsl.L);
                    saturation = hsl.S * (1.0 - t * 0.6);
                    break;
                }
            }
            saturation = Math.Clamp(saturation, 0.0, 1.0);

            var variation = new HslColor(hsl.A, hsl.H, saturation, lightness);
            palette.Add(variation.ToRgb());
        }

        return palette;
    }
    
    private static Color GetContrastColor(Color backgroundColor)
    {
        var yiq = (backgroundColor.R * 299 + 
                   backgroundColor.G * 587 + 
                   backgroundColor.B * 114) / 1000;
        return yiq >= 128 ? Colors.Black : Colors.White;
    }
}

public static class ColorPaletteExtensions
{
    extension(Color color)
    {
        public ColorPalette Palette => new(color);
        
        public SolidColorBrush Brush => new(color);
    }
}