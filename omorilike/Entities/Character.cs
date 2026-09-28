using Microsoft.Xna.Framework;
using omorilike.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace omorilike.Entities
{
    public abstract class Character : Entity
    {
        public Vector2 Velocity { get; protected set; }
        public float MoveSpeed { get; protected set; }

        protected Character(GameContext context, Vector2 position, float moveSpeed) : base(context, position)
        {
            MoveSpeed = moveSpeed;
            Velocity = Vector2.Zero;
        }

        protected void Move(Vector2 direction, GameTime gameTime)
        {
            if (direction != Vector2.Zero)
            {
                // If player presses both up and right the speed would be sqrt(1 ^ 2 + 1 ^ 2) = sqrt(2) = 1.414 which would be approx 41% faster than non-diagonal movement. Hence, we normalize.
                direction.Normalize();
            }

            Velocity = direction * MoveSpeed;
            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
