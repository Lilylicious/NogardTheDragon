using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects
{
    internal class Goal : MovingObject
    {
        public Goal(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            UsingSpritesheet = true;
            Source = new Rectangle(0, 288, 50, 48);
        }

        protected override bool HandleCollision()
        {
            var found = false;
            foreach (GameObject gameObject in Collides)
            {
                if (gameObject is Player)
                {
                    StoryMode.IntroStory = false;
                    NogardGame.MapsComplete++;
                    NogardGame.StoryMode.Init();
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