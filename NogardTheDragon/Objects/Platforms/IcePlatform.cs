using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Platforms
{
    public class IcePlatform : BasePlatform
    {
        public IcePlatform(Vector2 pos, Texture2D tex)
            : base(pos, tex)
        {
            Source = new Rectangle(0, 240, 100, 15);
        }

        public IcePlatform(Vector2 pos)
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

                    if (movingObject != null && !movingObject.Gliding)
                    {
                        movingObject.LandOnIcePlatform(this);
                        found = true;
                    }
                }

            return found;
        }
    }
}