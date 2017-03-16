using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NogardTheDragon.Objects;

namespace NogardTheDragon.Map
{
    public class Map
    {
        public List<GameObject> Objects = new List<GameObject>();

        public Map(List<GameObject> objects)
        {
            Objects = objects;
        }

        public void Update(GameTime gameTime)
        {
            foreach (var gObject in Objects)
            {
                // o == null if gObject can't be cast to MovingObject
                var o = gObject as MovingObject;

                // o? short circuits if o is null, as in it only continues the line if o != null. This is equivalent to:
                // if(o != null) { o.Update(gameTime); }
                o?.Update(gameTime);
            }
        }

        public void Draw()
        {
            foreach (var obj in Objects)
                if (obj.Active)
                    obj.Draw(NogardGame.SpriteBatch);
        }
    }
}