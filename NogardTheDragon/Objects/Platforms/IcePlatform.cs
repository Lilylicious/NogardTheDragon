using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Platforms
{
    internal class IcePlatform : BasePlatform
    {
        public IcePlatform(Vector2 pos, Texture2D tex)
            : base(pos, tex)
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