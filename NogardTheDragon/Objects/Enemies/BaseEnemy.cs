﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Interfaces;
using NogardTheDragon.Objects.Platforms;

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
            var player = Collides.Find(item => item is Player) as Player;
            if (player == null) return false;

            player.TakeDamage(1);
            return true;
        }
    }
}