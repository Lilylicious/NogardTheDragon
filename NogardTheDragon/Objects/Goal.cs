using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NogardTheDragon.Objects
{
    class Goal : MovingObject
    {
        public Goal(Vector2 pos, Texture2D tex)
        {
            DrawPos = pos;
            Texture = tex;

            SetColorData();
        }

        public override void CheckCollision()
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, DrawPos, Color.White);
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            if (CollidingWith is Player)
            {
                NogardGame.GameOverManager.Win();
                return true;
            }
            return false;
        }
    }
}