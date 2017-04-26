using Microsoft.Xna.Framework;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Abilities
{
    internal class SlowWorldPower : BasePowerup
    {
        public SlowWorldPower(GameTime gameTime) : base(gameTime)
        {
            Variables.WorldSpeed = 2;
            Timer = 5;
        }

        public override void Remove()
        {
            Variables.WorldSpeed = Variables.DefaultWorldSpeed;
            base.Remove();
        }
    }
}