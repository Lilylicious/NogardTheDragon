using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.AbilitysPowerups
{
    internal abstract class PowerupObject : MovingObject
    {
        protected PowerupObject(Vector2 pos, Texture2D tex)
        {
            DrawPos = pos;
            Texture = tex;

            SetColorData();
        }

        public abstract void AddPowerup(GameTime gameTime, Player player);
    }
}