﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Enemies
{
    internal class FlyingEnemy : BaseEnemy
    {
        private bool Airborn = false;
        private bool Fly;

        private bool isVisible = true;

        public FlyingEnemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            Source = new Rectangle(0, 0, 0, 0);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Velocity.Y <= 0 || Velocity.Y >= Texture.Height)
            {
                Fly = true;
                //Speed = +Speed;
            }

            if(Velocity.X < 0 - Texture.Width)
            {
                isVisible = false;
            }

            //if (frameTimer <= 0)
            //{
            //    frameTimer = frameInterval;
            //    frame++;
            //    Source = (CurrentFrame % 4) * 32;
            //}
        }

        //public void LoadFlyingEnemy()
        //{
        //    for(int i = 0; i <flyingEnemy.count; i++)
        //    {
        //        if (!flyingEnemy[i].isVisible)
        //        {
        //            flyingEnemy.RemoveAt(i);
        //            i--;
        //        }
        //    }
        //}
    }
}