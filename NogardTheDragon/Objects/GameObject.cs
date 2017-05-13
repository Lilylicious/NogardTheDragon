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
        protected Texture2D Texture;
        public bool CollideEnabled = true;

        // 

        /* The lambda operator => can be interpreted as a block containing a single return statement.
         * It is no different functionality wise, it just looks a bit cleaner to me.
         * For example, the Source property below is the equivalent of
         * 
        protected Rectangle SourceRect;
        public bool UsingSpritesheet = false;
        
         public virtual Rectangle Source 
         {
            get { return SourceRect; }
            set { SourceRect = value; }
         }

        public virtual Rectangle Dest => new Rectangle((int) DrawPos.X, (int) DrawPos.Y, Source.Width, Source.Height);

        public virtual Rectangle HitBox => Dest;

        public Vector2 GetPosition()
        {
            return DrawPos;
        }

        public Vector2 GetCenter()
        {
            return new Vector2(DrawPos.X + Source.Width / 2, DrawPos.Y + Source.Height / 2);
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