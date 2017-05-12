using Microsoft.Xna.Framework;
using System;

namespace NogardTheDragon.Objects.Obstacles
{
    internal class BaseObstacle : MovingObject
    {
        protected override bool HandleCollision()
        {
            return false;
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            return false;
        }
    }
}