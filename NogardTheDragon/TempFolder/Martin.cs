using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.TempFolder
{
    class StandardEnemy
    {
        private bool Airborn;
        public int Health;
        public int Score;

        public StandardEnemy(Vector2 pos, Texture2D tex)
        {
            Speed = 0;
            Health = 1;

            DrawPos = pos;
            Texture = tex;

            SetColorData();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HandleCollision();

            if (Health <= 0)
                remove;

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
            if (CollidingWith == null || !(Velocity.Y > 0)) return;

            DrawPos.Y = CollidingWith.GetPosition().Y - Texture.Height + 1;
            Airborn = false;
            Direction.Y = 0;
            Velocity.Y = 0;
        }
    }
}