using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Enemies
{
    internal class StandardEnemy : BaseEnemy
    {
        public StandardEnemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            Source = new Rectangle(48, 48, 48, 48);
        }
            public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

                if (Velocity.X <= Velocity.X - 5)
            {
                Walk = false;
                Effects = SpriteEffects.FlipHorizontally;
            }
            else if (Velocity.X >= Velocity.X + 5)
            {
                Walk = true;
            }

            if (Walk == false)
            {
                Velocity.X += 1f;
            }
            else if (Walk == true)
            {
                Velocity.X -= 1;
            }

            frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;

            if (frameTimer <= 0)
            {
                frameTimer = frameInterval;
                frame++;
                Source = new Rectangle((CurrentFrame % 4) * 32, Source.Y, Source.Width, Source.Height);
            }
        }
    }
}