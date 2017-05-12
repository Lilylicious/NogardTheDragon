using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Enemies
{
    internal class FlyingHunterEnemy : BaseEnemy
    {
        private int MaxDist;
        private int MinDist;
        private bool getPosition;

        public FlyingHunterEnemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            MaxDist = 10;
            MinDist = 5;
        }

        public override void Update(GameTime gameTime)
        {
            var Direction = player.getPosition - this.getPosition;
            Direction.Normalize();
            ChangeVelocity(Direction);
        }
    }
}
