using NogardTheDragon.Objects;

namespace NogardTheDragon.Abilities
{
    internal abstract class BaseAbility
    {
        protected MovingObject Owner;

        protected BaseAbility(MovingObject owner)
        {
            Owner = owner;
        }

        public abstract void TriggerAbility();
    }
}