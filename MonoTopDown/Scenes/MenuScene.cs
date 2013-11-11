using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MonoTopDown.Images;

namespace MonoTopDown.Scenes
{
    class MenuScene: BaseScene
    {
        public MenuScene()
        {
            Name = "mainmenu";
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime time)
        {
            var texture = new DrawTexture(ImagesManager.GetTexture("image"), "default");
            texture.Draw(spriteBatch, Vector2.Zero, Color.White, 0f);
        }
    }
}
