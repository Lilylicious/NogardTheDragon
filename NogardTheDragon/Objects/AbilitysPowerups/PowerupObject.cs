using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects
{
    internal abstract class PowerupObject : MovingObject
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