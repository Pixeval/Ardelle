using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Metadata;
using FluentIcons.Avalonia;
using FluentIcons.Common;

namespace Ardelle.MarkupExtensions;

public sealed class FluentIconExtension
{
    public FluentIconExtension() { }
    public FluentIconExtension(Icon icon)
    {
        Icon = icon;
    }

    [ConstructorArgument("icon")]
    public Icon? Icon { get; set; }
    public IconVariant? IconVariant { get; set; }
    public IconSize? IconSize { get; set; }
    public double? FontSize { get; set; }
    public Brush? Foreground { get; set; }

    public FluentIcon ProvideValue(IServiceProvider serviceProvider)
    {
        var icon = new FluentIcon();

        if (Icon.HasValue)
            icon.Icon = Icon.Value;
        if (IconVariant.HasValue)
            icon.IconVariant = IconVariant.Value;
        if (IconSize.HasValue)
            icon.IconSize = IconSize.Value;
        if (FontSize.HasValue)
            icon.FontSize = FontSize.Value;
        if (Foreground is not null)
            icon.Foreground = Foreground;

        var service = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
        if (Foreground is null && service?.TargetObject is TemplatedControl sourceControl)
        {
            icon.Bind(TemplatedControl.ForegroundProperty, new Binding
            {
                Source = sourceControl,
                Path = nameof(TemplatedControl.Foreground),
                Mode = BindingMode.OneWay
            });
        }
        if (service?.TargetObject is Visual source)
        {
            icon.Bind(Visual.FlowDirectionProperty, source.GetBindingObservable(Visual.FlowDirectionProperty));
        }

        return icon;
    }
}
