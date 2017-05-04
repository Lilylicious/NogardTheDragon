﻿using Microsoft.Xna.Framework;
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

            var found = false;
            foreach (GameObject gameObject in Collides)
            {
                if (!(gameObject is BasePlatform))
                {
                    var movingObject = gameObject as MovingObject;

                    if (MoveUp)
                        movingObject?.LandOnPlatform(1, this);
                    else if (!MoveUp)
                        movingObject?.LandOnPlatform(2, this);
                }
            }

            return found;
        }
    }
}