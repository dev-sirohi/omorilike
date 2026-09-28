using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;

namespace omorilike.Core
{
    public class GameContext
    {
        public GraphicsDevice GraphicsDevice { get; }
        public SpriteBatch SpriteBatch { get; }
        public ContentManager Content { get; }
        public InputManager InputManager { get; }
        public AssetManager AssetManager { get; }

        public GameContext(
            GraphicsDevice graphicsDevice,
            SpriteBatch spriteBatch,
            ContentManager content,
            InputManager inputManager)
        {
            GraphicsDevice = graphicsDevice;
            SpriteBatch = spriteBatch;
            Content = content;
            InputManager = inputManager;

            AssetManager = new AssetManager(content);
        }
    }
}