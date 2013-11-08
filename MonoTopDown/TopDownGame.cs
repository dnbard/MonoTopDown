#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using MonoTopDown.Scenes;

#endregion

namespace MonoTopDown
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class TopDownGame : Game
    {
        private GraphicsDeviceManager graphics;
        public static SpriteBatch SpriteBatch { get; set; }

        public TopDownGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            SceneManager.Activate(new MenuScene());
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();*/
            SceneManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            SceneManager.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
