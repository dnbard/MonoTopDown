#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

#endregion

namespace MonoTopDown
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Game = new TopDownGame();
            Game.Run();
        }

        public static TopDownGame Game;
    }
#endif
}
