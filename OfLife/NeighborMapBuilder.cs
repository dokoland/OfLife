namespace OfLife;

public class NeighborMapBuilder
{
    private MapBuilder? _mapBuilder;

    public Dictionary<(int, int), int> Build()
    {
        var map = new Dictionary<(int, int), int>();
        foreach (var cell in _mapBuilder!.Build().Keys)
        {
            AddToNeighborCounts(map, cell, 1);
        }

        return map;
    }

    public NeighborMapBuilder With(MapBuilder mapBuilder)
    {
        _mapBuilder = mapBuilder;

        return this;
    }

    private void AddToNeighborCounts(Dictionary<(int, int), int> map, (int, int) cell, int value)
    {
        var xLeft = cell.Item1 - 1;
        var x = cell.Item1;
        var xRight = cell.Item1 + 1;

        var yTop = cell.Item2 - 1;
        var y = cell.Item2;
        var yBottom = cell.Item2 + 1;

        xLeft = xLeft < 0 ? 0 : xLeft;
        xRight = xRight > _mapBuilder!.Width - 1 ? _mapBuilder.Width - 1 : xRight;
        yTop = yTop < 0 ? 0 : yTop;
        yBottom = yBottom > _mapBuilder.Height - 1 ? _mapBuilder.Height - 1 : yBottom;

        AddToDictionary(map, (xLeft, yTop), value);
        AddToDictionary(map, (x, yTop), value);
        AddToDictionary(map, (xRight, yTop), value);

        AddToDictionary(map, (xLeft, y), value);
        AddToDictionary(map, (xRight, y), value);

        AddToDictionary(map, (xLeft, yBottom), value);
        AddToDictionary(map, (x, yBottom), value);
        AddToDictionary(map, (xRight, yBottom), value);
    }

    private void AddToDictionary(Dictionary<(int, int), int> map, (int, int) key, int value)
    {
        if (!map.ContainsKey(key))
        {
            map[key] = 0;
        }
        map[key] += value;
    }
}
