## About

Powerful source code generator designed to enhance your development workflow by automating the generation of `Stringify()` extension methods for enum types. This "tool" efficiently scans your source code, identifies enum types, and generates extension methods that facilitate the conversion of enum members to their corresponding string representations.

## Key Features

- **Automatic Enum Stringification**: The generator intelligently analyzes your source code to identify enum types and creates `Stringify()` extension methods for each enum, streamlining the process of converting enum members to strings.
- **Customizable Output**: Tailor the generated code to match your project's coding standards and conventions. The source generator offers configuration options, allowing you to customize the output to align with your team's preferences.
- **Increased Productivity**: Save time and reduce the likelihood of errors by automating the creation of enum stringification methods. Focus on building robust features while the EnumStringifyGenerator handles the repetitive task of enum string conversion.

## Usage

### Basic enum stringification
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
