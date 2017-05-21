using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Interfaces;

namespace NogardTheDragon.Objects.Platforms
{
    public class SpikePlatform : BasePlatform
    {
        public SpikePlatform(Vector2 pos, Texture2D tex)
            : base(pos, tex)
        {
            Source = new Rectangle(0, 192, 50, 48);
        }
        public SpikePlatform(Vector2 pos)
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
                    

                    var damageable = movingObject as IDamageable;
                        damageable?.TakeDamage(1);

                    found = true;
                }
            }

            return found;
        }
    }
}