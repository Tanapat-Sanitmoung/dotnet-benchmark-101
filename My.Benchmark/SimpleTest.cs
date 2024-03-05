
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;

[Config(type:typeof(Config))]
public class SimpleTest
{
    private class Config:ManualConfig
    {
        public Config()
        {
            AddExporter(MarkdownExporter.GitHub);
            AddDiagnoser(MemoryDiagnoser.Default);
            AddJob(Job.ShortRun.WithInvocationCount(16_000_000));
        }
    }

    [Benchmark(Baseline = true)]
    public int Original()
    {
        var data = new byte[256];
        return 0;
    }

    
    [Benchmark()]
    [SkipLocalsInit]
    public int Improment_V1()
    {
        Span<byte> data = stackalloc byte[256];
        return 0;
    }
}