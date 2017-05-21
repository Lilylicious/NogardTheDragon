﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NogardTheDragon.Abilities;
using NogardTheDragon.Interfaces;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Objects
{
    public class Player : MovingObject, IAbilityUser, IDamageable
    {
        public int Health;
        public int Score;
        public double Timer;
        public double ShootTimer = 0.25;
        public double JumpTimer;

        enum AnimationEnum
        {
            Standing,
            Walking,
            Jumping
        }
        AnimationEnum animationState = AnimationEnum.Standing;

        public Player(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            Speed = 9;
            Health = 3;

            RegisterAbilities();
            UsingSpritesheet = true;
        }

        public Player(Vector2 pos) : base(pos)
        {
            Speed = 9;
            Health = 3;
            
            RegisterAbilities();
        }

        public void RegisterAbilities()
        {
            AddAbility(new DoubleJumpAbility(this));
            AddAbility(new ShootProjectileAbility(this));
        }

        public void TakeDamage(int damage)
        {
            if (Timer == 0)
            {
                var index = FindIndex();

                Timer = 2;
                if (index >= 0)
                    Powerups.RemoveAt(index);
                else
                    Health -= damage;
            }
        }

        private int FindIndex()
        {
            foreach (var powerup in Powerups)
                if (powerup is ArmorPower)
                    return Powerups.IndexOf(powerup);
            return -1;
        }

        public override void Update(GameTime gameTime)
        {
            NogardGame.HealthBonus = Health;
            base.Update(gameTime);
            Gliding = false;

            if (Timer > 0)
            {
                Timer -= gameTime.ElapsedGameTime.TotalSeconds;
                Color = Color.Red;
            }

            else
            {
                Timer = 0;
                Color = Color.White;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                animationState = AnimationEnum.Walking;
                LastFacing = Facing.Right;
                Direction.X = 1f;
                Effects = SpriteEffects.None;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                animationState = AnimationEnum.Walking;
                LastFacing = Facing.Left;
                Direction.X = -1f;
                Effects = SpriteEffects.FlipHorizontally;
            }

            else
            {
                animationState = AnimationEnum.Standing;
                Direction.X = 0f;
                Velocity.X = 0f;
            }

            if (!Airborn && KeyMouseReader.KeyPressed(Keys.Up))
            {
                Velocity.Y = -12;
                Airborn = true;
            }

            while (Airborn == true)
            {
                animationState = AnimationEnum.Jumping;
                break;
            }

            if (KeyMouseReader.KeyPressed(Keys.Space))
                ChangeFrameShooting = true;

            if (Health <= 0)
                NogardGame.GameOverManager.Lose();

            Velocity.Y += GravitySpeed;

            Velocity += Direction * (Speed / Math.Max(1, Math.Abs(Velocity.X))) *
                        (float)gameTime.ElapsedGameTime.TotalSeconds;
            Velocity = new Vector2(MathHelper.Clamp(Velocity.X, -3, 3), MathHelper.Clamp(Velocity.Y, -20, 20));

            frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
            PlayerFrames(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void PlayerFrames(GameTime gameTime)
        {
            switch (animationState)
            {
                case AnimationEnum.Standing:
                    if (!ChangeFrameStanding)
                        SourceRect = new Rectangle(0, 0, 24, 31);

                    if (ChangeFrameShooting)
                    {
                        ShootTimer -= gameTime.ElapsedGameTime.TotalSeconds;
                        if (ShootTimer > 0)
                        {
                            SourceRect.X = 24;
                        }
                        else if (ShootTimer <= 0)
                        {
                            ChangeFrameShooting = false;
                            SourceRect.X = 0;
                            ShootTimer = 0.25;
                        }
                    }

                    ChangeFrameStanding = true;
                    ChangeFrameJumping = false;
                    ChangeFrameWalking = false;
                    break;

                case AnimationEnum.Walking:
                    if (!ChangeFrameWalking)
                        SourceRect = new Rectangle(0, 31, 26, 31);

                    if (frameTimer <= 0)
                    {
                        frameTimer = frameInterval;
                        CurrentFrame++;
                        SourceRect.X = (CurrentFrame % 4) * 26;
                    }

                    if (ChangeFrameShooting)
                    {
                        SourceRect = new Rectangle(0, 93, 26, 31);

                        ShootTimer -= gameTime.ElapsedGameTime.TotalSeconds;
                        if (ShootTimer <= 0)
                        {
                            ChangeFrameShooting = false;
                            SourceRect.Y = 31;
                            ShootTimer = 0.25;
                        }
                    }

                    ChangeFrameWalking = true;
                    ChangeFrameStanding = false;
                    ChangeFrameJumping = false;
                    break;

                case AnimationEnum.Jumping:
                    if (!ChangeFrameJumping)
                        SourceRect = new Rectangle(0, 62, 28, 31);

                    if (frameTimer <= 0)
                    {
                        frameTimer = frameInterval;
                        CurrentFrame++;
                        SourceRect.X = (CurrentFrame % 2) * 28;
                    }

                    ChangeFrameJumping = true;
                    ChangeFrameWalking = false;
                    ChangeFrameStanding = false;
                    break;
            }
        }

        protected override bool HandleCollision()
        {
            return false;
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            return false;
        }
    }
}