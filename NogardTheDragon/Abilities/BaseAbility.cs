using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NogardTheDragon.Objects;

namespace NogardTheDragon.Abilities
{
    internal abstract class BaseAbility
    {
        protected BaseAbility(MovingObject owner)
        {
            Owner = owner;
        }

        protected MovingObject Owner;
        
        public abstract void TriggerAbility();
    }
}
