using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoTopDown.Images;

namespace MonoTopDown.GUI
{
    class GuiButton: BaseGuiComponent
    {
        public DrawTexture HoverTexture { get; set; }
        public bool FadeEffect { get; set; }

        private float _fadeValue = 0;
        private int _fadeDirection = 0;
        private float FadeValue
        {
            set
            {
                if (value < 0) value = 0;
                else if (value > 1) value = 1;
                _fadeValue = value;
            }
            get { return _fadeValue; }
        }

        public GuiButton()
        {
            MouseIn += OnMouseIn;
            MouseOut += OnMouseOut;

            FadeEffect = true;
            isActive = true;
        }

        private static void OnMouseOut(object sender, EventArgs args)
        {
            var self = sender as GuiButton;
            if (self == null) return;

            if (self.Texture != null)
                self.TextureToDraw = self.Texture;

            self._fadeDirection = -1;
        }

        private static void OnMouseIn(object sender, EventArgs args)
        {
            var self = sender as GuiButton;
            if (self == null) return;

            if (self.HoverTexture != null)
                self.TextureToDraw = self.HoverTexture;

            self._fadeDirection = 1;
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (!isVisible) return;

            if (!FadeEffect)
                base.Draw(gameTime);
            else
            {
                if (Texture != null)
                    Texture.Draw(TopDownGame.SpriteBatch, Position, Overlay * (1 - FadeValue), Layer);
                if (HoverTexture != null)
                    HoverTexture.Draw(TopDownGame.SpriteBatch, Position, Overlay * FadeValue, Layer);
            }
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);

            if (FadeEffect) FadeValue += 0.0475f * _fadeDirection;
        }
    }
}
