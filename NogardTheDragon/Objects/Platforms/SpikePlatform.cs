using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NogardTheDragon.Interfaces;

namespace NogardTheDragon.Objects
{
    class SpikePlatform : BasePlatform
    {
        public SpikePlatform(Vector2 pos, Texture2D tex)
            :base(pos, tex)
        {

        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            var o = CollidingWith as MovingObject;
            if (o == null) return false;

            o.LandOnPlatform(1);

            var d = o as IDamageable;
            d?.TakeDamage(1);
            return true;
        }
    }
}
