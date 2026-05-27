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
    }

    private void ThemeModeSwitch_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        if (sender is ToggleSwitch toggleSwitch)
            ApplyDemoTheme(toggleSwitch.IsChecked is true);
    }
}
