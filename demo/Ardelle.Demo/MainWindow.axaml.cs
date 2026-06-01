using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;

namespace Ardelle.Demo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        if (Application.Current is { } app)
        {
            app.RequestedThemeVariant = ThemeVariant.Light;
        }

        UpdateThemeButtons();
    }

    private void OnThemeToggleClick(object? sender, RoutedEventArgs e)
    {
        if (Application.Current is not { } app)
        {
            return;
        }

        app.RequestedThemeVariant = app.ActualThemeVariant == ThemeVariant.Dark
            ? ThemeVariant.Light
            : ThemeVariant.Dark;

        UpdateThemeButtons();
    }

    private void OnUseSystemThemeClick(object? sender, RoutedEventArgs e)
    {
        if (Application.Current is not { } app)
        {
            return;
        }

        app.RequestedThemeVariant = ThemeVariant.Default;
        UpdateThemeButtons();
    }

    private void UpdateThemeButtons()
    {
        if (Application.Current is not { } app)
        {
            return;
        }

        var isDarkTheme = app.ActualThemeVariant == ThemeVariant.Dark;

        ThemeToggleButton.Content = isDarkTheme ? "Switch to Light" : "Switch to Dark";
        SystemThemeButton.Content = app.RequestedThemeVariant == ThemeVariant.Default
            ? "Following System"
            : "Follow System";
    }
}