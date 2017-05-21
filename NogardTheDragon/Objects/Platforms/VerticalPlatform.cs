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
    class VerticalPlatform : MovingPlatform
    {
        public VerticalPlatform(Vector2 pos, Texture2D tex)
            : base(pos, tex)
        {
            Vertical = true;
            UsingSpritesheet = true;
            Source = new Rectangle(50, 145, 50, 16);
        }

        protected override bool HandleCollision()
        {
            var found = false;
            foreach (GameObject gameObject in Collides)
            {
                if (!(gameObject is BasePlatform))
                {
                    var movingObject = gameObject as MovingObject;

                    if (MoveUp)
                        movingObject?.LandOnPlatform(1, this);
                    else if (!MoveUp)
                        movingObject?.LandOnPlatform(2, this);

                    found = true;
                }
            }

            return found;
        }

    }
}
