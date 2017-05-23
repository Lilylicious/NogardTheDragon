using System.Drawing.Text;
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
            Transform = Matrix.CreateTranslation(-Pos.X, -Pos.Y, 0) * Matrix.CreateScale(Zoom, Zoom, 0) * Matrix.CreateTranslation(View.Width / 2, View.Height / 2, 0);
        }

        public Matrix GetTransform()
        {
            return Transform;
        }
    }
}