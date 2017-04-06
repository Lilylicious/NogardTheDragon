using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.Objects.Platforms
{
    class MovingPlatform : BaseSpecialPlatform
    {
        private Vector2 startPos;
        private bool moveUp;

        public MovingPlatform(Vector2 pos, Texture2D tex)
            :base(pos, tex)
        {
            startPos = pos;
        }

        public override void Update(GameTime gameTime)
        {
            if (DrawPos.Y <= startPos.Y - 200)
            {
                moveUp = false;
            }
            else if (DrawPos.Y >= startPos.Y + 200)
            {
                moveUp = true;
            }

            if (moveUp == false)
            {
                DrawPos.Y += 1f;
            }
            else if (moveUp == true)
            {
                DrawPos.Y -= 1;
            }
        }
    }
}
