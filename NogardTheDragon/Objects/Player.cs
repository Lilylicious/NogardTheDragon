﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NogardTheDragon.Abilities;
using NogardTheDragon.Interfaces;
using NogardTheDragon.Objects.Platforms;

namespace NogardTheDragon.Objects
{
    public class Player : MovingObject, IAbilityUser, IDamageable
    {
        private bool Airborn;
        private DoubleJumpAbility DoubleJumpAbility;
        public int Health;
        public int Score;
        private ShootProjectileAbility ShootProjectileAbility;
        public double Timer;
        bool left;
        bool right;

        public Player(Vector2 pos, Texture2D tex)
        {
            Speed = 9;
            Health = 3;

            DrawPos = pos;
            Texture = tex;

            SetColorData();

            RegisterAbilities();
        }

        public void RegisterAbilities()
        {
            DoubleJumpAbility = new DoubleJumpAbility(this);
            ShootProjectileAbility = new ShootProjectileAbility(this);
        }

        public void TakeDamage(int damage)
        {

            if (Timer == 0)
            {
                Health -= damage;
                Timer = 2;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

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

            if (Keyboard.GetState().IsKeyDown(Keys.K))
            {
                TakeDamage(1);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                left = false;
                right = true;
                Direction.X = 1f;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                right = false;
                left = true;
                Direction.X = -1f;
            }

            else
            {
                Direction.X = 0f;
                Velocity.X = 0f;
            }

            if (KeyMouseReader.KeyPressed(Keys.Space))
                ShootProjectileAbility?.TriggerAbility();

            if (!Airborn && KeyMouseReader.KeyPressed(Keys.Up))
            {
                Velocity.Y = -12f;
                Airborn = true;
            }
            else if (KeyMouseReader.KeyPressed(Keys.Up))
            {
                DoubleJumpAbility?.TriggerAbility();
            }

            if (Health <= 0)
                NogardGame.GameOverManager.Lose();

                Velocity.Y += GravitySpeed;

                Velocity += Direction * (Speed / Math.Max(1, Math.Abs(Velocity.X))) *
                            (float)gameTime.ElapsedGameTime.TotalSeconds;
                Velocity = new Vector2(MathHelper.Clamp(Velocity.X, -3, 3), Velocity.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            SourceRect = Source;
            base.Draw(spriteBatch);
        }

        protected override bool HandleCollision()
        {
            if (CollidingWith == null || !(Velocity.Y > 0)) return false;

            if (CollidingWith is Platform || CollidingWith is MovingPlatform)
            {
                LandOnPlatform();
            }
            else if (CollidingWith is SpikePlatform)
            {
                LandOnPlatform();
                TakeDamage(1);
            }
            else if (CollidingWith is CloudPlatform)
            {
                Airborn = false;
                Velocity.Y *= 0.3f;
                DoubleJumpAbility?.Reset();
            }
            else if (CollidingWith is Goal)
            {
                NogardGame.GameOverManager.Win();
            }
            else if (CollidingWith is IcePlatform)
            {
                LandOnPlatform();

                if (right)
                {
                    Direction.X += 1;
                    Velocity.X += 1;
                }
                else if (left)
                {
                    Direction.X -= 1;
                    Velocity.X -= 1;
                }
            }

            return true;
        }

        private void LandOnPlatform()
        {
            if(Texture != null)
                DrawPos.Y = CollidingWith.GetPosition().Y - Texture.Height + 1;
            Airborn = false;
            Direction.Y = 0;
            Velocity.Y = 0;
            DoubleJumpAbility?.Reset();
        }
    }
}