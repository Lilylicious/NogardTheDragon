using Microsoft.Xna.Framework;
using System;

namespace NogardTheDragon.Objects.Obstacles
{
    internal class BaseObstacle : MovingObject
    {
        protected override bool HandleCollision()
        {
            throw new NotImplementedException();
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}