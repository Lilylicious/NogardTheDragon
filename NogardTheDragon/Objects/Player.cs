﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public int Health;
        public int Score;
        public double Timer;
        public bool left;
        public bool right;
        private bool test = true;

        private List<BasePowerup> Powerups = new List<BasePowerup>();
        private List<BaseAbility> Abilities = new List<BaseAbility>();

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
            foreach (BasePowerup powerup in Powerups)
                if (powerup is ArmorPower)
                {
                    return Powerups.IndexOf(powerup);
                }
            return -1;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (test)
            {
                AddPowerup(new SlowWorldPower(gameTime));
                AddPowerup(new UnlimitedPower(gameTime));
                test = false;
            }

            if(Airborn)
                Console.WriteLine(GetVelocity().Y + " : " + GetPosition().Y);

            UpdateAbilitiesPowerups();

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

            if (!Airborn && KeyMouseReader.KeyPressed(Keys.Up))
            {
                Velocity.Y = -12;
                Airborn = true;
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

        protected override void HandleCollision()
        {
            if (CollidingWith is Goal)
            {
                NogardGame.GameOverManager.Win();
            }
        }

        public void LandOnPlatform(int offset, bool normal, bool cloud, bool ice)
        {
            if (CollidingWithPlatform == null || !(Velocity.Y > 0)) return;

            if (normal)
            {
                DrawPos.Y = CollidingWithPlatform.GetPosition().Y - Texture.Height + offset;
                Direction.Y = 0;
                Velocity.Y = 0;
            }

            if (normal || cloud)
            {
                Airborn = false;
                ResetDoubleJump();
                if (cloud)
                    Velocity.Y *= 0.2f;
                if (ice)
                {
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
            }

            if (CollidingWith != null && CollidingWith is Goal)
            {
                NogardGame.GameOverManager.Win();
            }
        }

        private void AddAbility(BaseAbility ability)
        {
            Abilities.Add(ability);
        }

        private void AddPowerup(BasePowerup powerup)
        {
            Powerups.Add(powerup);
        }

        private void UpdateAbilitiesPowerups()
        {
            foreach(BaseAbility ability in Abilities)
                ability.Update();

            foreach(BasePowerup powerup in Powerups)
                powerup.Update();

            Powerups.RemoveAll(item => !item.Active);
        }

        private void ResetDoubleJump()
        {
            foreach(var ability in Abilities)
            {
                var jumpAbility = ability as DoubleJumpAbility;
                jumpAbility?.Reset();
            }
        }
    }
}