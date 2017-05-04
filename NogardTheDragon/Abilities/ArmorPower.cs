using Microsoft.Xna.Framework;

namespace NogardTheDragon.Abilities
{
    internal class ArmorPower : BasePowerup
    {
        public ArmorPower(GameTime gameTime) : base(gameTime)
        {
            Timer = 30;
        }
    }
}