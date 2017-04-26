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

        protected override bool HandleCollision(GameTime gameTime)
        {
            var o = CollidingWith as MovingObject;
            if (o == null) return false;

            o.LandOnPlatform(1);
            return true;
        }
    }
}