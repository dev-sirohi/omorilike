using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace omorilike.Core
{
    public class InputManager
    {
        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;

        public void Update()
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();
        }

        public Vector2 MovementVector
        {
            get
            {
                Vector2 movement = Vector2.Zero;

                if (_currentKeyboardState.IsKeyDown(Keys.W))
                    movement.Y -= 1;

                if (_currentKeyboardState.IsKeyDown(Keys.S))
                    movement.Y += 1;

                if (_currentKeyboardState.IsKeyDown(Keys.A))
                    movement.X -= 1;

                if (_currentKeyboardState.IsKeyDown(Keys.D))
                    movement.X += 1;

                return movement;
            }
        }

        public bool IsKeyPressed(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key) &&
                   !_previousKeyboardState.IsKeyDown(key);
        }
    }
}
