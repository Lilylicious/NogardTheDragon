using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects
{
    class FlyingEnemy : BaseEnemy
    {
        private bool Airborn = false;
        private bool Fly;

        public FlyingEnemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (DrawPos.X >= DrawPos.X + 5)
            {
                Fly = true;
                //Speed = +Speed;
            }
        }
    }
}
