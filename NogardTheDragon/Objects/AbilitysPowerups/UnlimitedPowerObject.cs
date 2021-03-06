﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Abilities;

namespace NogardTheDragon.Objects.AbilitysPowerups
{
    internal class UnlimitedPowerObject : PowerupObject
    {
        public UnlimitedPowerObject(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
        }

        public override void AddPowerup(GameTime gameTime, Player player)
        {
            player.AddPowerup(new UnlimitedPower(gameTime));
            Active = false;
        }

        protected override bool HandleCollision()
        {
            return false;
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            var player = Collides.Find(item => item is Player) as Player;
            if (player == null) return false;

            AddPowerup(gameTime, player);
            return true;
        }
    }
}