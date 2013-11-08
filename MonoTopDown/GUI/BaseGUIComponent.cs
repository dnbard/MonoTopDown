using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonoTopDown.GUI
{
    abstract class BaseGUIComponent:DrawableGameComponent
    {
        protected BaseGUIComponent() : base(Program.Game)
        {
            
        }
    }
}
