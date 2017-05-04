using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Platforms
{
    internal class Platform : BasePlatform
    {
        public Platform(Vector2 pos, Texture2D tex)
            : base(pos, tex)
        {
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            var found = false;
            foreach (GameObject gameObject in Collides)
            {
                if (!(gameObject is BasePlatform))
                {
                    var movingObject = gameObject as MovingObject;
                    movingObject?.LandOnPlatform(1, this);
                    found = true;
                }
            }
            
            return found;
        }
    }
}