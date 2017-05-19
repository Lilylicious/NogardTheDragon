using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects
{
    internal class Goal : MovingObject
    {
        public Goal(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            Source = new Rectangle(50, 288, 50, 48);
            UsingSpritesheet = true;
        }

        protected override bool HandleCollision()
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

        protected override bool HandleCollision(GameTime gameTime)
        {
            return true;
        }
    }
}