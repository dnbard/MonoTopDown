using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MonoTopDown.Images;

namespace MonoTopDown.GUI
{
    class BaseGuiComponent:DrawableGameComponent
    {
        public DrawTexture Texture { get; set; }
        public Color Overlay { get; set; }
        public float Layer { get; set; }

        public Vector2 Position { get; set; }

        public BaseGuiComponent() : base(Program.Game)
        {
            Overlay = Color.White;
        }

        public override void Draw(GameTime gameTime)
        {
            if (Texture != null)
                Texture.Draw(TopDownGame.SpriteBatch, Position, Overlay, Layer);
        }
    }
}
