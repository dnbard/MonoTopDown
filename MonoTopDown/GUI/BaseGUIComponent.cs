using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonoTopDown.GUI
{
    abstract class BaseGuiComponent:DrawableGameComponent
    {
        protected BaseGuiComponent() : base(Program.Game)
        {
            
        }
    }
}
