using Microsoft.Xna.Framework;
using NogardTheDragon.Objects;

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
            if (!CanTrigger) return;
            Owner.ChangeVelocity(new Vector2(0, -6));
            CanTrigger = false;
        }

        public void Reset()
        {
            CanTrigger = true;
        }
    }
}