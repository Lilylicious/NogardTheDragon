using Microsoft.Xna.Framework;

namespace NogardTheDragon.Abilities
{
    internal abstract class BasePowerup
    {
        protected GameTime GameTime;
        protected double Timer;

        public BasePowerup(GameTime gameTime)
        {
            GameTime = gameTime;
        }

        public bool Active = true;

        public virtual void Update()
        {
            if (Timer > 0)
                Timer -= GameTime.ElapsedGameTime.TotalSeconds;

            else
                Remove();
        }

        public virtual void Remove()
        {
            Active = false;
        }
    }
}