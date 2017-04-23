using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NogardTheDragon.Abilities
{
    class ArmorPower : BasePowerup
    {
        public ArmorPower(GameTime gameTime) : base(gameTime)
        {
            Timer = 30;
        }
    }
}
