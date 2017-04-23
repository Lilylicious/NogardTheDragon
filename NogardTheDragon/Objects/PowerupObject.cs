using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Abilities;

namespace NogardTheDragon.Objects
{
    class PowerupObject : MovingObject
    {
        private BasePowerup Powerup;

        public PowerupObject(BasePowerup powerup)
        {
            Powerup = powerup;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            SourceRect = Source;
            base.Draw(spriteBatch);
        }

        protected override void HandleCollision()
        {
            var Player = CollidingWith as Player;
            if (Player == null) return;
            Player.AddPowerup(Powerup);
            Active = false;
        }
    }
}
