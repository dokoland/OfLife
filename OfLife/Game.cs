namespace OfLife;

public class Game
{
    private readonly Dictionary<(int, int), bool> _map;
    private readonly MapBuilder _mapBuilder;
    private NeighborMap _neighborMap;
    private List<(int, int)> _died = new();
    private List<(int, int)> _born = new();

    public (int, int)[] GetCells() => _map.Keys.ToArray();

    public Game(MapBuilder mapBuilder)
    {
        _mapBuilder = mapBuilder;
        _map = mapBuilder.Build();
        _neighborMap = A.NeighborMap.With(_mapBuilder).Build();
    }

    public void Cycle(int iterations)
    {
        for (var i = 0; i < iterations; i++)
        {
            Cycle();
        }
    }

    public (List<(int, int)>, List<(int, int)>) Cycle()
    {
        _neighborMap.Update(_born, _died);

        _died = new();
        _born = new();

        foreach (var cell in _map.Keys)
        {
            // Should the cell die?
            // More than 3 neighbors?
            // Less than 2 neighbors or no neighbors at all
            var neighborsCount = _neighborMap.GetNeighbors(cell);
            if (neighborsCount > 3 || neighborsCount < 2)
            {
                if (_map.ContainsKey(cell))
                {
                    _map.Remove(cell);
                    _died.Add(cell);
                }
            }
        }

        // Should a cell be born?
        // exactly 3 neighbors
        foreach (var neighbor in _neighborMap.GetCellsWith3Neighbors())
        {
            if (!_map.ContainsKey(neighbor))
            {
                _map[neighbor] = true;
                _born.Add(neighbor);
            }
        }

        return (_born, _died);
    }

    public void Draw()
    {
        foreach (var cell in _map.Keys)
        {
            Console.SetCursorPosition(cell.Item1, cell.Item2);
            Console.Write("X");
        }
    }
}
