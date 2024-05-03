using System.Diagnostics.CodeAnalysis;

using BenchmarkDotNet.Attributes;

namespace Strinum.Benchmarks;

[MemoryDiagnoser]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
public class Executor
{
    [Benchmark]
    public void Object_ToString()
    {
        _ = TypeCode.String.ToString();
    }

    [Benchmark]
    public void Enum_GetName()
    {
        _ = Enum.GetName(TypeCode.String);
    }

    [Benchmark]
    public void StringEnum_ToString()
    {
        _ = StringEnum.ToString(TypeCode.String);
    }
}