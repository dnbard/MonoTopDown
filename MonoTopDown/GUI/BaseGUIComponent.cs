using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MonoTopDown.Images;
using MonoTopDown.Utils;

namespace MonoTopDown.GUI
{
    class BaseGuiComponent:DrawableGameComponent
    {
        public DrawTexture Texture { get; set; }
        protected DrawTexture TextureToDraw { get; set; }
        public Color Overlay { get; set; }
        public float Layer { get; set; }

        public Vector2 Position { get; set; }
        public Vector2 Size { 
            get { return Texture == null ? Vector2.Zero : Texture.Size; }
        }

        protected bool isActive = false;

        private bool _isMouseIn = false;
        protected event EventHandler MouseIn;
        protected event EventHandler MouseOut;
        public event EventHandler MouseLeftClick;

        public BaseGuiComponent() : base(Program.Game)
        {
            Overlay = Color.White;
        }

        public override void Draw(GameTime gameTime)
        {
            if (TextureToDraw != null)
                TextureToDraw.Draw(TopDownGame.SpriteBatch, Position, Overlay, Layer);
        }

        public override void Update(GameTime gameTime)
        {
            var mouse = MouseManager.Instance;
            base.Update(gameTime);

            if (isActive)
            {
                if (MouseManager.IsMouseInRectangle(Position, Size))
                {
                    if (!_isMouseIn && MouseIn != null) MouseIn(this, null);
                    _isMouseIn = true;

                    if (mouse.IsLeftUp && MouseLeftClick != null) 
                        MouseLeftClick(this, null);
                }
                else
                {
                    if (_isMouseIn && MouseOut != null) MouseOut(this, null);
                    _isMouseIn = false;
                }
            }

            if (TextureToDraw == null && Texture != null)
                TextureToDraw = Texture;
        }
    }
}
