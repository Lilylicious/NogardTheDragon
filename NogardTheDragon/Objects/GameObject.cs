using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects
{
    public abstract class GameObject
    {
        public bool Active = true;
        protected Color Color = Color.White;

        private Color[] ColorData;
        protected Vector2 DrawPos;
        protected SpriteEffects Effects = SpriteEffects.None;
        protected float GravitySpeed = 0.5f;
        protected float LayerDepth = 0;
        protected Vector2 Origin;
        protected float Rotation = 0;
        protected float Scale = 1.0f;
        protected Rectangle SourceRect = new Rectangle();
        protected Texture2D Texture;

        // 

        /* The lambda operator => can be interpreted as a block containing a single return statement.
         * It is no different functionality wise, it just looks a bit cleaner to me.
         * For example, the Source property below is the equivalent of
         * 
         public virtual Rectangle Source 
         {
            get { return new Rectangle(0, 0, Texture.Width, Texture.Height); }
         }

        */
        public virtual Rectangle Source => new Rectangle(0, 0, Texture.Width, Texture.Height);

        public virtual Rectangle Dest => new Rectangle((int) DrawPos.X, (int) DrawPos.Y, Texture.Width, Texture.Height);

        public virtual Rectangle HitBox => Dest;

        public Vector2 GetPosition()
        {
            return DrawPos;
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void CheckCollision();

        public void SetColorData()
        {
            ColorData = new Color[Texture.Width * Texture.Height];
            Texture.GetData(ColorData);
        }

        public Color GetPixel(int col, int row)
        {
            var c = col - Dest.X + Source.X;
            var r = row - Dest.Y + Source.Y;
            return ColorData[r * Texture.Width + c];
        }
    }
}