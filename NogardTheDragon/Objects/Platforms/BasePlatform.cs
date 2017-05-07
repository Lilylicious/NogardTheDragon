using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Platforms
{
    public abstract class BasePlatform : MovingObject
    {
        public BasePlatform(Vector2 pos)
        {
            DrawPos = pos;
        }
        public BasePlatform(Vector2 pos, Texture2D tex)
        {
            DrawPos = pos;
            Texture = tex;

            SetColorData();
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            SourceRect = Source;
            base.Draw(spriteBatch);
        }
    }
}