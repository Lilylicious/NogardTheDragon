using Microsoft.Xna.Framework;

namespace NogardTheDragon.Managers
{
    public abstract class BaseManager
    {
        public ButtonManager ButtonManager;

        public abstract void Init();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw();
    }
}