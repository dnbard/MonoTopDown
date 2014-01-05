#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using MonoTopDown.Model.Utils;
using MonoTopDown.Scenes;
using MonoTopDown.Utils;

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
        private Settings settings = Settings.Load(Resources.Get("pathConfig"));
        public Vector2 ViewportSize { get; private set; }

        public TopDownGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            ViewportSize = new Vector2(settings.Width, settings.Height);
            
            this.IsFixedTimeStep = true;
            graphics.PreferredBackBufferWidth = settings.Width;
            graphics.PreferredBackBufferHeight = settings.Height;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();

            //SceneManager.Activate(new MenuScene());
            SceneManager.Activate(new LevelScene());
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
