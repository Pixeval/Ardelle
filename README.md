# Pixeval.Controls.Material

Avalonia control theme library scaffold targeting .NET 9.

## Usage

Add the generated package/project reference to your Avalonia app, then include the theme:

```xml
<Application.Styles>
  <FluentTheme />
  <StyleInclude Source="avares://Pixeval.Controls.Material/Themes/MaterialTheme.axaml" />
</Application.Styles>
```

The library currently includes:
- `Themes/Colors.axaml`: base color resources.
- `Themes/Controls.axaml`: starter control styles (`Button.material`).

Example selector usage:

```xml
<Button Classes="material" Content="Material button" />
```

## Unit Conversion

Avalonia uses DIP (1/96 inch). Typography specs are often in points (1/72 inch).

Helper location: `Tokens/UnitConversion.cs`

```csharp
var bodySizeDip = UnitConversion.PtToDip(12); // 16
var bodySizePt = UnitConversion.DipToPt(16);  // 12
```
