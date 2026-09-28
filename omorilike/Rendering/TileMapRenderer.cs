using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using omorilike.Core;

namespace omorilike.Rendering
{
    public class TileMapRenderer
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly Texture2D _tileset;

        private readonly int _columns;
        private readonly int _tileWidth;
        private readonly int _tileHeight;

        public TileMapRenderer(
            SpriteBatch spriteBatch,
            Texture2D tileset,
            int columns,
            int tileWidth,
            int tileHeight)
        {
            _spriteBatch = spriteBatch;
            _tileset = tileset;

            _columns = columns;
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
        }

        public void Draw(TileMap map)
        {
            foreach (TileLayer layer in map.Layers)
            {
                DrawLayer(layer, map);
            }
        }

        private void DrawLayer(
            TileLayer layer,
            TileMap map)
        {
            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    int gid = layer.GetTile(x, y);

                    if (gid == 0)
                        continue;

                    DrawTile(gid, x, y, map);
                }
            }
        }

        private void DrawTile(
            int gid,
            int x,
            int y,
            TileMap map)
        {
            int tileIndex = gid - 1;

            int sourceX =
                (tileIndex % _columns) * _tileWidth;

            int sourceY =
                (tileIndex / _columns) * _tileHeight;

            Rectangle sourceRectangle = new Rectangle(
                sourceX,
                sourceY,
                _tileWidth,
                _tileHeight
            );

            Vector2 position = new Vector2(
                x * map.TileWidth,
                y * map.TileHeight
            );

            _spriteBatch.Draw(
                _tileset,
                position,
                sourceRectangle,
                Color.White
            );
        }
    }
}