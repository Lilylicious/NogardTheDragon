using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Abilities;
using NogardTheDragon.Objects.Platforms;

namespace NogardTheDragon.Objects
{
    public abstract class MovingObject : GameObject
    {
        public enum Facing
        {
            Left,
            Right
        }

        protected List<BaseAbility> Abilities = new List<BaseAbility>();
        protected int Acceleration = 2;
        protected int AccelerationConstant = 2;
        public bool Airborn;
        protected GameObject CollidingWith;
        protected GameObject CollidingWithPlatform;
        protected int CurrentFrame;
        protected Vector2 Direction = new Vector2(0, 0);
        public bool Gliding;
        protected bool Gravity = false;
        protected Facing LastFacing = Facing.Left;
        protected bool Moving = false;
        protected int NumberOfFrames;
        protected List<BasePowerup> Powerups = new List<BasePowerup>();
        protected float Speed;
        protected int Step = 1;
        protected double TimeBetweenFrames = 0.1;
        protected double TimeSinceLastFrame;
        protected Vector2 Velocity;

        public override void CheckCollision()
        {
            var found = false;
            var foundPlatform = false;
            foreach (var gameObject in NogardGame.GamePlayManager.ActiveMap.Objects)
                if (PixelCollision(this, gameObject))
                {
                    // This is just an inverted if statement. 
                    // Instead of nesting found and collidingwith inside of if (this != gameObject), I just reversed the if statement
                    // and told the foreach statement to go to the next thing if this == gameObject.
                    // The reason is that we don't want to collide with ourselves.
                    if (this == gameObject) continue;

                    if (!(gameObject is BasePlatform))
                    {
                        found = true;
                        CollidingWith = gameObject;
                    }
                    else
                    {
                        foundPlatform = true;
                        CollidingWithPlatform = gameObject;
                    }
                }

            if (!found)
                CollidingWith = null;

            if (!foundPlatform)
                CollidingWithPlatform = null;
        }

        public static bool PixelCollision(GameObject p1, GameObject p2)
        {
            if (!p1.HitBox.Intersects(p2.HitBox))
                return false;
            float collLeft = MathHelper.Max(p1.Dest.X, p2.Dest.X);
            float collTop = MathHelper.Max(p1.Dest.Y, p2.Dest.Y);
            float collRight = MathHelper.Min(p1.Dest.Right, p2.Dest.Right);
            float collBottom = MathHelper.Min(p1.Dest.Bottom, p2.Dest.Bottom);
            for (var col = (int) collLeft; col < collRight; col++)
            for (var row = (int) collTop; row < collBottom; row++)
                if (p1.GetPixel(col, row).A > 127
                    && p2.GetPixel(col, row).A > 127)
                    return true;
            return false;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Texture,
                DrawPos,
                SourceRect,
                Color,
                Rotation,
                Origin,
                Scale,
                Effects,
                LayerDepth);
        }

        protected abstract bool HandleCollision(GameTime gameTime);

        public virtual void Update(GameTime gameTime)
        {
            CheckCollision();
            HandleCollision(gameTime);
            UpdateAbilitiesPowerups();

            DrawPos += Velocity;
        }

        public Vector2 GetVelocity()
        {
            return Velocity;
        }

        public void ChangeVelocity(Vector2 vel)
        {
            Velocity += vel;
        }

        public bool LandOnPlatform(int offset)
        {
            if (CollidingWithPlatform == null || !(Velocity.Y > 0)) return false;

            DrawPos.Y = CollidingWithPlatform.GetPosition().Y - Texture.Height + offset;
            Airborn = false;
            ResetDoubleJump();
            Direction.Y = 0;
            Velocity.Y = 0;
            return true;
        }

        public bool LandOnCloudPlatform()
        {
            if (CollidingWithPlatform == null || !(Velocity.Y > 0)) return false;

            Airborn = false;
            ResetDoubleJump();
            Velocity.Y *= 0.2f;
            return true;
        }

        public bool LandOnIcePlatform()
        {
            if (CollidingWithPlatform == null || !(Velocity.Y > 0)) return false;

            LandOnPlatform(1);
            Gliding = true;

            switch (LastFacing)
            {
                case Facing.Right:
                    Direction.X += 1;
                    Velocity.X += 1;
                    break;
                case Facing.Left:
                    Direction.X -= 1;
                    Velocity.X -= 1;
                    break;
            }
            return true;
        }

        public void AddAbility(BaseAbility ability)
        {
            Abilities.Add(ability);
        }

        public void AddPowerup(BasePowerup powerup)
        {
            Powerups.Add(powerup);
        }

        private void UpdateAbilitiesPowerups()
        {
            foreach (var ability in Abilities)
                ability.Update();

            foreach (var powerup in Powerups)
                powerup.Update();

            Powerups.RemoveAll(item => !item.Active);
        }

        private void ResetDoubleJump()
        {
            foreach (var ability in Abilities)
            {
                var jumpAbility = ability as DoubleJumpAbility;
                jumpAbility?.Reset();
            }
        }

        public void SetVelocity(Vector2 vector2)
        {
            Velocity = vector2;
        }
    }
}