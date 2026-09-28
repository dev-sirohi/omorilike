using Microsoft.Xna.Framework;

namespace omorilike.Core
{
    public abstract class GameScene
    {
        protected GameContext Context { get; }

        public GameScene(GameContext context)
        {
            Context = context;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
