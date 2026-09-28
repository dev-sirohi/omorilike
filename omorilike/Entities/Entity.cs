using Microsoft.Xna.Framework;
using omorilike.Core;

namespace omorilike.Entities
{
    public abstract class Entity
    {
        protected GameContext Context { get; }
        public Vector2 Position { get; protected set; }

        protected Entity(GameContext context, Vector2 position)
        {
            Context = context;
            Position = position;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
