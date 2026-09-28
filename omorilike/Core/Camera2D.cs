
using Microsoft.Xna.Framework;

namespace omorilike.Core
{
    public class Camera2D
    {
        public Vector2 Position { get; private set; }
        public float Zoom { get; set; } = 1f;

        private readonly int _viewportWidth;
        private readonly int _viewportHeight;

        public Camera2D(
            int viewportWidth,
            int viewportHeight)
        {
            _viewportWidth = viewportWidth;
            _viewportHeight = viewportHeight;
        }

        public void Follow(Vector2 targetPosition)
        {
            Position = targetPosition;
        }

        public Matrix GetTransform()
        {
            return Matrix.CreateTranslation(-Position.X, -Position.Y, 0f) * Matrix.CreateScale(Zoom) * Matrix.CreateTranslation(_viewportWidth / 2f, _viewportHeight / 2f, 0f);
        }
    }
}
