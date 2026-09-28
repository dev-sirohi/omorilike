using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using omorilike.Core;
using omorilike.World;

namespace omorilike
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private const int InternalWidth = 640;
        private const int InternalHeight = 360;

        private RenderTarget2D _renderTarget;
        private GameManager _gameManager = new GameManager();
        private InputManager _inputManager = new InputManager();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;

            _graphics.SynchronizeWithVerticalRetrace = true;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _renderTarget = new RenderTarget2D(GraphicsDevice, InternalWidth, InternalHeight);

            // Create GameContext to provide Dependency Injection to other classes
            var context = new GameContext(GraphicsDevice, _spriteBatch, Content, _inputManager);

            var worldScene = new WorldScene(context);
            _gameManager.CurrentScene = worldScene;
        }

        protected override void Update(GameTime gameTime)
        {
            _inputManager.Update();

            if (_inputManager.IsKeyPressed(Keys.Escape))
            {
                Exit();
            }

            _gameManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Set render target to the internal rendering screen
            GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(Color.Black);

            _gameManager.Draw(gameTime);

            // Remove internal screen. It already contains the state.
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);

            // Use SpriteBatch to render the internal screen to the actual screen
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_renderTarget, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
