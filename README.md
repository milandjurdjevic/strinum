# Strinum [![latest version](https://img.shields.io/nuget/v/strinum)](https://www.nuget.org/packages/strinum)

### Fast and easy enum conversion to strings 
Powerful source code generator designed to enhance your development workflow by automating the generation of stringification extension methods for enum types. This "tool" efficiently scans your source code, identifies enum types, and generates extension methods that facilitate the conversion of enum members to their corresponding string representations.

## Features
- **Automatic Enum Stringification**: The generator intelligently analyzes your source code to identify enum types and creates stringification extension methods for each enum, streamlining the process of converting enum members to strings.
- **Customizable Output**: Tailor the generated code to match your project's coding standards and conventions. The source generator offers configuration options, allowing you to customize the output to align with your team's preferences.
- **Increased Productivity**: Save time and reduce the likelihood of errors by automating the creation of enum stringification methods. Focus on building robust features while the EnumStringifyGenerator handles the repetitive task of enum string conversion.

## Usage

The source generator will scan the source code for enum types and generate a `Stringify()` extension method that will
return the name of the enum member as a string.

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

## Benchmark

| Method        | Sample |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|---------------|--------|----------:|----------:|----------:|-------:|----------:|
| EnumToString  | One    | 6.8824 ns | 0.0161 ns | 0.0150 ns | 0.0038 |      24 B |
| EnumGetName   | One    | 1.1687 ns | 0.0008 ns | 0.0007 ns |      - |         - |
| EnumStringify | One    | 0.5309 ns | 0.0016 ns | 0.0014 ns |      - |         - |
| EnumToString  | Ten    | 6.9882 ns | 0.0398 ns | 0.0353 ns | 0.0038 |      24 B |
| EnumGetName   | Ten    | 1.1703 ns | 0.0010 ns | 0.0008 ns |      - |         - |
| EnumStringify | Ten    | 0.5309 ns | 0.0010 ns | 0.0009 ns |      - |         - |

### Legends

- Sample: Value of the 'Sample' parameter
- Mean: Arithmetic mean of all measurements
- Error: Half of 99.9% confidence interval
- StdDev: Standard deviation of all measurements
- Gen0: GC Generation 0 collects per 1000 operations
- Allocated: Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
- 1 ns: 1 Nanosecond (0.000000001 sec)

### Device

- Chip: Apple M1 Pro
- Memory: 16 GB
- OS: Sonoma 14.1.2