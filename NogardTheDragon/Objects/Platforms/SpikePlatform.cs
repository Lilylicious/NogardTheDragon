using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Interfaces;

namespace NogardTheDragon.Objects.Platforms
{
    internal class SpikePlatform : BasePlatform
    {
        public SpikePlatform(Vector2 pos, Texture2D tex)
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

                    var damageable = movingObject as IDamageable;
                        damageable?.TakeDamage(1);
                }
            }

            return found;




        }
    }
}