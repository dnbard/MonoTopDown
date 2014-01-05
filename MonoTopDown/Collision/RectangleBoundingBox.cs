using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTopDown.Utils;

namespace MonoTopDown.Collision
{
    class RectangleBoundingBox: BaseBoundingBox
    {
        public Rectangle Rect { get; set; }

        public override bool IntersectsWithPoint(Point point)
        {
            return Rect.Contains(point);
        }

        public override bool IntersectsWithRectangle(Rectangle rectangle)
        {
            return Rect.Intersects(rectangle);
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch, Vector2 offset)
        {
            batch.DrawLine(new Vector2(Rect.X, Rect.Y) - offset, new Vector2(Rect.X + Rect.Width, Rect.Y) - offset, Color.Green);
            batch.DrawLine(new Vector2(Rect.X + Rect.Width, Rect.Y) - offset, 
                new Vector2(Rect.X + Rect.Width, Rect.Y + Rect.Height) - offset, Color.Green);
            batch.DrawLine(new Vector2(Rect.X + Rect.Width, Rect.Y + Rect.Height) - offset,
                new Vector2(Rect.X, Rect.Y + Rect.Height) - offset, Color.Green);
            batch.DrawLine(new Vector2(Rect.X, Rect.Y + Rect.Height) - offset, new Vector2(Rect.X, Rect.Y) - offset, Color.Green);
        }
    }
}
