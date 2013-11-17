using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoTopDown.Utils
{
    [DebuggerDisplay("Mouse -> X:{Position.X}, Y:{Position.Y}")]
    class MouseManager:GameComponent
    {
        public static MouseManager Instance { get; protected set; }

        public MouseManager() : base(Program.Game)
        {
            Instance = this;
            _previousState = default(MouseState);
        }

        private MouseState _current = default(MouseState);
        private MouseState CurrentState {
            get { return _current; }
            set
            {
                Position = new Vector2(value.X, value.Y);
                Delta = new Vector2(value.X - _previousState.X, value.Y - _previousState.Y);

                IsLeftUp = value.LeftButton == ButtonState.Released 
                    && _previousState.LeftButton == ButtonState.Pressed;
                IsRightUp = value.RightButton == ButtonState.Released 
                    && _previousState.RightButton == ButtonState.Pressed;

                _current = value;
            }
        }
        private MouseState _previousState;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _previousState = CurrentState;
            CurrentState = Mouse.GetState();
        }

        public static bool IsMouseInRectangle(Vector2 position, Vector2 size)
        {
            var mouse = Instance.Position;
            return mouse.X >= position.X && mouse.Y >= position.Y &&
                   mouse.X <= position.X + size.X && mouse.Y <= position.Y + size.Y;
        }

        public Vector2 Position { get; protected set; }
        public Vector2 Delta { get; protected set; }
        public bool IsLeftDown { get { return CurrentState.LeftButton == ButtonState.Pressed; } }
        public bool IsRightDown { get { return CurrentState.RightButton == ButtonState.Pressed; } }
        public bool IsLeftUp { get; protected set; }
        public bool IsRightUp { get; protected set; }
    }
}
