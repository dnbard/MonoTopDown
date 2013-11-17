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

            var center = Utils.Viewport.GetViewportCenter();

            var logo = new BaseGuiComponent();
            logo.Texture = new DrawTexture(ImagesManager.GetTexture("menu"), "logo");
            var left = center.X - logo.Texture.Size.X*0.5f;
            logo.Position = new Vector2(left, logo.Position.Y);
            Components.Add(logo);

            var newGameButton = new GuiButton();
            newGameButton.Texture = new DrawTexture(ImagesManager.GetTexture("menu"), "newgame0");
            newGameButton.HoverTexture = new DrawTexture(ImagesManager.GetTexture("menu"), "newgame1");
            newGameButton.Position = new Vector2(left, 300);
            Components.Add(newGameButton);

            var quitButton = new GuiButton();
            quitButton.Texture = new DrawTexture(ImagesManager.GetTexture("menu"), "quit0");
            quitButton.HoverTexture = new DrawTexture(ImagesManager.GetTexture("menu"), "quit1");
            quitButton.Position = new Vector2(left, newGameButton.Texture.Size.Y + newGameButton.Position.Y);
            quitButton.MouseLeftClick += (sender, args) => Program.Game.Exit();
            Components.Add(quitButton);
        }
    }
}
