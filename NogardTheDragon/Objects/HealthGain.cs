using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects
{
    internal class HealthGain : MovingObject
    {
        public HealthGain(Vector2 pos, Texture2D tex)
            : base(pos, tex)
        {
        }

        protected override bool HandleCollision()
        {
            var found = false;
            foreach (var gameObject in Collides)
                if (!(gameObject is HealthGain))
                {
                    var movingObject = gameObject as Player;

                    if (movingObject != null)
                    {
                        found = true;
                        Active = false;
                        if (movingObject.Health < 5)
                            movingObject.Health += 1;
                    }
                }

            return found;
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            return false;
        }
    }
}