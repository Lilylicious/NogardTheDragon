using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Platforms
{
    public abstract class BasePlatform : MovingObject
    {
        public Player CollidingPlayer;

        public BasePlatform(Vector2 pos) : base(pos)
        {
        }

        public BasePlatform(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            UsingSpritesheet = true;
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            return false;
        }
    }
}