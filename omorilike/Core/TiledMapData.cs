using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace omorilike.Core
{
    public class TiledMapData
    {
        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("tilewidth")]
        public int TileWidth { get; set; }

        [JsonPropertyName("tileheight")]
        public int TileHeight { get; set; }

        [JsonPropertyName("layers")]
        public List<TiledLayerData> Layers { get; set; } = new();
    }
}
