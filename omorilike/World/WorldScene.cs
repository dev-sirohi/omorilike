using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using omorilike.Core;
using omorilike.Entities;
using omorilike.Rendering;
using System.Collections.Generic;

namespace omorilike.World
{
    public class WorldScene : GameScene
    {
        private readonly List<Entity> _entities = new();
        private readonly Player _player;
        private readonly Camera2D _camera;
        private readonly TileMap _tileMap;
        private readonly TileMapRenderer _tileMapRenderer;

        public WorldScene(GameContext context) : base(context)
        {
            _tileMap = TileMapLoader.Load("Content/Maps/farm.tmj");
            Texture2D tileset = context.AssetManager.LoadTexture("Tiles/Grass");

            _tileMapRenderer = new TileMapRenderer(
                context.SpriteBatch,
                tileset,
                11,
                16,
                16
            );

            _camera = new Camera2D(640, 360);
            _player = new Player(context, new Vector2(100, 100), 100f);
            _entities.Add(_player);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Entity entity in _entities)
            {
                entity.Update(gameTime);
            }

            _camera.Follow(_player.Position);
        }

        public override void Draw(GameTime gameTime)
        {
            Context.SpriteBatch.Begin(transformMatrix: _camera.GetTransform());

            _tileMapRenderer.Draw(_tileMap);

            foreach (Entity entity in _entities)
            {
                entity.Draw(gameTime);
            }

            Context.SpriteBatch.End();
        }
    }
}
