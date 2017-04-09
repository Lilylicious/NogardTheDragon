using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects
{
    public class Platform : GameObject
    {
        public Platform(Vector2 pos, Texture2D tex)
        {
            DrawPos = pos;
            Texture = tex;

            SetColorData();
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, DrawPos, Color.White);
        }

        public override void CheckCollision()
        {
            throw new NotImplementedException();
        }
    }
}