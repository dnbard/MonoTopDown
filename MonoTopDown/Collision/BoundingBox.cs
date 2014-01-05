using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTopDown.GUI;

namespace MonoTopDown.Collision
{
    internal abstract class BaseBoundingBox
    {
        public BaseGuiComponent Owner { get; set; }

        public abstract bool IntersectsWithPoint(Point point);
        public abstract bool IntersectsWithRectangle(Rectangle rectangle);

        public abstract void Draw(GameTime gameTime, SpriteBatch batch, Vector2 offset);
    }
}
