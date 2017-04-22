using System;
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
        public bool left;
        public bool right;

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
                DoubleJumpAbility?.Reset();
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
        }
    }
}