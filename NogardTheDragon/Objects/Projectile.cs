using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Interfaces;

namespace NogardTheDragon.Objects
{
    public class Projectile : MovingObject
    {
        private readonly MovingObject Owner;

        public Projectile(Vector2 pos, Texture2D tex, Vector2 dir, MovingObject owner) : base(pos, tex)
        {
            Source = new Rectangle(0, 144, 48, 48);
            UsingSpritesheet = true;

            Speed = 10;

            DrawPos = pos;
            Texture = tex;
            Direction = dir;
            Owner = owner;

            SetColorData();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Velocity = Direction * Speed;

            frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;

            if (frameTimer <= 0)
            {
                frameTimer = frameInterval;
                frame++;
                Source = new Rectangle((CurrentFrame % 3) * 32, Source.Y, Source.Width, Source.Height);
            }
        }

        protected override bool HandleCollision()
        {
            var target = Collides.Find(item => item is IDamageable) as IDamageable;
            if (target == null || Owner == target) return false;

            target.TakeDamage(1);
            Active = false;
            return true;
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            return false;
        }
    }
}