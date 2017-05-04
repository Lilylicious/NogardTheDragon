using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Enemies
{
    internal class FlyingEnemy : BaseEnemy
    {
        private bool Airborn = false;
        private bool Fly;

        private bool isVisible = true;

        public FlyingEnemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (DrawPos.Y <= 0 || DrawPos.Y >= gameTime.Viewport.Height - Texture.Height)
            {
                Fly = true;
                //Speed = +Speed;
            }

            if(DrawPos.X < 0 - Texture.Width)
            {
                isVisible = false;
            }
        }

        public void LoadFlyingEnemies()
        {
            for(int i = 0; i <flyingEnemy.count; i++)
            {
                if (!flyingEnemy[i].isVisible)
                {
                    flyingEnemy.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}