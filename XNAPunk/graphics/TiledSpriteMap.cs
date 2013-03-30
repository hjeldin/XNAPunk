using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XNAPunk.graphics;

namespace Adam.xnapunk.graphics
{
    class TiledSpriteMap : AnimatedSpriteMap
    {
        public TiledSpriteMap(Texture2D texture, Vector2 frameSize, Vector2 dimensions) : base(texture, frameSize) { }
    }
}
