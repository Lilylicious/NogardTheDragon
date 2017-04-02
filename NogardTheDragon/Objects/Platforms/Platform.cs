using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects
{
    internal class Platform : GameObject
    {
        public Platform(Vector2 pos, Texture2D tex)
        {
            DrawPos = pos;
            Texture = tex;

            SetColorData();
        }


        public static int PlatformWidth { get; } = 47;

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