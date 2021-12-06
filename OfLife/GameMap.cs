namespace OfLife
{
    public class GameMap
    {
        private readonly int _width = 25;
        private readonly int _height = 15;

        private readonly Dictionary<(int, int), bool> _map = new();
        private readonly Dictionary<(int, int), int> _neighbors = new();

        public GameMap()
        {
        }

        public GameMap(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public void Add(int x, int y)
        {
            _map[(x, y)] = true;
        }

        public void InitPentominoR()
        {
            Add(_width / 2, _height / 2 - 1);
            Add(_width / 2, _height / 2);
            Add(_width / 2, _height / 2 + 1);
            Add(_width / 2 + -1, _height / 2);
            Add(_width / 2 + 1, _height / 2 - 1);
        }

        public void InitLeightWeightSpaceship()
        {
            Add(_width / 2 - 2, _height / 2 - 2);
            Add(_width / 2 - 1, _height / 2 - 2);
            Add(_width / 2 - 0, _height / 2 - 2);
            Add(_width / 2 + 1, _height / 2 - 2);

            Add(_width / 2 + 1, _height / 2 - 1);
            Add(_width / 2 + 1, _height / 2 - 0);

            Add(_width / 2 + 0, _height / 2 + 1);
            Add(_width / 2 - 3, _height / 2 + 1);
            Add(_width / 2 - 3, _height / 2 - 1);
        }

        public void InitExclamationMark()
        {
            Add(_width / 2, _height / 2 - 4);
            Add(_width / 2, _height / 2 - 3);
            Add(_width / 2, _height / 2 - 2);
            Add(_width / 2, _height / 2 - 1);
            Add(_width / 2, _height / 2 + 1);
            Add(_width / 2, _height / 2 + 2);

            Add(_width / 2 + 1, _height / 2 - 4);
            Add(_width / 2 + 1, _height / 2 - 3);
            Add(_width / 2 + 1, _height / 2 - 2);
            Add(_width / 2 + 1, _height / 2 - 1);
            Add(_width / 2 + 1, _height / 2 + 1);
            Add(_width / 2 + 1, _height / 2 + 2);
        }

        public void InitExplosion()
        {
            Add(_width / 2 - 1, _height / 2 - 3);
            Add(_width / 2 - 1, _height / 2 - 2);
            Add(_width / 2 - 1, _height / 2 - 1);
            Add(_width / 2, _height / 2 - 3);
            Add(_width / 2 + 1, _height / 2 - 3);
            Add(_width / 2 + 1, _height / 2 - 2);
            Add(_width / 2 + 1, _height / 2 - 1);

            Add(_width / 2 - 1, _height / 2 + 3);
            Add(_width / 2 - 1, _height / 2 + 2);
            Add(_width / 2 - 1, _height / 2 + 1);
            Add(_width / 2, _height / 2 + 3);
            Add(_width / 2 + 1, _height / 2 + 3);
            Add(_width / 2 + 1, _height / 2 + 2);
            Add(_width / 2 + 1, _height / 2 + 1);
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
                    //Console.SetCursorPosition(cell.Item1, cell.Item2);
                    //Console.BackgroundColor = ConsoleColor.Black;
                    //Console.Write(" ");

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
            xRight = xRight > _width - 1 ? _width - 1 : xRight;
            yTop = yTop < 0 ? 0 : yTop;
            yBottom = yBottom > _height - 1 ? _height - 1 : yBottom;

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

        public void Draw()
        {
            foreach (var cell in _map.Keys)
            {
                //Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(cell.Item1, cell.Item2);
                Console.Write("X");
            }
        }

        public void DrawAll()
        {
            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    if (_map.ContainsKey((x, y)))
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

        }

    }
}
