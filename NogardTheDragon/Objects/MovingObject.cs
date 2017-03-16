using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects
{
    public class MovingObject : GameObject
    {
        protected int Acceleration = 2;
        protected int AccelerationConstant = 2;

        protected GameObject CollidingWith;

        protected int CurrentFrame;
        protected Vector2 Direction = new Vector2(0, 0);
        protected bool Gravity = false;
        protected bool Moving = false;
        protected int NumberOfFrames;
        protected float Speed;
        protected int Step = 1;
        protected double TimeBetweenFrames = 0.1;
        protected double TimeSinceLastFrame;
        protected Vector2 Velocity;

        public override void CheckCollision()
        {
            var found = false;
            foreach (var gameObject in NogardGame.GamePlayManager.ActiveMap.Objects)
                if (PixelCollision(this, gameObject))
                {
                    if (this == gameObject) continue;

                    found = true;
                    CollidingWith = gameObject;
                }

            if (!found)
                CollidingWith = null;
        }

        public static bool PixelCollision(GameObject p1, GameObject p2)
        {
            if (!p1.HitBox.Intersects(p2.HitBox))
                return false;
            float collLeft = MathHelper.Max(p1.Dest.X, p2.Dest.X);
            float collTop = MathHelper.Max(p1.Dest.Y, p2.Dest.Y);
            float collRight = MathHelper.Min(p1.Dest.Right, p2.Dest.Right);
            float collBottom = MathHelper.Min(p1.Dest.Bottom, p2.Dest.Bottom);
            for (var col = (int) collLeft; col < collRight; col++)
            for (var row = (int) collTop; row < collBottom; row++)
                if (p1.GetPixel(col, row).A > 127
                    && p2.GetPixel(col, row).A > 127)
                    return true;
            return false;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Texture,
                DrawPos,
                SourceRect,
                Color,
                Rotation,
                Origin,
                Scale,
                Effects,
                LayerDepth);
        }

        protected virtual void HandleCollision()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
            CheckCollision();

            DrawPos += Velocity;
        }

        public Vector2 GetVelocity()
        {
            return Velocity;
        }

        
    }
}