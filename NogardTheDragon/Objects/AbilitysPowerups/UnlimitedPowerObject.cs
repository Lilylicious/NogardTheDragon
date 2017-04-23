﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Abilities;

namespace NogardTheDragon.Objects.AbilitysPowerups
{
    class UnlimitedPowerObject : PowerupObject
    {
        public UnlimitedPowerObject(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(CollidingWith is Player)
                AddPowerup(gameTime);
        }

        public override void AddPowerup(GameTime gameTime)
        {
            ((Player)CollidingWith).AddPowerup(new UnlimitedPower(gameTime));
            Active = false;
        }
    }
}