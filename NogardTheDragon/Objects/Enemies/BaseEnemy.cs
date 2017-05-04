﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Interfaces;
using NogardTheDragon.Objects.Platforms;

namespace NogardTheDragon.Objects.Enemies
{
    public class BaseEnemy : MovingObject, IDamageable
    {
        public int Health;
        public int Score;
        private bool Walk;

        public BaseEnemy(Vector2 pos)
        {
            Speed = 2;
            Health = 1;

            DrawPos = pos;
        }
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

        protected override bool HandleCollision()
        {
            var player = Collides.Find(item => item is Player) as Player;
            if (player == null) return false;

            player.TakeDamage(1);
            return true;
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}