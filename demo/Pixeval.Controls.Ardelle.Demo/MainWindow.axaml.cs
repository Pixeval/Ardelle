using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Pixeval.Controls.Ardelle.Tokens;

namespace Pixeval.Controls.Ardelle.Demo;

public partial class MainWindow : Window
{
    public string PaletteAnchorHex { get; }

    public MainWindow()
    {
        InitializeComponent();
    }
}