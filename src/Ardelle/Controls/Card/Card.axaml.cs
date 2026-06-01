using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Ardelle.AttachedProperties;

namespace Ardelle.Controls.Card;

[TemplatePart("PART_BackgroundBorder", typeof(Border))]
public class Card : ContentControl, IBrutalizable
{
    public Border? Border { get; private set; }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        Border = e.NameScope.Find<Border>("PART_BackgroundBorder")!;
    }
}