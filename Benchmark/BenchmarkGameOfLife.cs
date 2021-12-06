namespace Benchmark;

using BenchmarkDotNet.Attributes;
using OfLife;

public class BenchmarkGameOfLife
{
    private readonly MapBuilder _mapBuilder = 
        A.Map
         .WithWidth(120)
         .WithHeight(40);

    private Game _pentominoR => new(_mapBuilder.WithPentominoR());
    private Game _spaceship => new(_mapBuilder.WithLeightWeightSpaceship());

    [Benchmark]
    public void LWSS() => _spaceship.Cycle(1000);

    [Benchmark]
    public void PentominoR() => _pentominoR.Cycle(1000);
}
