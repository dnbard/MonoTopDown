using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTopDown.GUI;
using MonoTopDown.Images;

namespace MonoTopDown.Scenes
{
    class MenuScene: BaseScene
    {
        public MenuScene()
        {
            Name = "mainmenu";

            Components.Add(new StaticBackground()
                {Texture = new DrawTexture(ImagesManager.GetTexture("mainmenu"))});

            Components.Add(new BaseGuiComponent(){Texture = new DrawTexture(ImagesManager.GetTexture("menu"), "logo")});
        }

        /*public override void Draw(Microsoft.Xna.Framework.GameTime time)
        {
            var texture = new DrawTexture(ImagesManager.GetTexture("image"), "default");
            texture.Draw(spriteBatch, Vector2.Zero, Color.White, 0f);
        }*/
    }
}
