using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.Objects.Platforms
{
    public class HorizontalPlatform : MovingPlatform
    {
        public HorizontalPlatform(Vector2 pos, Texture2D tex)
            :base (pos, tex)
        {
            Vertical = false;
            Source = new Rectangle(0, 145, 50, 16);
        }

        protected override bool HandleCollision()
        {
            var found = false;
            foreach (GameObject gameObject in Collides)
            {
                if (!(gameObject is BasePlatform))
                {
                    var movingObject = gameObject as MovingObject;

                    if (movingObject != null && !movingObject.Moving)
                    {
                        movingObject?.LandOnHorizontalPlatform(this);
                        found = true;
                    }
                }
            }

            return found;
        }
    }
}
