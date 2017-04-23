using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Abilities;

namespace NogardTheDragon.Objects
{
    abstract class PowerupObject : MovingObject
    {
        public PowerupObject(Vector2 pos, Texture2D tex)
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

        public abstract void AddPowerup(GameTime gameTime);
    }
}
