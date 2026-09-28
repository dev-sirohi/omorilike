using Microsoft.Xna.Framework;

namespace omorilike.Core
{
    public class GameManager
    {
        public GameScene CurrentScene { get; set; }

        public GameManager()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            CurrentScene.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            CurrentScene.Draw(gameTime);
        }
    }
}
