using System.Diagnostics.CodeAnalysis;

using BenchmarkDotNet.Attributes;

namespace Strinum.Benchmarks;

[MemoryDiagnoser]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
public class Executor
{
    [Params(Sample.One, Sample.Ten)]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public Sample Sample { get; set; }

    [Benchmark]
    public void EnumToString()
    {
        _ = Sample.ToString();
    }

    [Benchmark]
    public void EnumGetName()
    {
        _ = Enum.GetName(Sample);
    }

    [Benchmark]
    public void EnumGetDescription()
    {
        _ = Sample.GetDescription();
    }
}