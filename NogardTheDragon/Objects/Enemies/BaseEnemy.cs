using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Interfaces;

namespace NogardTheDragon.Objects.Enemies
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

        public void TakeDamage(int damage)
        {
            Health -= damage;
            NogardGame.KillBonus += 2;
            Active = false;
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

        protected override bool HandleCollision(GameTime gameTime)
        {
            return false;
        }
    }
}