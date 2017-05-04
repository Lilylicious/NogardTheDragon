using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NogardTheDragon.Objects;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Abilities
{
    internal class DoubleJumpAbility : BaseAbility
    {
        private bool CanTrigger = true;

        public DoubleJumpAbility(MovingObject owner) : base(owner)
        {
        }

        public override void TriggerAbility()
        {
            Owner.ChangeVelocity(new Vector2(0, -(Owner.GetVelocity().Y + 12)));
            CanTrigger = false;
        }

        public void Reset()
        {
            CanTrigger = true;
        }

        public override void Update()
        {
            if (Owner.Airborn && KeyMouseReader.KeyPressed(Keys.Up) && (CanTrigger || Variables.UnlimitedPower))
                TriggerAbility();
        }
    }
}