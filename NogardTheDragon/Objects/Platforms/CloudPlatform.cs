using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.Objects.Platforms
{
    class CloudPlatform : BasePlatform
    {
        public CloudPlatform(Vector2 pos, Texture2D tex)
            :base(pos, tex)
        {
            
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            var o = CollidingWith as MovingObject;
            o?.LandOnCloudPlatform();
            return true;
        }
    }
}
