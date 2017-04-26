using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NogardTheDragon.Objects
{
    class BaseObstacle : MovingObject
    {
        protected override bool HandleCollision(GameTime gameTime)
        {
            return false;
        }
    }
}
