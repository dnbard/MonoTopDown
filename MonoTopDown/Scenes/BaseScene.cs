using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTopDown.Scenes
{
    abstract class BaseScene: DrawableGameComponent
    {
        public string Name { get; set; }
        public bool IsLightingEnabled { get; set; }

        public EventHandler OnActivate { get; set; }
        public EventHandler OnDeactivate { get; set; }

        protected SpriteBatch spriteBatch;

        protected BaseScene() : base(Program.Game)
        {
            spriteBatch = TopDownGame.SpriteBatch;
        }

        public void Activate()
        {
            if (OnActivate != null) OnActivate(this, null);
        }

        public void Deactivate()
        {
            if (OnDeactivate != null) OnDeactivate(this, null);
        }

        public virtual void Update(GameTime time)
        {

        }

        public virtual void Draw(GameTime time)
        {

        }

        public virtual void DrawLighting(GameTime time)
        {

        }
    }
}
