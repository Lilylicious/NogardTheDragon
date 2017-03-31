using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.Managers
{
    public class Camera
    {
        private Viewport view;
        private Vector2 pos;
        private Matrix transform;

        public Camera(Viewport view)
        {
            this.view = view;
        }

        public void SetPos(Vector2 pos)
        {
            this.pos = pos;
            transform = Matrix.CreateTranslation(-this.pos.X + view.Width / 2, -this.pos.Y + view.Height / 2, 0);
        }

        public Matrix GetTransform()
        {
            return transform;
        }
    }
}
