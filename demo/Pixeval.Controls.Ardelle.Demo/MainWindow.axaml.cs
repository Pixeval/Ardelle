using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;

namespace Pixeval.Controls.Ardelle.Demo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ApplyDemoTheme(bool isDark)
    {
        RequestedThemeVariant = isDark ? ThemeVariant.Dark : ThemeVariant.Light;

        Resources["DemoPageBackgroundBrush"] = new SolidColorBrush(Color.Parse(isDark ? "#121211" : "#F4F4F3"));
        Resources["DemoCardBackgroundBrush"] = new SolidColorBrush(Color.Parse(isDark ? "#20201E" : "#FFFFFF"));
        Resources["DemoCardForegroundBrush"] = new SolidColorBrush(Color.Parse(isDark ? "#F4F4F3" : "#1A1918"));
        Resources["DemoMutedForegroundBrush"] = new SolidColorBrush(Color.Parse(isDark ? "#C8C8C2" : "#888888"));
        Resources["DemoSeparatorBrush"] = new SolidColorBrush(Color.Parse(isDark ? "#F4F4F3" : "#1A1918"));
        Resources["DemoAltSurfaceBrush"] = new SolidColorBrush(Color.Parse(isDark ? "#2D2D2A" : "#E6E6E3"));
    }

    private void ThemeModeSwitch_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        if (sender is ToggleSwitch toggleSwitch)
            ApplyDemoTheme(toggleSwitch.IsChecked is true);
    }
}
