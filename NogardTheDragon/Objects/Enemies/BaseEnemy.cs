using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NogardTheDragon.Interfaces;

namespace NogardTheDragon.Objects
{
    internal class BaseEnemy : MovingObject, IDamageable
    {
        private int Health;
        public int Score;
        private bool Walk;

        public BaseEnemy(Vector2 pos, Texture2D tex)
        {
            Speed = 2;
            Health = 1;

            DrawPos = pos;
            Texture = tex;

            SetColorData();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            Velocity.Y += GravitySpeed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            SourceRect = Source;
            base.Draw(spriteBatch);
        }

        protected override void HandleCollision()
        {
            if (CollidingWithPlatform != null)
            {
                LandOnPlatform();
            }

            if (CollidingWith != null && CollidingWith is Player)
                {
                    ((Player)CollidingWith).TakeDamage(1);
                }
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        private void LandOnPlatform()
        {
            DrawPos.Y = CollidingWithPlatform.GetPosition().Y - Texture.Height + 1;
            Airborn = false;
            Direction.Y = 0;
            Velocity.Y = 0;
        }
    }
}