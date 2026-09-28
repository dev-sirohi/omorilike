using System.Collections.Generic;

namespace omorilike.Core
{
    public class TileLayer
    {
        public string Name { get; }
        public int Width { get; }
        public int Height { get; }

        public IReadOnlyList<int> Tiles { get; }

        public TileLayer(
            string name,
            int width,
            int height,
            IReadOnlyList<int> tiles)
        {
            Name = name;
            Width = width;
            Height = height;
            Tiles = tiles;
        }

        public int GetTile(int x, int y)
        {
            return Tiles[y * Width + x];
        }
    }
}
