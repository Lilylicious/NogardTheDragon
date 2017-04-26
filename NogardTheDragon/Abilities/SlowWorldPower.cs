using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Abilities
{
    class SlowWorldPower : BasePowerup
    {
        public SlowWorldPower(GameTime gameTime) : base(gameTime)
        {
            Variables.WorldSpeed = 2;
            Timer = 5;
        }

        public override void Remove()
        {
            Variables.WorldSpeed = Variables.DefaultWorldSpeed;
            base.Remove();
        }
    }
}
