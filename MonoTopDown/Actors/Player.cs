using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoTopDown.Collision;
using MonoTopDown.Images;

namespace MonoTopDown.Actors
{
    class Player: BaseActor
    {
        private static string name = "suit"; 

        public Player() : base(name)
        {
            Position = new Vector2(400, 400);

            Animations.Add("left", AnimationManager.Get(name, "left", 8));
            Animations.Add("right", AnimationManager.Get(name, "right", 8));
            Animations.Add("waitright", AnimationManager.Get(name, "waitright", 1));
            Animations.Add("waitleft", AnimationManager.Get(name, "waitleft", 1));
            Animations.Add("jumpleft", AnimationManager.Get(name, "jumpleft", 1));
            Animations.Add("jumpright", AnimationManager.Get(name, "jumpright", 1));

            Direction = Direction.Right;
            CurrentAction = Actions.StandStill;

            SetWaitAnimation();
            Texture = CurrentAnimation.Frame;

            BoundingPoints.Add(new BoundingPoint()
            {
                X = 4 * 4,
                Y = 35 * 4 + 1,
                Intersection = new ActorEventHandler(target => target.ApplyGravity = false)
            });

            BoundingPoints.Add(new BoundingPoint()
            {
                X = 12 * 4,
                Y = 35 * 4 + 1,
                Intersection = new ActorEventHandler(target => target.ApplyGravity = false)
            });

            BoundingPoints.Add(new BoundingPoint()
            {
                X = 15 * 4 + 1,
                Y = 12 * 4,
                Intersection = new ActorEventHandler(target => target.CanMoveRight = false)
            });

            BoundingPoints.Add(new BoundingPoint()
            {
                X = 2 * 4 - 1,
                Y = 12 * 4,
                Intersection = new ActorEventHandler(target => target.CanMoveLeft = false)
            });
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (gameTime.TotalGameTime.TotalMilliseconds - _lastAnimationUpdate.TotalMilliseconds > AnimationDelay)
            {
                if (jumpKey && Keyboard.GetState().IsKeyUp(Keys.Up)) jumpKey = false;

                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if (CanJump)
                    {
                        fallspeed = 12;
                        JumpsCount++;
                        SetJumpAnimation();
                        JumpPower = 40;
                        JumpPowerIncrement = 40;
                        isAnimationUpdating = true;
                        jumpKey = true;
                    } 
                    else if (jumpKey)
                    {
                        if (JumpPowerIncrement < MaxJumpPower)
                        {
                            var increment = JumpPowerIncrement + 20 < MaxJumpPower
                                                ? 20
                                                : MaxJumpPower - JumpPowerIncrement;
                            JumpPower += increment;
                            JumpPowerIncrement += increment;
                        }
                    }
                }
                
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    if (IsCurrentAnimationJump())
                        CurrentAnimation = Animations["left"];
                    isAnimationUpdating = true;
                    CurrentAction = Actions.MoveLeft;
                    Direction = Direction.Left;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    if (IsCurrentAnimationJump())
                        CurrentAnimation = Animations["right"];
                    isAnimationUpdating = true;
                    CurrentAction = Actions.MoveRight;
                    Direction = Direction.Right;
                }
                else
                {
                    isAnimationUpdating = false;
                }

                if (isAnimationUpdating)
                {
                    CurrentAnimation.Update();
                    Texture = CurrentAnimation.Frame;
                }
                else
                {
                    CurrentAnimation.SetZeroFrame();
                    Texture = CurrentAnimation.Frame;
                    CurrentAction = Actions.StandStill;
                    SetWaitAnimation();
                }

                _lastAnimationUpdate = gameTime.TotalGameTime;
            }

            DoAction();
        }
    }
}
