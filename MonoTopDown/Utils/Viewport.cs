using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonoTopDown.Utils
{
    class Viewport
    {
        public static Vector2 GetViewportSize()
        {
            var viewport = TopDownGame.SpriteBatch.GraphicsDevice.Viewport;
            return new Vector2(viewport.Width, viewport.Height);
        }

        public static Vector2 GetViewportCenter()
        {
            return GetViewportSize() * 0.5f;
        }
    }
}
