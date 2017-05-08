using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Platforms
{
    public class Platform : BasePlatform
    {
        public Platform(Vector2 pos, Texture2D tex)
            : base(pos, tex)
        {
        }
        public Platform(Vector2 pos)
            : base(pos)
        {
        }
        protected override bool HandleCollision()
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