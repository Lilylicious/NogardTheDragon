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
                var o = gObject as MovingObject;
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