using NogardTheDragon.Objects;

namespace NogardTheDragon.Abilities
{
    public abstract class BaseAbility
    {
        protected MovingObject Owner;

        protected BaseAbility(MovingObject owner)
        {
            Owner = owner;
        }

        public abstract void TriggerAbility();
        public abstract void Update();
    }
}