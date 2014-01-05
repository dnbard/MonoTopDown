using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonoTopDown.Actors
{
    class Camera: GameComponent
    {
        private Vector2 offset; 

        public Vector2 Position { get; set; }
        public BaseActor Target { get; set; }

        public Camera() : base(Program.Game)
        {
            offset = Program.Game.ViewportSize*0.5f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Target != null)
                Position = Target.Position - offset;
        }
    }
}
