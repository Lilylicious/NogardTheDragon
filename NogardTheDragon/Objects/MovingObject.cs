﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Abilities;
using NogardTheDragon.Interfaces;
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
        protected bool AffectedByGravity = true;
        public bool Airborn;
        public bool ChangeFrameJumping;
        public bool ChangeFrameShooting;

        public bool ChangeFrameStanding;
        public bool ChangeFrameWalking;

        public List<GameObject> Collides = new List<GameObject>();
        protected int CurrentFrame;
        protected Vector2 Direction = new Vector2(0, 0);
        protected double frameTimer = 200, frameInterval = 200;
        public bool Gliding;
        protected bool Gravity = false;
        public Facing LastFacing = Facing.Right;
        public bool Moving;
        protected int NumberOfFrames;
        protected List<BasePowerup> Powerups = new List<BasePowerup>();
        protected float rotation = 0;

        public bool Sinking;
        protected float Speed;
        protected int Step = 1;
        protected double TimeBetweenFrames = 0.1;
        protected double TimeSinceLastFrame;
        protected Vector2 Velocity;
        protected Rectangle PlatformCheckerRectangle;

        protected MovingObject(Vector2 pos, Texture2D tex)
        {
            DrawPos = pos;
            Texture = tex;
            Source = new Rectangle(0, 0, Texture.Width, Texture.Height);

            if (Texture != null)
                SetColorData();
        }

        protected MovingObject(Vector2 pos)
        {
            DrawPos = pos;
        }

        public override void CheckCollision()
        {
            foreach (var gameObject in NogardGame.GamePlayManager.ActiveMap.Objects)
                if (this != gameObject)
                    if (PixelCollision(this, gameObject))
                    {
                        if (!Collides.Contains(gameObject))
                            Collides.Add(gameObject);
                    }
                    else
                    {
                        if (Collides.Contains(gameObject))
                            Collides.Remove(gameObject);
                    }

            Collides.RemoveAll(item => item.Active == false);
        }

        public static bool PixelCollision(GameObject p1, GameObject p2)
        {
            if (!p1.HitBox.Intersects(p2.HitBox) || !p1.CollideEnabled || !p2.CollideEnabled)
                return false;
            if (p1.UsingSpritesheet || p2.UsingSpritesheet)
                return true;

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
                Source,
                Color,
                Rotation,
                Origin,
                Scale,
                Effects,
                LayerDepth);
        }

        protected abstract bool HandleCollision();

        protected abstract bool HandleCollision(GameTime gameTime);

        public virtual void Update(GameTime gameTime)
        {
            CheckCollision();
            HandleCollision();
            HandleCollision(gameTime);
            UpdateAbilitiesPowerups();

            PlatformCheckerRectangle = new Rectangle((int) DrawPos.X, (int) DrawPos.Y + Source.Height, Source.Width, Source.Height * 4);

            DrawPos += Velocity;
            CurrentFrame++;
        }

        public Vector2 GetVelocity()
        {
            return Velocity;
        }

        public void ChangeVelocity(Vector2 vel)
        {
            Velocity += vel;
        }

        public bool LandOnPlatform(int offset, BasePlatform platform)
        {
            if (!(Velocity.Y > 0)) return false;

            var movingObject = this as IDamageable;
            if (Velocity.Y > 25 && Velocity.Y <= 30)
                movingObject?.TakeDamage(1);
            if (Velocity.Y > 30 && Velocity.Y <= 40)
                movingObject?.TakeDamage(2);
            if (Velocity.Y > 40 && Velocity.Y <= 55)
                movingObject?.TakeDamage(3);

            DrawPos.Y = platform.GetPosition().Y - (Texture != null ? Texture.Height : 0) + offset;

            DrawPos.Y = platform.GetPosition().Y - (Texture != null ? Source.Height : 0) + offset;

            Airborn = false;
            ResetDoubleJump();
            Direction.Y = 0;
            Velocity.Y = 0;
            
            return true;
        }

        public bool LandOnHorizontalPlatform(HorizontalPlatform platform)
        {
            LandOnPlatform(1, platform);
            Moving = true;

            if (platform.MoveRight)
                DrawPos.X += 1;
            else
                DrawPos.X -= 1;

            return true;
        }

        public bool LandOnCloudPlatform()
        {
            if (!(Velocity.Y > 0)) return false;

            Sinking = true;
            Airborn = false;
            ResetDoubleJump();
            Velocity.Y *= 0.2f;

            return true;
        }

        public bool LandOnIcePlatform(BasePlatform platform)
        {
            if (!(Velocity.Y > 0)) return false;

            LandOnPlatform(1, platform);
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

        public void SetPosition(Vector2 vector2)
        {
            DrawPos = vector2;
        }
    }
}