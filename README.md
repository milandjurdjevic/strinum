# Strinum [![latest version](https://img.shields.io/nuget/v/strinum)](https://www.nuget.org/packages/strinum)

### Fast and easy enum conversion to strings

Powerful source code generator designed to enhance your development workflow by automating the generation of
stringification methods for enum types. This "tool" efficiently scans your source code, identifies used enum types,
and generates methods that facilitate the conversion of enum members to their corresponding string
representations and vice versa.

## Benchmark

| Method              |       Mean |     Error |    StdDev |   Gen0 | Allocated |
|---------------------|-----------:|----------:|----------:|-------:|----------:|
| Object_ToString     | 10.4174 ns | 0.0292 ns | 0.0228 ns | 0.0038 |      24 B |
| Enum_GetName        |  4.2885 ns | 0.0143 ns | 0.0112 ns |      - |         - |
| StringEnum_ToString |  0.5429 ns | 0.0209 ns | 0.0196 ns |      - |         - |

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