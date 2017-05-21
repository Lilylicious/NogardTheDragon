using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.Objects
{
    class HealthGain : MovingObject
    {
        public HealthGain(Vector2 pos, Texture2D tex)
            :base(pos, tex)
        {

        }

        protected override bool HandleCollision()
        {
            var found = false;
            foreach (GameObject gameObject in Collides)
            {
                if (!(gameObject is HealthGain))
                {
                    var movingObject = gameObject as Player;

                    if (movingObject != null)
                    {
                        found = true;
                        this.Active = false;
                        if (movingObject.Health < 5)
                            movingObject.Health += 1;
                    }
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
