using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Enemies
{
    internal class FlyingHunterEnemy : BaseEnemy
    {
        private bool getPosition;
        private int MaxDist;
        private int MinDist;

        public FlyingHunterEnemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            MaxDist = 10;
            MinDist = 5;
        }

        //    Direction.Normalize();
        //    var Direction = player.getPosition - this.getPosition;
        //{

        //public override void Update(GameTime gameTime)
        //    ChangeVelocity(Direction);
        //}
    }
}