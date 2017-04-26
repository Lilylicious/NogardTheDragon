using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Managers
{
    public class Camera
    {
        private Vector2 Pos;
        private Matrix Transform;
        private Viewport View;

        public Camera(Viewport view)
        {
            this.View = view;
        }

        public void SetPos(Vector2 pos)
        {
            this.Pos = pos;
            Transform = Matrix.CreateTranslation(-this.Pos.X + View.Width / 2, -this.Pos.Y + View.Height / 2, 0);
        }

        public Matrix GetTransform()
        {
            return Transform;
        }
    }
}