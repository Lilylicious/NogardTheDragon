using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.Managers
{
    public abstract class BaseManager
    {

        public abstract void Init();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw();
    }
}
