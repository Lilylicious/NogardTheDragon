using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Platforms
{
    internal class FadingPlatform : BasePlatform
    {
        private readonly float RESET = 0;
        private bool StartTimer;
        private readonly byte StepSize = 3;
        private float Timer;

        public FadingPlatform(Vector2 pos, Texture2D tex)
            : base(pos, tex)
        {
            Source = new Rectangle(150, 145, 50, 16);
        }

        public override void Update(GameTime gameTime)
        {
            if (HandleCollision())
            {
                Color.A -= StepSize;

                if (Color.A <= 20)
                {
                    CollideEnabled = false;
                    StartTimer = true;
                }
            }
            else if (!HandleCollision() && !(Color.A >= 250) && !StartTimer)
            {
                Color.A += StepSize;
            }

            if (StartTimer)
            {
                Timer += (float) gameTime.ElapsedGameTime.TotalSeconds;

                if (Timer >= 5)
                {
                    Color.A = 250;
                    Timer = RESET;
                    CollideEnabled = true;
                    StartTimer = false;
                }
            }
            base.Update(gameTime);
        }

        protected override bool HandleCollision()
        {
            var found = false;
            foreach (var gameObject in Collides)
                if (!(gameObject is BasePlatform))
                {
                    var movingObject = gameObject as MovingObject;
                    movingObject?.LandOnPlatform(1, this);

                    found = true;
                }

            return found;
        }
    }
}