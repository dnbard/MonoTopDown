using Microsoft.Xna.Framework;
using MonoTopDown.Utils;

namespace MonoTopDown.GUI
{
    sealed class StaticBackground : BaseGuiComponent
    {
        private bool initialized = false;

        public StaticBackground()
        {
   
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);

            if (!initialized && Texture != null)
            {
                var size = Viewport.GetViewportSize();
                if (size.X > Texture.Source.Width)
                    Texture.Scale = new Vector2(size.X / Texture.Source.Width, Texture.Scale.Y);
                else Position = new Vector2((size.X - Texture.Source.Width) * 0.5f, Position.Y);
                if (size.Y > Texture.Source.Height)
                    Texture.Scale = new Vector2(Texture.Scale.X, size.Y / Texture.Source.Height);

                initialized = true;
            }
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (Texture != null)
                Texture.Draw(TopDownGame.SpriteBatch, Position, Overlay, Layer);
        }


    }
}
