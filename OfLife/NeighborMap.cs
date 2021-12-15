namespace OfLife;

public class NeighborMap
{
    private readonly int width;
    private readonly int height;
    private Dictionary<(int, int), int> _map = new Dictionary<(int, int), int>();

    public NeighborMap(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public int GetNeighbors((int, int) cell)
    {
        if (!_map.ContainsKey(cell)) return 0;

        return _map[cell];
    }

    public (int, int)[] GetCellsWith3Neighbors()
        => _map.Where(cell => cell.Value == 3).Select(cell => cell.Key).ToArray();

    public void Update(List<(int, int)> born, List<(int, int)> died)
    {
        foreach (var cell in born)
        {
            AddToNeighborCounts(cell, 1);
        }

        foreach (var cell in died)
        {
            AddToNeighborCounts(cell, -1);
        }
    }

    public void AddToNeighborCounts((int, int) cell, int value)
    {
        var xLeft = cell.Item1 - 1;
        var x = cell.Item1;
        var xRight = cell.Item1 + 1;

        var yTop = cell.Item2 - 1;
        var y = cell.Item2;
        var yBottom = cell.Item2 + 1;

        var xMax = width - 1;
        var yMax = height - 1;

        if (xLeft < 0)
        {
            xLeft = xMax;
        }
        if (xRight > xMax)
        {
            xRight = 0;
        }
        if (yTop < 0)
        {
            yTop = yMax;
        }
        if (yBottom > yMax)
        {
            yBottom = 0;
        }

        AddToDictionary((xLeft, yTop), value);
        AddToDictionary((x, yTop), value);
        AddToDictionary((xRight, yTop), value);

        AddToDictionary((xLeft, y), value);
        AddToDictionary((xRight, y), value);

        AddToDictionary((xLeft, yBottom), value);
        AddToDictionary((x, yBottom), value);
        AddToDictionary((xRight, yBottom), value);
    }

    private void AddToDictionary((int, int) key, int value)
    {
        if (!_map.ContainsKey(key))
        {
            _map[key] = 0;
        }

        _map[key] += value;
    }
}
