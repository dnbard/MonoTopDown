using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MonoTopDown.Actors;
using MonoTopDown.Collision;
using MonoTopDown.GUI;
using MonoTopDown.Images;
using MonoTopDown.Scenery;

namespace MonoTopDown.Scenes
{
    class LevelScene : BaseScene
    {
        public Camera Camera { get; private set; }
        public List<BaseBoundingBox> BoundingBoxes = new List<BaseBoundingBox>();

        public LevelScene()
        {
            this.Name = "level";

            Components.Add(new BaseScenery()
            {
                Texture = new DrawTexture(ImagesManager.GetTexture("tree0"))
                {
                    Scale = new Vector2(4, 4)
                },
                Position = new Vector2(600, 400),
            });

            Components.Add(new BaseScenery()
            {
                Texture = new DrawTexture(ImagesManager.GetTexture("tree0"))
                {
                    Scale = new Vector2(4, 4)
                },
                Position = new Vector2(-100, 400),
            });

            /*Components.Add(new BaseGuiComponent()
                {
                    Texture = new DrawTexture(ImagesManager.GetTexture("back"))
                        {
                            Scale = new Vector2(4,4)
                        },
                    Layer = 0
                });*/

            Components.Add(new BaseScenery()
                {
                    Texture = new DrawTexture(ImagesManager.GetTexture("box"))
                    {
                        Scale = new Vector2(4, 4)
                    },
                    Layer = 0.8f,
                    Position = new Vector2(400, 800)
                });

            var player = new Player() {Layer = 1};
            Components.Add(player);

            Camera = new Camera();
            Camera.Target = player;
            Components.Add(Camera);
        }
    }
}
