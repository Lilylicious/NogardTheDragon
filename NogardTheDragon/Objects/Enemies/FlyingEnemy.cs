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
            Source = new Rectangle(0, 144, 192, 48);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Velocity.Y <= 0 || Velocity.Y >= Texture.Height)
            {
                Fly = true;
                //Speed = +Speed;
            }

            if(Velocity.X < 0 - Texture.Width)
            {
                isVisible = false;
            }

            if (frameTimer <= 0)
            {
                frameTimer = frameInterval;
                frame++;
                Source = new Rectangle((CurrentFrame % 4) * 32, Source.Y, Source.Width, Source.Height);
            }
        }

        public void LoadFlyingEnemy()
        {
            for (int i = 0; i < Source.count; i++)
            {
                if (!Source[i].isVisible)
                {
                    Source.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}