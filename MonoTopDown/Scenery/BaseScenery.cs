using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MonoTopDown.Collision;
using MonoTopDown.GUI;
using MonoTopDown.Images;
using MonoTopDown.Scenes;
using MonoTopDown.Utils;

namespace MonoTopDown.Scenery
{
    class BaseScenery: BaseGuiComponent
    {
        protected bool Initialized = false;

        public BaseBoundingBox BoundingBox { get; protected set; }

        public new Vector2 Position
        {
            get { return base.Position; }
            set
            {
                base.Position = value;
                if (BoundingBox is RectangleBoundingBox)
                {
                    var bb = BoundingBox as RectangleBoundingBox;
                    bb.Rect = new Rectangle((int)value.X, (int)value.Y, bb.Rect.Width, bb.Rect.Height);
                }
            }
        }

        public new DrawTexture Texture
        {
            get { return base.Texture; }
            set
            {
                base.Texture = value;
                BoundingBox = new RectangleBoundingBox()
                    {
                        Rect = new Rectangle((int) Position.X, (int) Position.Y,
                                             (int) (value.Size.X), (int) (value.Size.Y)),
                    };
            }
        }

        public BaseScenery()
        {
            /*Texture = new DrawTexture(ImagesManager.GetTexture("box")){Scale = new Vector2(4, 4)};
            BoundingBox = new RectangleBoundingBox()
            {
                Rect = new Rectangle((int)Position.X, (int)Position.Y,
                    (int)(Texture.Size.X * Texture.Scale.X), (int)(Texture.Size.Y * Texture.Scale.Y)), 
                    Owner = this
                };
             * */
        }

        protected static LevelScene CurrentLevel
        {
            get
            {
                var scene = SceneManager.CurrentScene as LevelScene;
                return scene;
            }
        }

        protected Vector2 CameraPosition
        {
            get
            {
                var scene = SceneManager.CurrentScene as LevelScene;
                if (scene != null)
                {
                    return scene.Camera.Position;
                }

                return Vector2.Zero;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (Texture != null && isVisible)
            {
                //Texture.Draw(TopDownGame.SpriteBatch, Position - CameraPosition, Overlay, Layer);

                BoundingBox.Draw(gameTime, TopDownGame.SpriteBatch, CameraPosition);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!Initialized)
            {
                Initialized = true;
                CurrentLevel.BoundingBoxes.Add(BoundingBox);
            }
        }
    }
}
