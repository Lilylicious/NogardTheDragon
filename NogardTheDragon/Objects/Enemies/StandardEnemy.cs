using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects
{
    class StandardEnemy : BaseEnemy
    {
        public StandardEnemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
        }
            public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Velocity.X <= Velocity.X - 5)
            {
                Walk = false;
            }
            else if (Velocity.X >= Velocity.X + 5)
            {
                Walk = true;
            }

            if (Walk == false)
            {
                Velocity.X += 1f;
            }
            else if (Walk == true)
            {
                Velocity.X -= 1;
            }
        }
    }
}
