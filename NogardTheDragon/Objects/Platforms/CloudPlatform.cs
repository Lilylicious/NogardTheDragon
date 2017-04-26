using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Platforms
{
    internal class CloudPlatform : BasePlatform
    {
        public CloudPlatform(Vector2 pos, Texture2D tex)
            : base(pos, tex)
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