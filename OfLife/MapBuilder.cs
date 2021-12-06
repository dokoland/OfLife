namespace OfLife
{
    public class MapBuilder
    {
        public int Width { private set; get; } = 25;
        public int Height { private set; get; } = 15;

        private readonly Dictionary<(int, int), bool> _map = new();

        public Dictionary<(int, int), bool> Build()
        {
            return _map;
        }

        public MapBuilder WithPentominoR()
        {
            Add(HalfWidth + 0, HalfHeight - 1);
            Add(HalfWidth + 0, HalfHeight);
            Add(HalfWidth + 0, HalfHeight + 1);
            Add(HalfWidth - 1, HalfHeight);
            Add(HalfWidth + 1, HalfHeight - 1);

            return this;
        }

        public MapBuilder InitLeightWeightSpaceship()
        {
            Add(HalfWidth - 2, HalfHeight - 2);
            Add(HalfWidth - 1, HalfHeight - 2);
            Add(HalfWidth - 0, HalfHeight - 2);
            Add(HalfWidth + 1, HalfHeight - 2);
            Add(HalfWidth + 1, HalfHeight - 1);
            Add(HalfWidth + 1, HalfHeight - 0);
            Add(HalfWidth + 0, HalfHeight + 1);
            Add(HalfWidth - 3, HalfHeight + 1);
            Add(HalfWidth - 3, HalfHeight - 1);

            return this;
        }

        public MapBuilder InitExclamationMark()
        {
            Add(HalfWidth, HalfHeight - 4);
            Add(HalfWidth, HalfHeight - 3);
            Add(HalfWidth, HalfHeight - 2);
            Add(HalfWidth, HalfHeight - 1);
            Add(HalfWidth, HalfHeight + 1);
            Add(HalfWidth, HalfHeight + 2);

            Add(HalfWidth + 1, HalfHeight - 4);
            Add(HalfWidth + 1, HalfHeight - 3);
            Add(HalfWidth + 1, HalfHeight - 2);
            Add(HalfWidth + 1, HalfHeight - 1);
            Add(HalfWidth + 1, HalfHeight + 1);
            Add(HalfWidth + 1, HalfHeight + 2);

            return this;
        }

        public MapBuilder InitExplosion()
        {
            Add(HalfWidth - 1, HalfHeight - 3);
            Add(HalfWidth - 1, HalfHeight - 2);
            Add(HalfWidth - 1, HalfHeight - 1);
            Add(HalfWidth + 0, HalfHeight - 3);
            Add(HalfWidth + 1, HalfHeight - 3);
            Add(HalfWidth + 1, HalfHeight - 2);
            Add(HalfWidth + 1, HalfHeight - 1);

            Add(HalfWidth - 1, HalfHeight + 3);
            Add(HalfWidth - 1, HalfHeight + 2);
            Add(HalfWidth - 1, HalfHeight + 1);
            Add(HalfWidth + 0, HalfHeight + 3);
            Add(HalfWidth + 1, HalfHeight + 3);
            Add(HalfWidth + 1, HalfHeight + 2);
            Add(HalfWidth + 1, HalfHeight + 1);

            return this;
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

        private void Add(int x, int y)
        {
            _map[(x, y)] = true;
        }

        private int HalfWidth => Width / 2;
        private int HalfHeight => Height / 2;
    }
}