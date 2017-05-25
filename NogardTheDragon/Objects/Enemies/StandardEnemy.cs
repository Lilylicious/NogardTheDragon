using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Objects.Enemies
{
    internal class StandardEnemy : BaseEnemy
    {
        private bool MoveRight;
        private Vector2 StartPos;

        public StandardEnemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            StartPos = pos;
            Source = new Rectangle(0, 150, 31, 32);
            Health = 5;
            AffectedByGravity = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Health <= 0 && Active)
            {
                NogardGame.KillBonus += 2;
                Active = false;
            }

            if (DrawPos.X <= StartPos.X - 100)
                MoveRight = true;
            else if (DrawPos.X >= StartPos.X + 100)
                MoveRight = false;

            if (Variables.UpdateTick)
                if (!MoveRight)
                {
                    Effects = SpriteEffects.FlipHorizontally;
                    DrawPos.X -= 1f;
                }
                else if (MoveRight)
                {
                    Effects = SpriteEffects.None;
                    DrawPos.X += 1;
                }

            frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
            if (frameTimer <= 0)
            {
                frameTimer = frameInterval;
                CurrentFrame++;
                Source = new Rectangle(CurrentFrame % 4 * 31, Source.Y, Source.Width, Source.Height);
            }
        }
    }
}