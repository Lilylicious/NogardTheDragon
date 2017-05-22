using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Interfaces;

namespace NogardTheDragon.Objects.Enemies
{
    public class BaseEnemy : MovingObject, IDamageable
    {
        public int Health;
        public int Score;
        protected bool Walk;

        public BaseEnemy(Vector2 pos) : base(pos)
        {
            Speed = 2;
            Health = 2;
        }

        public BaseEnemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            UsingSpritesheet = true;
            Source = new Rectangle(0, 48, 18, 40);

            Speed = 2;
            Health = 2;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Health <= 0 && Active)
            {
                NogardGame.KillBonus += 2;
                Active = false;
            }

            Velocity.Y += GravitySpeed;
        }

        protected override bool HandleCollision()
        {
            var player = Collides.Find(item => item is Player) as Player;
            if (player == null) return false;

            player.TakeDamage(1);
            return true;
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            return false;
        }
    }
}