using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Objects.Platforms
{
    class MovingPlatform : BasePlatform
    {
        private Vector2 startPos;
        private bool moveUp;

        public MovingPlatform(Vector2 pos, Texture2D tex)
            :base(pos, tex)
        {
            startPos = pos;
            SetColorData();
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

            if(Variables.UpdateTick) {
                if (!moveUp)
                {
                    DrawPos.Y += 1f;
                }
                else if (moveUp)
                {
                    DrawPos.Y -= 1;
                }
            }
            
            base.Update(gameTime);
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            var o = CollidingWith as MovingObject;
            if (o == null) return false;

            if (moveUp)
                o.LandOnPlatform(1);
            else if (!moveUp)
                o.LandOnPlatform(2);

            return true;
        }
    }
}
