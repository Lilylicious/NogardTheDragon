using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Abilities
{
    class UnlimitedPower : BasePowerup
    {
        public UnlimitedPower(GameTime gameTime) : base(gameTime)
        {
            Variables.UnlimitedPower = true;
            Timer = 5;
        }

        public override void Remove()
        {
            Variables.UnlimitedPower = false;
            base.Remove();
        }
    }
}
