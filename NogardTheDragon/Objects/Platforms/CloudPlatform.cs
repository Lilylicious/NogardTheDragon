﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Platforms
{
    public class CloudPlatform : BasePlatform
    {
        public CloudPlatform(Vector2 pos, Texture2D tex)
            : base(pos, tex)
        {
            Source = new Rectangle(0, 96, 50, 16);
        }

        public CloudPlatform(Vector2 pos)
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

                    if (movingObject != null && !movingObject.Sinking)
                    {
                        movingObject?.LandOnCloudPlatform();
                        found = true;
                    }
                }

            return found;
        }
    }
}