using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace omorilike.Core
{
    public class TileMapLoader
    {
        public static TileMap Load(string mapPath)
        {
            string json = File.ReadAllText(mapPath);

            TiledMapData data =
                JsonSerializer.Deserialize<TiledMapData>(json)
                ?? throw new InvalidOperationException(
                    $"Could not load Tiled map: {mapPath}"
                );

            var layers = new List<TileLayer>();

            foreach (TiledLayerData layer in data.Layers)
            {
                if (layer.Type != "tilelayer")
                    continue;

                layers.Add(
                    new TileLayer(
                        layer.Name,
                        layer.Width,
                        layer.Height,
                        layer.Data
                    )
                );
            }

            return new TileMap(
                data.Width,
                data.Height,
                data.TileWidth,
                data.TileHeight,
                layers
            );
        }
    }
}
