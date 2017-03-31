using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NogardTheDragon.Objects;
using NogardTheDragon.Managers;

namespace NogardTheDragon.Map
{
    public class Map
    {
        public List<GameObject> Objects = new List<GameObject>();
        Player player;
        public Camera cam;

        public List<Projectile> ProjectilesToAdd = new List<Projectile>();

        public Map(List<GameObject> objects)
        {
            Objects = objects;
            cam = new Camera(NogardGame.SpriteBatch.GraphicsDevice.Viewport);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var p in ProjectilesToAdd)
                Objects.Add(p);

            ProjectilesToAdd.Clear();

            foreach (var gObject in Objects)
            {
                if (gObject is Player)
                    player = (Player)gObject;

                // o == null if gObject can't be cast to MovingObject
                var o = gObject as MovingObject;

                // o? short circuits if o is null, as in it only continues the line if o != null. This is equivalent to:
                // if(o != null) { o.Update(gameTime); }
                o?.Update(gameTime);

            }
            cam.SetPos(player.GetPosition());
            Objects.RemoveAll(item => item.Active == false);

        }

        public void Draw()
        {
            foreach (var obj in Objects)
                if (obj.Active)
                    obj.Draw(NogardGame.SpriteBatch);
        }
    }
}