using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace XNAPunk.graphics
{
    public class Text : Graphic
    {
        public SpriteFont Font = XP.Font;
        public string action = "";
        public String Txt = "";
        public float alpha = 1;
        public Text(String txt)
        {
            Txt = txt;
            Size = Font.MeasureString(Txt);
        }

        public void MeasureString() { Size = Font.MeasureString(Txt); }

        public override void Draw(Vector2 position)
        {
            myPos = position;
            XP.Canvas.DrawString(Font, Txt, position + Position - XP.Camera.Position * Parallax, Tint * alpha, Rotation, Origin, Scale, Effects, 0);
        }

    }
}
