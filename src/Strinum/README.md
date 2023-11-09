### Usage

The source generator will scan the source code for enum members marked
with `System.ComponentModel.DescriptionAttribute`. Attribute argument value will retrieved from `GetDescription()`
extension method.

### Example

```csharp
public enum Number
{
    [Description("Number 1")] One,
    [Description("Number 2")] Two,
    [Description("Number 3")] Three
}

 Console.WriteLine(Number.One.GetDescription());
 Console.WriteLine(Number.Two.GetDescription());
 Console.WriteLine(Number.Three.GetDescription());

// Output:
// Number 1
// Number 2
// Number 3
```
