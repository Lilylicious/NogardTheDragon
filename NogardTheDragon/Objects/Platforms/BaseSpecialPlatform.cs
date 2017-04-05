﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.Objects
{
    abstract class BaseSpecialPlatform : MovingObject
    {
        public BaseSpecialPlatform(Vector2 pos, Texture2D tex)
        {
            DrawPos = pos;
            Texture = tex;
            SetColorData();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            SourceRect = Source;
            base.Draw(spriteBatch);
        }
    }
}
