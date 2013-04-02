using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XNAPunk;
using XNAPunk.graphics;

namespace Adam.xnapunk.graphics
{
    public class TiledSpriteMap : AnimatedSpriteMap
    {
        protected Vector2 _dimensions;
        protected Rectangle dimRect;
        protected Vector2 repeat;
        public TiledSpriteMap(Texture2D texture, Vector2 frameSize, Vector2 dimensions) : base(texture, frameSize) 
        {
            _dimensions = dimensions;
            repeat = _dimensions / frameSize;
            dimRect = new Rectangle((int)this.Position.X, (int)this.Position.Y, (int)frameSize.X, (int)frameSize.Y);
            
        }

        public override void Draw(Vector2 position)
        {
            //DAFFAQ? Can not draw with linearwarp, can't tell why <_<
            int i =0;
            int j =0;
            for (i = 0; i < repeat.X; i++)
            {
                for (j = 0; j < repeat.Y; j++ )
                {
                    dimRect.X = (int)(i * Size.X) + (int)position.X;
                    dimRect.Y = (int)(j * Size.Y) + (int)position.Y;
                    XP.Canvas.Draw(Texture, dimRect, SourceRect, Tint, Rotation, Origin, Effects, 0);
                }
            }
            
            //base.Draw(position);
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
