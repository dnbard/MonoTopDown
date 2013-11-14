using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonoTopDown.GUI
{
    class MouseCursor:DrawableGameComponent 
    {
        public MouseCursor(Game game) : base(game)
        {
            IsDefaultCursor = true;
        }

        private bool _default;
        public bool IsDefaultCursor
        {
            get { return _default; }
            set
            {
                _default = value;
                Program.Game.IsMouseVisible = value;
            }
        }


    }
}
