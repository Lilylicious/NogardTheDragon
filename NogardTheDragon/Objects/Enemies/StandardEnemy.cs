using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Enemies
{
    internal class StandardEnemy : BaseEnemy
    {
        public StandardEnemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            Source = new Rectangle(48, 96, 48, 240);
        }
            public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

                if (Velocity.X <= Velocity.X - 5)
            {
                Walk = false;
                rotation = MathHelper.ToRadians(-180);
            }
            else if (Velocity.X >= Velocity.X + 5)
            {
                Walk = true;
                rotation = MathHelper.ToRadians(180);
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
                Source = (CurrentFrame % 4) * 32;
            }
        }
    }
}