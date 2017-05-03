﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects
{
    internal class Goal : MovingObject
    {
        public Goal(Vector2 pos, Texture2D tex)
        {
            DrawPos = pos;
            Texture = tex;

            SetColorData();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, DrawPos, Color.White);
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            var found = false;
            foreach (GameObject gameObject in Collides)
            {
                if (gameObject is Player)
                {
                    NogardGame.GameOverManager.Win();
                    found = true;
                }
            }

            return found;
        }
    }
}