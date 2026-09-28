using System.Collections.Generic;

namespace omorilike.Core
{
    public class TileMap
    {
        public int Width { get; }
        public int Height { get; }
        public int TileWidth { get; }
        public int TileHeight { get; }

        public IReadOnlyList<TileLayer> Layers { get; }

        public TileMap(
            int width,
            int height,
            int tileWidth,
            int tileHeight,
            IReadOnlyList<TileLayer> layers)
        {
            Width = width;
            Height = height;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Layers = layers;
        }
    }
}
