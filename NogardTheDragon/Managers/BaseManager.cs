using Microsoft.Xna.Framework;

namespace NogardTheDragon.Managers
{
    public abstract class BaseManager
    {
        public virtual void Init()
        {
            NogardGame.ButtonManager.Init();
        }
        public virtual void Update(GameTime gameTime)
        {
            NogardGame.ButtonManager.Update(gameTime);
        }
        public virtual void Draw()
        {
            NogardGame.ButtonManager.Draw();
        }
    }
}