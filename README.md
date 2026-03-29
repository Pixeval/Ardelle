# Ardelle
Ardelle is a control library of Avalonia incorporating a lightweight form of [Neobrutalism](https://aesthetics.fandom.com/wiki/Neubrutalism), which is a design aesthetic most characterized by its hard shadows and high contrasts. This library is immature and not available for general use, it is intended to be a control library for the [Pixeval Project](https://github.com/Pixeval/Pixeval).

## Programming Guide
The control styles and logics are put under `src/Pixeval.Controls.Ardelle/Controls` directory, inside which each subdirectory contains a set of controls sharing common functionalities, for example, all variations of buttons should be put in the same subdirectory of `/Controls`, inside each subdirectory, we typically have three kind of files

1. Token files, this file contains the design tokens for the set of controls, like the default margin, background, foreground, font size of buttons, etc.
2. Control styles, like `Button.axaml` and `Button.axaml.cs`, these file defines the visual style and the logic of the controls. 
3. `Includes.axaml` file, this file includes all the style files like `Button.axaml` above, this will then be included in the app's global `ResourceDictionary`

Therefore, the general structure of the `Controls` folder should look like this

```
Controls/
├─ Buttons/
│  ├─ Button.axaml
│  ├─ Button.axaml.cs
│  ├─ IconButton.axaml
│  ├─ IconButton.axaml.cs
│  ├─ Includes.axaml
│  ├─ ButtonTokens.axaml
├─ Cards/
│  ├─ Card.axaml.cs
│  ├─ Card.axaml
│  ├─ CardTokens.axaml
│  ├─ Includes.axaml
```

After a control is created, you should put `<ControlName>.axaml` inside corresponding `Includes.axaml`，the `Includes.axaml` should look like this

```xml
<ResourceDictionary xmlns="https://github.com/avaloniaui"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <ResourceDictionary.MergedDictionaries>
        <ResourceInclude Source="Button.axaml" />
        <ResourceInclude Source="ButtonTokens.axaml" />
        <ResourceInclude Source="BaseButtonTheme.axaml" />
        <ResourceInclude Source="OutlineButton.axaml" />
        <ResourceInclude Source="GhostButton.axaml" />
        <ResourceInclude Source="IconButton.axaml" />
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>
```

And all the `Includes.axaml` should be put inside `Themes/Controls.axaml` like:

```xml
<ResourceDictionary xmlns="https://github.com/avaloniaui">
    <ResourceDictionary.MergedDictionaries>
        <ResourceInclude Source="../Controls/Buttons/Includes.axaml" />
        <ResourceInclude Source="../Controls/Card/Includes.axaml" />
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>
```
## Colors
We use a system to autogenerate a color palette from a single base color, for the concrete implementation, check `ColorPalette` and `ColorScheme`, it is suggested that for each control, choose a baseline color, and all other colors applied on this control should be computed using its variants generated from the `ColorPalette`.

In order to simplify the styling, we have two color markup extension

1. `ContrastBrushExtension`, this creates the dual color constrast to the given color.
2. `ShiftedColorBrushExtension`, given a specific color, use this to access the colors from the palette generated from this color. For example, you may use `#000000` as default enabled background inside by `<Setter Property="Background" Value="#000000" />`, then to get the text color on top of it, you may use 
   ```xml
   <Setter Property="Foreground" Value={ContrastBrush BaseColor={Binding Background, RelativeSource={RelativeSource TemplateParent}, Mode=OneTime}}" />
   ```
   to set the text color to white automatically.


## Miscellenous
The name of this project, _Ardelle_, comes from the operator _Ardelia_ in the game _Arknights: Endfield_, where I slightly modified it to have a typical French feminine suffix _-elle_.