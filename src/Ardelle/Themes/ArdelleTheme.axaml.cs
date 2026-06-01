// Copyright (c) Ardelle.
// Licensed under the GPL-3.0 License.

using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Ardelle.Themes;

public class ArdelleTheme : Styles
{
    public ArdelleTheme()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
