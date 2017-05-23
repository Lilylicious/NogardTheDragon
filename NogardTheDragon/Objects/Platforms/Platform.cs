using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Platforms
{
    public class Platform : BasePlatform
    {
        public Platform(Vector2 pos, Texture2D tex)
            : base(pos, tex)
        {
            Source = new Rectangle(0, 0, 50, 15);
        }

        public Platform(Vector2 pos)
            : base(pos)
        {
        }

        protected override bool HandleCollision()
        {
            var found = false;
            foreach (var gameObject in Collides)
                if (!(gameObject is BasePlatform))
                {
                    var movingObject = gameObject as MovingObject;
                    if (movingObject?.HitBox.Bottom - HitBox.Top < 10 && movingObject.HitBox.Bottom - HitBox.Top > -10)
                    {
                        movingObject.LandOnPlatform(1, this);
                        found = true;
                    }
                }

            return found;
        }
    }
}