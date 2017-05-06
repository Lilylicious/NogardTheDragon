﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Interfaces;

namespace NogardTheDragon.Objects
{
    public class Projectile : MovingObject
    {
        private readonly MovingObject Owner;

        public Projectile(Vector2 pos, Texture2D tex, Vector2 dir, MovingObject owner)
        {
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
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            SourceRect = Source;
            base.Draw(spriteBatch);
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            var target = Collides.Find(item => item is IDamageable) as IDamageable;
            if (target == null || Owner == target) return false;

            target.TakeDamage(1);
            Active = false;
            return true;
        }
    }
}