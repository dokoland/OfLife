namespace Benchmark;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using OfLife;

[SimpleJob(RuntimeMoniker.Net60)]
[RPlotExporter]
public class BenchmarkGameOfLife
{
    private readonly MapBuilder _mapBuilder = 
        A.Map
         .WithWidth(120)
         .WithHeight(40);

    private Game _pentominoR => new(_mapBuilder.WithPentominoR());
    private Game _spaceship => new(_mapBuilder.WithLeightWeightSpaceship());

    [Params(10, 100, 1000)]
    public int cycles;

    [Benchmark]
    public void LWSS() => _spaceship.Cycle(cycles);

    [Benchmark]
    public void PentominoR() => _pentominoR.Cycle(cycles);
}
