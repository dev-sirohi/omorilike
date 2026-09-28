using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace omorilike.Core
{
    public class AssetManager
    {
        private readonly ContentManager _contentManager;

        public AssetManager(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public Texture2D LoadTexture(string assetName)
        {
            return _contentManager.Load<Texture2D>(assetName);
        }
    }
}
