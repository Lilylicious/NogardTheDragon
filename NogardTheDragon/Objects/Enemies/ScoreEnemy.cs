using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Enemies
{
    internal class ScoreEnemy : BaseEnemy
    {
        public ScoreEnemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
        }

        public override void Update(GameTime gameTime)
        {

        }

        public void TakeDamage(int damage)
        {
            Score++;
        }
    }
}