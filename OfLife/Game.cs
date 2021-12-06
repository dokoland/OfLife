namespace OfLife
{
    public class Game
    {
        private readonly Dictionary<(int, int), bool> _map;
        private readonly MapBuilder _mapBuilder;

        public Game(MapBuilder mapBuilder)
        {
            _mapBuilder = mapBuilder;
            _map = mapBuilder.Build();
        }

        public void Cycle()
        {
            var neighbors = CreateNeighborMap(_map.Keys.ToArray());
            foreach (var cell in _map.Keys)
            {
                // Should the cell die?
                // More than 3 neighbors?
                // Less than 2 neighbors or no neighbors at all
                if (!neighbors.ContainsKey(cell) || neighbors[cell] > 3 || neighbors[cell] < 2)
                {
                    _map.Remove(cell);
                }
            }
            // Should a cell be born?
            // exactly 3 neighbors
            foreach (var neighbor in neighbors
                .Where(cell => cell.Value == 3)
                .Select(cell => cell.Key))
            {
                _map[neighbor] = true;
            }
        }

        public void Draw()
        {
            foreach (var cell in _map.Keys)
            {
                Console.SetCursorPosition(cell.Item1, cell.Item2);
                Console.Write("X");
            }
        }

        private Dictionary<(int, int), int> CreateNeighborMap((int, int)[] cells)
        {
            var map = new Dictionary<(int, int), int>();
            foreach (var cell in cells)
            {
                AddToNeighborCounts(map, cell, 1);
            }

            return map;
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
            xRight = xRight > _mapBuilder.Width - 1 ? _mapBuilder.Width - 1 : xRight;
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
}
