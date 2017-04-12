using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NogardTheDragon.Interfaces;

namespace NogardTheDragon.Objects
{
    internal class BaseEnemy : MovingObject, IDamageable
    {
        private bool Airborn = true;
        private int Health;
        public int Score;
        bool left;
        bool right;

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

            //if (!Airborn)
            //{
            //    Direction.X = 0f;
            //    Velocity.X = 0f;
            //}

            //Velocity += Direction * (Speed / Math.Max(1, Math.Abs(Velocity.X))) *
            //            (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Velocity = new Vector2(MathHelper.Clamp(Velocity.X, -3, 3), Velocity.Y);

            //for (int i = 0; i < Enemies.Count; i++)
            //{
            //    //If player intersects enemy
            //    if (player.Bounds.Intersects(Enemies[i].Bounds))
            //    {
            //        Enemies.RemoveAt(i);
            //        i--;
            //        continue;
            //    }
            //}
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