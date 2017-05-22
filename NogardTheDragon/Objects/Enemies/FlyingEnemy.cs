using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Enemies
{
    internal class FlyingEnemy : BaseEnemy
    {
        //private bool Fly;
        //private bool isVisible = true;

        public FlyingEnemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            Source = new Rectangle(0, 144, 48, 48);
            AffectedByGravity = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //if (Velocity.Y <= 0 || Velocity.Y >= Texture.Height)
            //{
            //    Fly = true;
            //    //Speed = +Speed;
            //}

            //if(Velocity.X < 0 - Texture.Width)
            //{
            //    isVisible = false;
            //}

            if (Velocity.X <= Velocity.X - 5)
            {
                Walk = false;
                Effects = SpriteEffects.FlipHorizontally;
            }
            else if (Velocity.X >= Velocity.X + 5)
            {
                Walk = true;
                Effects = SpriteEffects.None;
            }

            if (Walk == false)
                Velocity.X += 1f;
            else if (Walk)
                Velocity.X -= 1;

            if (frameTimer <= 0)
            {
                frameTimer = frameInterval;
                CurrentFrame++;
                Source = new Rectangle(CurrentFrame % 4 * 32, Source.Y, Source.Width, Source.Height);
            }
        }

        //{

        //public void LoadFlyingEnemy()
        //    for (int i = 0; i < Source; i++)
        //    {
        //        if (!Source[i].isVisible)
        //        {
        //            Source.RemoveAt(i);
        //            i--;
        //        }
        //    }
        //}
    }
}