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

        public Player(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            Speed = 9;
            Health = 3;

            RegisterAbilities();

            Source = new Rectangle(48, 48, 48, 48);
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
                LastFacing = Facing.Right;
                Direction.X = 1f;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                LastFacing = Facing.Left;
                Direction.X = -1f;
                Effects = SpriteEffects.FlipHorizontally;
            }

            else
            {
                Direction.X = 0f;
                Velocity.X = 0f;
            }

            if (!Airborn && KeyMouseReader.KeyPressed(Keys.Up))
            {
                Velocity.Y = -12;
                Airborn = true;
            }

            if (Health <= 0)
                NogardGame.GameOverManager.Lose();

            Velocity.Y += GravitySpeed;

            Velocity += Direction * (Speed / Math.Max(1, Math.Abs(Velocity.X))) *
                        (float) gameTime.ElapsedGameTime.TotalSeconds;
            Velocity = new Vector2(MathHelper.Clamp(Velocity.X, -3, 3), MathHelper.Clamp(Velocity.Y, -20, 20));

            frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;

            if (frameTimer <= 0)
            {
                frameTimer = frameInterval;
                frame++;
                Source = new Rectangle((CurrentFrame % 4) * 32, Source.Y, Source.Width, Source.Height);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
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