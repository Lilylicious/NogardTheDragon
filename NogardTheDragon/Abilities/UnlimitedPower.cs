using Microsoft.Xna.Framework;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Abilities
{
    internal class UnlimitedPower : BasePowerup
    {
        public UnlimitedPower(GameTime gameTime) : base(gameTime)
        {
            Variables.UnlimitedPower = true;
            Timer = 5;
        }

        public override void Remove()
        {
            Variables.UnlimitedPower = false;
            base.Remove();
        }
    }
}