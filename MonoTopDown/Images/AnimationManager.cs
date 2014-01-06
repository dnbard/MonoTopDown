using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoTopDown.Actors;

namespace MonoTopDown.Images
{
    class AnimationManager
    {
        static Dictionary<string, ActorAnimation> animations = new Dictionary<string, ActorAnimation>();

        public static ActorAnimation Get(string textureName, string animation, int frames, bool continuous = true)
        {
            var anName = textureName + animation;

            if (animations.ContainsKey(anName))
            {
                return animations[anName];
            }
            else
            {
                var anEntity = new ActorAnimation(animation, frames, ImagesManager.GetTexture(textureName), continuous);
                animations.Add(anName, anEntity);
                return anEntity;
            }
        }
    }
}
