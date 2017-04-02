using NogardTheDragon.Interfaces;

namespace NogardTheDragon.Objects
{
    internal class BaseEnemy : MovingObject, IDamageable
    {
        private int Health = 3;

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}