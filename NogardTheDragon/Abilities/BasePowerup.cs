using Microsoft.Xna.Framework;

namespace NogardTheDragon.Abilities
{
    public abstract class BasePowerup
    {
        public bool Active = true;
        protected GameTime GameTime;
        protected double Timer;

        protected BasePowerup(GameTime gameTime)
        {
            GameTime = gameTime;
        }

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