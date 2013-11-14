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

        protected List<IGameComponent> Components = new List<IGameComponent>();

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

        public override void Update(GameTime time)
        {
            foreach (IUpdateable component in Components.OfType<IUpdateable>())
                component.Update(time);
        }

        public override void Draw(GameTime time)
        {
            foreach (IDrawable component in Components.OfType<IDrawable>())
                component.Draw(time);
        }

        public virtual void DrawLighting(GameTime time)
        {

        }
    }
}
