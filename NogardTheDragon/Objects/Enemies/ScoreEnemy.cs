using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects
{
    class ScoreEnemy : BaseEnemy
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
