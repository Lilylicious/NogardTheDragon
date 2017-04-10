using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects
{
    internal class Platform : BasePlatform
    {
        public Platform(Vector2 pos, Texture2D tex)
            :base(pos, tex)
        {

        }

        protected override bool HandleCollision()
        {
            if(CollidingWith is Player)
            {
                ((Player)CollidingWith).LandOnPlatform(1, true, false, false);
                return true;
            }
            return false;
        }
    }
}