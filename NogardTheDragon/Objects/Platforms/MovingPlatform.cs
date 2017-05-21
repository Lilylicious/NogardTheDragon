using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Objects.Platforms
{
    public abstract class MovingPlatform : BasePlatform
    {
        public bool MoveRight;
        protected bool MoveUp;
        protected Vector2 StartPos;
        protected bool Vertical;

        public MovingPlatform(Vector2 pos, Texture2D tex)
            : base(pos, tex)
        {
            StartPos = pos;
            Source = new Rectangle(50, 144, 50, 48);
        }

        public MovingPlatform(Vector2 pos)
            : base(pos)
        {
        }

        public override void Update(GameTime gameTime)
        {

            switch (Vertical)
            {
                case true:
                    if (DrawPos.Y <= StartPos.Y - 200)
                        MoveUp = false;
                    else if (DrawPos.Y >= StartPos.Y + 200)
                        MoveUp = true;

                    if (Variables.UpdateTick)
                        if (!MoveUp)
                            DrawPos.Y += 1f;
                        else if (MoveUp)
                            DrawPos.Y -= 1;
                    break;

                case false:
                    if (DrawPos.X <= StartPos.X - 200)
                        MoveRight = true;
                    else if (DrawPos.X >= StartPos.X + 200)
                        MoveRight = false;

                    if (Variables.UpdateTick)
                        if (!MoveRight)
                            DrawPos.X -= 1f;
                        else if (MoveRight)
                            DrawPos.X += 1;
                    break;
            }

            base.Update(gameTime);
        }

        protected override bool HandleCollision()
        {
            throw new NotImplementedException();
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            return false;
        }
    }
}