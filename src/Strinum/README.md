## Usage

The `Stringify()` extension method is generated for each enum type in your source code. If you call it on an enum member, it will return the member represented as a string.

```csharp
public enum Number
{
    One,
    Two,
    Three
}

 Console.WriteLine(Number.One.Stringify());
 Console.WriteLine(Number.Two.Stringify());
 Console.WriteLine(Number.Three.Stringify());

// Output:
// One
// Two
// Three
```

### Customizing outputs

Sometimes you want to change the output of a stringified enum value. To do that, you can use `StringifyAttribute` to override the default enum string value.

```csharp
using Strinum;

public enum Number
{
    [Stringify("NumberOne")] One,
    [Stringify("number_two")] Two,
    [Stringify("number-three")] Three,
    [Stringify("numberFour")] Four,
    [Stringify("Number 5")] Five
}

Console.WriteLine(Number.One.Stringify());
Console.WriteLine(Number.Two.Stringify());
Console.WriteLine(Number.Three.Stringify());
Console.WriteLine(Number.Four.Stringify());
Console.WriteLine(Number.Five.Stringify());

// Output:
// NumberOne
// number_two
// number-three
// numberFour
// Number 5
```
