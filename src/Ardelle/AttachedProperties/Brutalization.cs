using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Threading;

namespace Ardelle.AttachedProperties;

public interface IBrutalizable
{
    Border? Border { get; }
}

public class Brutalization : AvaloniaObject
{
    static Brutalization()
    {
        IsBrutalizedProperty.Changed.AddClassHandler<Control>(OnIsBrutalizedChanged);
    }
    
    public static readonly AttachedProperty<bool> IsBrutalizedProperty =
        AvaloniaProperty.RegisterAttached<Brutalization, Control, bool>("IsBrutalized", defaultValue: false);

    public static readonly AttachedProperty<BoxShadows> BrutalizedShadowsProperty =
        AvaloniaProperty.RegisterAttached<Brutalization, Control, BoxShadows>("BrutalizedShadows", defaultValue: default);
    
    public static void SetIsBrutalized(AvaloniaObject element, bool value)
    {
        element.SetValue(IsBrutalizedProperty, value);
    }
    
    public static bool GetIsBrutalized(AvaloniaObject element)
    {
        return element.GetValue(IsBrutalizedProperty);
    }

    public static BoxShadows GetBrutalizedShadows(AvaloniaObject element)
    {
        return element.GetValue(BrutalizedShadowsProperty);
    }
    
    public static void SetBrutalizedShadows(AvaloniaObject element, BoxShadows value)
    {
        element.SetValue(BrutalizedShadowsProperty, value);
    }
    
    private static void OnIsBrutalizedChanged(Control control, AvaloniaPropertyChangedEventArgs args)
    {
        if (control.IsLoaded)
        {
            if (!Dispatcher.UIThread.CheckAccess())
            {
                Dispatcher.UIThread.Post(() => ApplyShadow(control, args));
            }
            else
            {
                ApplyShadow(control, args);
            }
        }
        else
        { 
            void ControlOnLoaded(object? sender, RoutedEventArgs e)
            {
                control.Loaded -= ControlOnLoaded;
                if (!Dispatcher.UIThread.CheckAccess())
                {
                    Dispatcher.UIThread.Post(() => ApplyShadow(control, args));
                }
                else
                {
                    ApplyShadow(control, args);
                }
            }

            control.Loaded += ControlOnLoaded;
        }
    }
    

    private static void ApplyShadow(Control control, AvaloniaPropertyChangedEventArgs args)
    {
        if (control is IBrutalizable { Border: { } border })
        {
            var shadowBrush = GetDefaultBrutalizationShadowBrush();

            border.BoxShadow = args.NewValue is true ? ResolveShadows(control, shadowBrush) : default;
            if (args.NewValue is true)
            {
                border.BorderThickness = new Thickness(2);
                border.BorderBrush = shadowBrush;
            }
            else
            {
                border.ClearValue(Border.BorderThicknessProperty);
            }
        }
    }

    private static SolidColorBrush GetDefaultBrutalizationShadowBrush() =>
        Application.Current?.TryFindResource("DefaultBrutalizationShadowBrush", out var brush) is true
            ? brush as SolidColorBrush ?? new SolidColorBrush(Colors.Black)
            : new SolidColorBrush(Colors.Black);

    private static BoxShadows ResolveShadows(Control control, SolidColorBrush shadowBrush)
    {
        var shadows = GetBrutalizedShadows(control);
        return shadows.Count is 0 ? CreateDefaultShadows(shadowBrush) : shadows;
    }

    private static BoxShadows CreateDefaultShadows(SolidColorBrush shadowBrush) =>
        new(
            new BoxShadow
            {
                OffsetX = 10,
                OffsetY = 12,
                Blur = 0,
                Spread = 0,
                Color = shadowBrush.Color
            });
}