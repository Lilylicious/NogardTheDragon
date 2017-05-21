using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace NogardTheDragon.Objects.Platforms
{
    class FadingPlatform : BasePlatform
    {
        private bool StartTimer;
        private float RESET = 0;
        private float Timer;
        private byte StepSize = 3;

        public FadingPlatform(Vector2 pos, Texture2D tex)
            : base(pos, tex)
        {
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
                Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

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
            foreach (GameObject gameObject in Collides)
            {
                if (!(gameObject is BasePlatform))
                {
                    var movingObject = gameObject as MovingObject;
                    movingObject?.LandOnPlatform(1, this);
                    
                    found = true;
                }
            }

            return found;
        }
    }
}
