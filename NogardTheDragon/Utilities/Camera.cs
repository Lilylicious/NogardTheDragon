using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Utilities
{
    public class Camera
    {
        private Vector2 Pos;
        private Matrix Transform;
        private Viewport View;

        public Camera(Viewport view)
        {
            View = view;
        }

        public void SetPos(Vector2 pos)
        {
            Pos = pos;
            Transform = Matrix.CreateTranslation(-Pos.X + View.Width / 2, -Pos.Y + View.Height / 2, 0);
        }

        public Matrix GetTransform()
        {
            return Transform;
        }
    }
}