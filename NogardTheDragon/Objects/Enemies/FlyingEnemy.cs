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
        public FlyingEnemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
        }
    }
}
