using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NogardTheDragon.Objects
{
    public class Player : MovingObject
    {
        private bool Airborn;
        public int Health;
        public int Score;
        public double Timer;

        public Player(Vector2 pos, Texture2D tex)
        {
            Speed = 9;
            Health = 3;

            DrawPos = pos;
            Texture = tex;

            SetColorData();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HandleCollision();

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                Direction.X = 1f;

            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                Direction.X = -1f;

            else
            {
                Direction.X = 0f;
                Velocity.X = 0f;
            }

            if (!Airborn && Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Velocity.Y = -12f;
                Airborn = true;
            }

            if (Health <= 0)
                NogardGame.GameState = NogardGame.GameStateEnum.GameOver;

            Velocity.Y += GravitySpeed;

            Velocity += Direction * (Speed / Math.Max(1, Math.Abs(Velocity.X))) * (float) gameTime.ElapsedGameTime.TotalSeconds;
            Velocity = new Vector2(MathHelper.Clamp(Velocity.X, -3, 3), Velocity.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            SourceRect = Source;
            base.Draw(spriteBatch);
        }

        protected override void HandleCollision()
        {
            if (CollidingWith == null || !(Velocity.Y > 0)) return;

            DrawPos.Y = CollidingWith.GetPosition().Y - Texture.Height + 1;
            Airborn = false;
            Direction.Y = 0;
            Velocity.Y = 0;
        }
    }
}