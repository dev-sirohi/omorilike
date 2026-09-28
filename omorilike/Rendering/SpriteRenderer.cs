using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace omorilike.Rendering
{
    public class SpriteRenderer
    {
        private readonly Texture2D _texture;

        public SpriteRenderer(Texture2D texture)
        {
            _texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(_texture, position, Color.White);
        }
    }
}
