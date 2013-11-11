using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using MonoTopDown.Model;
using MonoTopDown.Utils;

namespace MonoTopDown.Images
{
    class ImagesManager
    {
        static string[] imageExtensions = {".png", ".jpg"};

        private static Dictionary<string, Texture2D> Textures 
            = new Dictionary<string, Texture2D>();

        private static Dictionary<string, List<ImageFrame>> Frames
            = JSON.Deserialize<Dictionary<string, List<ImageFrame>>>(Resources.Get("pathFrames"));

        public static Texture2D GetTexture(string name)
        {
            Texture2D result;
            if (Textures.TryGetValue(name, out result))
                return result;

            if (LoadTexture(name)) return Textures[name];

            return null;
        }

        public static bool LoadTexture(string name)
        {
            for (var i = 0; i < imageExtensions.Length; i++)
            {
                var path = name + imageExtensions[i];
                if (File.Exists("Content/" + path))
                {
                    Textures.Add(name, Program.Game.Content.Load<Texture2D>(path));
                    return true;
                }
            }

            return false;
        }
    }
}
