using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTopDown.Images;

namespace MonoTopDown.Actors
{
    class ActorAnimation
    {
        private Dictionary<string, DrawTexture> textures;

        private string name;
        private int number = 0;
        private int framesCount = 0;

        public string Name
        {
            get { return name; }
        }

        public DrawTexture Frame
        {
            get
            {
                return textures[name + number];
            }
        }

        private int increment = 1;
        public int Increment
        {
            get { return increment; }
            set 
            { 
                if (value > 1 || value < -1 || value == 0) return;
                increment = value;
            }
        }

        private bool Continous = true;

        public ActorAnimation(string _name, int frames, Texture2D texture, bool continous = true)
        {
            this.name = _name;
            this.framesCount = frames;
            this.Continous = continous;

            textures = new Dictionary<string, DrawTexture>(frames);

            for (int i = 0; i < frames; i++)
            {
                var txName = name + i;
                var tx = new DrawTexture(texture, txName);
                tx.Scale = new Vector2(2, 2);
                textures.Add(txName, tx);
            }
        }

        public void Update()
        {
            if (Increment > 0)
            {
                if (!Continous && number < framesCount - 1 || Continous)
                {
                    number++;
                    if (number == framesCount) number = 0;
                }
            }
            else 
            {
                number--;
                if (number < 0 && Continous) number = framesCount - 1;
            }
        }

        public void SetZeroFrame()
        {
            number = 0;
        }
    }
}
