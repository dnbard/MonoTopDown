using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTopDown.Utils;

namespace MonoTopDown.Images
{
    class DrawTexture
    {
        public Texture2D Texture { get; set; }
        
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; }
        
        public Rectangle Source { get; set; }
        public Vector2 Origin { get; set; }

        public Vector2 Size
        {
            get { return new Vector2(Source.Width * Scale.X, Source.Height * Scale.Y); }
        }

        public void Draw(SpriteBatch batch, Vector2 position, Color overlay, float layer)
        {
            batch.Draw(Texture, 
                position, 
                Source, 
                overlay, 
                Rotation, 
                Origin, 
                Scale,
                SpriteEffects.None, 
                layer);
        }

        public DrawTexture(Texture2D texture, ImageSourcePosition position = ImageSourcePosition.LeftTop)
        {
            Texture = texture;
            Rotation = 0f;
            Scale = Vector2.One;

            Source = new Rectangle(0, 0, texture.Width, texture.Height);
            Origin = position == ImageSourcePosition.Middle ? new Vector2((int)(texture.Width * 0.5f), (int)(texture.Height * 0.5f)) 
                : Vector2.Zero;
        }

        public DrawTexture(Texture2D texture, string frameName, ImageSourcePosition position = ImageSourcePosition.LeftTop)
            : this(texture, position)
        {
            var textureKey = texture.Name;
            var frame = ImagesManager.GetFrame(textureKey, frameName);

            if (frame != null)
            {
                Source = new Rectangle(frame.Left, frame.Top, frame.Width, frame.Height);
            }
        }
    }
}
