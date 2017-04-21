using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.Objects
{
    class SpikePlatform : BasePlatform
    {
        public SpikePlatform(Vector2 pos, Texture2D tex)
            :base(pos, tex)
        {

        }

        protected override void HandleCollision()
        {
            if (CollidingWith is Player)
            {
                ((Player)CollidingWith).LandOnPlatform(1, true, false, false);
                ((Player)CollidingWith).TakeDamage(1);
            }
            base.HandleCollision();
        }
    }
}
