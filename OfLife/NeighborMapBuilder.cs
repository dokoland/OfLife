namespace OfLife;

public class NeighborMapBuilder
{
    private MapBuilder? _mapBuilder;

    private NeighborMap? _neighborMap;

    public NeighborMap Build()
    {
        _neighborMap = new NeighborMap(_mapBuilder!.Width, _mapBuilder.Height);

        foreach (var cell in _mapBuilder!.Build().Keys)
        {
            _neighborMap.AddToNeighborCounts(cell, 1);
        }

        return _neighborMap;
    }

    public NeighborMapBuilder With(MapBuilder mapBuilder)
    {
        _mapBuilder = mapBuilder;

        return this;
    }
}
