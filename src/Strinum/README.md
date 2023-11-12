### Usage

The source generator will scan the source code for enum types and generate a `Stringify()` extension method that will return the name of the enum member as a string.

### Example

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
// Number 1
// Number 2
// Number 3
```
