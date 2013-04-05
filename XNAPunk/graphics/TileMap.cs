using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAPunk.graphics
{
    public class TileMap : Graphic
    {
        protected Texture2D tilemap;
        protected int width, height, tileWidth, tileHeight;
        protected Texture2D completeTilemap;
        private int _cols, _rows;
        private Rectangle _tile, sourceRect;
        private int _setCols, _setRows, _setCount;

        public TileMap(Texture2D source, int _width, int _height, int _tileWidth, int _tileHeight)
        {
            tilemap = source;
            width = _width;
            height = _height;
            tileWidth = _tileWidth;
            tileHeight = _tileHeight;

            _cols = (int)Math.Ceiling(_width / _tileWidth);
            _rows = (int)Math.Ceiling(_height / _tileHeight);

            _tile = new Rectangle(0, 0, tileWidth, tileHeight);
            completeTilemap = new Texture2D(XP.Graphics.GraphicsDevice, _width, _height);
            sourceRect = new Rectangle(0, 0, _width, _height);
            if (tilemap != null)
            {
                _setCols = (int)Math.Ceiling(source.Width / tileWidth);
                _setRows = (int)Math.Ceiling(source.Height / tileHeight);
                _setCount = _setCols * _setRows;
            }
        }

        public void SetTile(int col, int row, int index)
        {
            index %= _setCount;
            col %= _cols;
            row %= _rows;
            _tile.X = (index % _setCols) * _tile.Width;
            _tile.Y = (int)(index / _setCols) * _tile.Height;
            int destX = col * tileWidth;
            int destY = row * tileHeight;
            Rectangle destCopy = new Rectangle(destX, destY, tileWidth, tileHeight);
            Color[] data = new Color[_tile.Width * _tile.Height];
            try
            {
                tilemap.GetData(0, _tile, data, 0, data.Length);
                completeTilemap.SetData(0,destCopy,data,0,data.Length);
            }
            catch (Exception e)
            {

            }
        }

        public override void Draw(Vector2 position)
        {
            XP.Canvas.Draw(completeTilemap, position + Position - XP.Camera.Position * Parallax, sourceRect, Tint, Rotation, Origin, Scale, Effects, 0);
        }
    }
}
