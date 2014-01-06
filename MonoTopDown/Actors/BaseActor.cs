using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoTopDown.Collision;
using MonoTopDown.GUI;
using MonoTopDown.Images;
using MonoTopDown.Scenes;

namespace MonoTopDown.Actors
{
    class BaseActor: BaseGuiComponent
    {
        protected Dictionary<string, ActorAnimation> Animations = new Dictionary<string, ActorAnimation>();
        protected List<BoundingPoint> BoundingPoints = new List<BoundingPoint>();

        protected ActorAnimation CurrentAnimation;
        protected int AnimationSpeed = 12;

        protected double AnimationDelay {
            get
            {
                if (AnimationSpeed > 0)
                    return 1000 / AnimationSpeed ;
                return 999;
            }
        }

        protected bool isAnimationUpdating = false;
        protected TimeSpan _lastAnimationUpdate = default(TimeSpan);

        protected Actions CurrentAction;
        protected Direction Direction;

        protected int Speed = 8;

        protected int JumpPower = 0;
        protected int MaxJumpPower = 60;
        protected int JumpPowerIncrement = 0;
        protected bool jumpKey = false;

        protected internal bool ApplyGravity = true;
        protected internal bool CanMoveRight = true;
        protected internal bool CanMoveLeft = true;


        protected bool CanJump
        {
            get { return JumpsCount < 2 && !jumpKey; }
        }

        private bool isFreeFall;

        protected int JumpsCount = 0;
        protected float fallspeed = 12;

        public BaseActor(string name)
        {
            
        }

        protected void SetWaitAnimation()
        {
            CurrentAnimation = Direction == Direction.Left ? Animations["waitleft"] : Animations["waitright"];
        }

        protected void SetJumpAnimation()
        {
            if (!IsCurrentAnimationJump())
                CurrentAnimation = Direction == Direction.Left ? Animations["jumpleft"] : Animations["jumpright"]; 
        }

        protected bool IsCurrentAnimationJump()
        {
            return CurrentAnimation != null && (CurrentAnimation.Name == "jumpleft" || CurrentAnimation.Name == "jumpright");
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
            CheckBoindingPoints();
            ApplyGravitation();
        }

        protected static LevelScene CurrentLevel
        {
            get
            {
                var scene = SceneManager.CurrentScene as LevelScene;
                return scene;
            }
        }

        protected void CheckBoindingPoints()
        {
            var offset = new Point((int) Position.X, (int) Position.Y);

            ApplyGravity = true;
            CanMoveRight = true;
            CanMoveLeft = true;

            if (BoundingPoints.Count > 0)
            {
                foreach (var boundingBox in CurrentLevel.BoundingBoxes)
                {
                    foreach (var boundingPoint in BoundingPoints)
                    {
                        var intersection = boundingBox.IntersectsWithPoint(boundingPoint.Point + offset);

                        if (intersection)
                        {
                            if (boundingPoint.Intersection != null)
                                boundingPoint.Intersection(this);
                        }
                        else
                        {
                            if (boundingPoint.NoIntersection != null)
                                boundingPoint.NoIntersection(this);
                        }
                    }
                }
            }
        }

        protected virtual void DoAction()
        {
            switch (CurrentAction)
            {
                case Actions.MoveLeft:
                    if (CanMoveLeft)
                        Position = new Vector2(Position.X - Speed * (isFreeFall ? 0.5f : 1), this.Position.Y);
                    break;
                case Actions.MoveRight:
                    if (CanMoveRight)
                        Position = new Vector2(Position.X + Speed * (isFreeFall ? 0.5f : 1), this.Position.Y);
                    break;
            }

            if (JumpPower > 1)
            {
                JumpPower--;
                this.Position = new Vector2(this.Position.X, (float) (this.Position.Y - Speed * 0.7 * (Math.Log(JumpPower))));

                SetJumpAnimation();
            }
            else
            {
                JumpPower = 0;
            }
        }

        protected virtual void ApplyGravitation()
        {
            isFreeFall = ApplyGravity;

            if (isFreeFall)
            {
                Position = new Vector2(Position.X, Position.Y + fallspeed);
                
                fallspeed += 0.1f;
                SetJumpAnimation();
            }
            else
            {
                JumpsCount = 0;
                fallspeed = 12;
                SetWaitAnimation();
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
                Texture.Draw(TopDownGame.SpriteBatch, Position - CameraPosition, Overlay, Layer);
        }
    }
}
