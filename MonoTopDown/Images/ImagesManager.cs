using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using MonoTopDown.Model;
using MonoTopDown.Utils;
using Microsoft.CSharp;

namespace MonoTopDown.Images
{
    class ImagesManager
    {
        private static Dictionary<string, Texture2D> Textures 
            = new Dictionary<string, Texture2D>();

        private static readonly Dictionary<string, Dictionary<string, ImageFrame>> Frames
            = InitFrames();

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
            for (var i = 0; i < Resources.ImageExtensions.Length; i++)
            {
                var path = name + Resources.ImageExtensions[i];
                if (File.Exists("Content/images/" + path))
                {
                    var texture = Program.Game.Content.Load<Texture2D>("images/" + path);
                    texture.Name = name;
                    Textures.Add(name, texture);
                    return true;
                }
            }

            return false;
        }

        public static ImageFrame GetFrame(string textureName, string frameName)
        {
            var textureFrames = Frames[textureName];
            if (textureFrames == null) return null;

            return textureFrames[frameName];
        }

        private static Dictionary<string, Dictionary<string, ImageFrame>> InitFrames()
        {
            var result = new Dictionary<string, Dictionary<string, ImageFrame>>();

            var files = Directory.GetFiles("Content/images");
            foreach (var file in files)
            {
                if (Path.GetExtension(file) != ".json") continue;
                var filename = Path.GetFileNameWithoutExtension(file);
                var json = JSON.Deserialize<ImageFrame[]>(file);
                var holder = json.ToDictionary
                    (e => ImagesUtils.ExtractKeyFromFilepath(e.Filename), e => e);
                result.Add(ImagesUtils.ExtractKeyFromFilepath(filename), holder);
            }

            return result;
        }
    }
}
