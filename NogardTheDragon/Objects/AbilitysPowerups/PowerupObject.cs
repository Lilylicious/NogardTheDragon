using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.AbilitysPowerups
{
    internal abstract class PowerupObject : MovingObject
    {
        protected PowerupObject(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
        }

        public abstract void AddPowerup(GameTime gameTime, Player player);
    }
}