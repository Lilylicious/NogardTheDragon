using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NogardTheDragon.Managers;
using NogardTheDragon.Objects;

namespace NogardTheDragon.Map
{
    public class Map
    {
        public Camera Cam;
        public List<GameObject> Objects = new List<GameObject>();
        private Player Player;

        public List<Projectile> ProjectilesToAdd = new List<Projectile>();

        public Map(List<GameObject> objects)
        {
            Objects = objects;
            Cam = new Camera(NogardGame.SpriteBatch.GraphicsDevice.Viewport);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var p in ProjectilesToAdd)
                Objects.Add(p);

            ProjectilesToAdd.Clear();

            foreach (var gObject in Objects)
            {
                if (gObject is Player)
                    Player = (Player) gObject;

                // o == null if gObject can't be cast to MovingObject
                var o = gObject as MovingObject;

                // o? short circuits if o is null, as in it only continues the line if o != null. This is equivalent to:
                // if(o != null) { o.Update(gameTime); }
                o?.Update(gameTime);
            }

            Cam.SetPos(Player.GetPosition());
            Objects.RemoveAll(item => item.Active == false);
        }

        public void Draw()
        {
            foreach (var obj in Objects)
                obj.Draw(NogardGame.SpriteBatch);
        }
    }
}