using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Objects.Platforms
{
    internal class MovingPlatform : BasePlatform
    {
        private bool MoveUp;
        private Vector2 StartPos;

        public MovingPlatform(Vector2 pos, Texture2D tex)
            : base(pos, tex)
        {
            StartPos = pos;
            SetColorData();
        }

        public override void Update(GameTime gameTime)
        {
            if (DrawPos.Y <= StartPos.Y - 200)
                MoveUp = false;
            else if (DrawPos.Y >= StartPos.Y + 200)
                MoveUp = true;

            if (Variables.UpdateTick)
                if (!MoveUp)
                    DrawPos.Y += 1f;
                else if (MoveUp)
                    DrawPos.Y -= 1;

            base.Update(gameTime);
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            var o = CollidingWith as MovingObject;
            if (o == null) return false;

            if (MoveUp)
                o.LandOnPlatform(1);
            else if (!MoveUp)
                o.LandOnPlatform(2);

            return true;
        }
    }
}