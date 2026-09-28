using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using omorilike.Core;
using omorilike.Rendering;
using System;

namespace omorilike.Entities
{
    public class Player : Character
    {
        private readonly SpriteRenderer _spriteRenderer;

        public Player(
            GameContext context,
            Vector2 position,
            float moveSpeed)
            : base(context, position, moveSpeed)
        {
            var texture = context.AssetManager.LoadTexture("Characters/bearded-idle-1");

            _spriteRenderer = new SpriteRenderer(texture);
        }

        public override void Update(GameTime gameTime)
        {
            Move(Context.InputManager.MovementVector, gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteRenderer.Draw(Context.SpriteBatch, Position);
        }
    }
}