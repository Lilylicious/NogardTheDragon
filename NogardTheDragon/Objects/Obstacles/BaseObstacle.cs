using Microsoft.Xna.Framework;

namespace NogardTheDragon.Objects
{
    internal class BaseObstacle : MovingObject
    {
        protected override bool HandleCollision(GameTime gameTime)
        {
            return false;
        }
    }
}