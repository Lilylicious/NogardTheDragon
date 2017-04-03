using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NogardTheDragon.Interfaces;

namespace NogardTheDragon
{
    internal class BaseEnemy : MovingObject, IDamageable
    {
        private bool Airborn;
        private int Health = 3;
        public int Score;

        public BaseEnemy(Vector2 pos, Texture2D tex)
        {
            //Speed = 0;
            //Health = 0;

            DrawPos = pos;
            Texture = tex;

            SetColorData();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HandleCollision();

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

            foreach (Enemy enemy in Enemies)
            {
                spriteBatch.Draw(enemy.texture, enemy.position, Color.White);
            }
        }

        protected override void HandleCollision()
        {
            if (CollidingWith == null || !(Velocity.Y > 0) || !(CollidingWith is Platform)) return;

            DrawPos.Y = CollidingWith.GetPosition().Y - Texture.Height + 1;
            Airborn = false;
            Direction.Y = 0;
            Velocity.Y = 0;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}