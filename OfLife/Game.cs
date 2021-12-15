namespace OfLife;

public class Game
{
    private readonly Dictionary<(int, int), bool> _map;
    private readonly MapBuilder _mapBuilder;

    public (int, int)[] GetCells() => _map.Keys.ToArray();

    public Game(MapBuilder mapBuilder)
    {
        _mapBuilder = mapBuilder;
        _map = mapBuilder.Build();
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
        var died = new List<(int, int)>();
        var born = new List<(int, int)>();

        var neighbors = A.NeighborMap
            .With(_mapBuilder)
            .Build();

        foreach (var cell in _map.Keys)
        {
            // Should the cell die?
            // More than 3 neighbors?
            // Less than 2 neighbors or no neighbors at all
            if (!neighbors.ContainsKey(cell) || neighbors[cell] > 3 || neighbors[cell] < 2)
            {
                _map.Remove(cell);
                died.Add(cell);
            }
        }
        // Should a cell be born?
        // exactly 3 neighbors
        foreach (var neighbor in neighbors)
        {
            if (neighbor.Value == 3)
            {
                _map[neighbor.Key] = true;
                born.Add(neighbor.Key);
            }
        }

        return (born, died);
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
