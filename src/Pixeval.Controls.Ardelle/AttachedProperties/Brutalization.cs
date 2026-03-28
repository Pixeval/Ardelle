using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Threading;

namespace Pixeval.Controls.Ardelle.AttachedProperties;

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
        AvaloniaProperty.RegisterAttached<Brutalization, Control, BoxShadows>("BrutalizedShadows", defaultValue: new BoxShadows(
            new BoxShadow
            {
                OffsetX = 8,
                OffsetY = 8,
                Blur = 0,
                Spread = 0,
                Color = Color.Parse("#1A1918")
            }));
    
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
            border.BoxShadow = args.NewValue is true ? GetBrutalizedShadows(control) : default;
            if (args.NewValue is true)
            {
                border.BorderThickness = new Thickness(0);
            }
            else
            {
                border.ClearValue(Border.BorderThicknessProperty);
            }
        }
    }
}