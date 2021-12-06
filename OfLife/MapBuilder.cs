namespace OfLife
{
    public class MapBuilder
    {
        public int Width { private set; get; }
        public int Height { private set; get; }
        
        private readonly Dictionary<(int, int), bool> _map = new();

        public Dictionary<(int, int), bool> Build()
        {
            return _map;
        }

        public MapBuilder WithHeight(int height)
        {
            Height = height;
            return this;
        }

        public MapBuilder WithWidth(int width)
        {
            Width = width;
            return this;
        }

        public MapBuilder WithPentominoR()
        {
            Add(Width / 2, Height / 2 - 1);
            Add(Width / 2, Height / 2);
            Add(Width / 2, Height / 2 + 1);
            Add(Width / 2 + -1, Height / 2);
            Add(Width / 2 + 1, Height / 2 - 1);

            return this;
        }

        public MapBuilder InitLeightWeightSpaceship()
        {
            Add(Width / 2 - 2, Height / 2 - 2);
            Add(Width / 2 - 1, Height / 2 - 2);
            Add(Width / 2 - 0, Height / 2 - 2);
            Add(Width / 2 + 1, Height / 2 - 2);

            Add(Width / 2 + 1, Height / 2 - 1);
            Add(Width / 2 + 1, Height / 2 - 0);

            Add(Width / 2 + 0, Height / 2 + 1);
            Add(Width / 2 - 3, Height / 2 + 1);
            Add(Width / 2 - 3, Height / 2 - 1);

            return this;
        }

        public MapBuilder InitExclamationMark()
        {
            Add(Width / 2, Height / 2 - 4);
            Add(Width / 2, Height / 2 - 3);
            Add(Width / 2, Height / 2 - 2);
            Add(Width / 2, Height / 2 - 1);
            Add(Width / 2, Height / 2 + 1);
            Add(Width / 2, Height / 2 + 2);

            Add(Width / 2 + 1, Height / 2 - 4);
            Add(Width / 2 + 1, Height / 2 - 3);
            Add(Width / 2 + 1, Height / 2 - 2);
            Add(Width / 2 + 1, Height / 2 - 1);
            Add(Width / 2 + 1, Height / 2 + 1);
            Add(Width / 2 + 1, Height / 2 + 2);

            return this;
        }

        public MapBuilder InitExplosion()
        {
            Add(Width / 2 - 1, Height / 2 - 3);
            Add(Width / 2 - 1, Height / 2 - 2);
            Add(Width / 2 - 1, Height / 2 - 1);
            Add(Width / 2, Height / 2 - 3);
            Add(Width / 2 + 1, Height / 2 - 3);
            Add(Width / 2 + 1, Height / 2 - 2);
            Add(Width / 2 + 1, Height / 2 - 1);

            Add(Width / 2 - 1, Height / 2 + 3);
            Add(Width / 2 - 1, Height / 2 + 2);
            Add(Width / 2 - 1, Height / 2 + 1);
            Add(Width / 2, Height / 2 + 3);
            Add(Width / 2 + 1, Height / 2 + 3);
            Add(Width / 2 + 1, Height / 2 + 2);
            Add(Width / 2 + 1, Height / 2 + 1);

            return this;
        }

        private void Add(int x, int y)
        {
            _map[(x, y)] = true;
        }
    }
}