using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTopDown.Utils
{
    static class SpriteBatchExtend
    {
        private static Texture2D Texture = null;

        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 begin, Vector2 end, Color color, int width = 1)
        {
            if (Texture == null)
            {
                Texture = new Texture2D(Program.Game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
                Int32[] pixel = { 0xFFFFFF }; 
                Texture.SetData<Int32>(pixel, 0, Texture.Width * Texture.Height);
            }

            Rectangle r = new Rectangle((int)begin.X, (int)begin.Y, (int)(end - begin).Length()+width, width);
            Vector2 v = Vector2.Normalize(begin - end);
            float angle = (float)Math.Acos(Vector2.Dot(v, -Vector2.UnitX));
            if (begin.Y > end.Y) angle = MathHelper.TwoPi - angle;
            spriteBatch.Draw(Texture, r, null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
        }   
    }
}
