using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.Objects.Platforms
{
    class IcePlatform : BasePlatform
    {
        public IcePlatform(Vector2 pos, Texture2D tex)
            :base(pos, tex)
        {

        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            var o = CollidingWith as MovingObject;
            if (o != null && !o.Gliding)
            {
                o.LandOnIcePlatform();
                return true;
            }
            return false;
        }
    }
}
