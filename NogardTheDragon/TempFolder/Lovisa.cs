using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.TempFolder
{
     
    class Lovisa
    {

        int hp = 3, invulnerableTimer = 2000, timer = 0;
        bool gameOver = false, justDmgd = false;
        Texture2D nogardPlayer;
        Texture2D gameOverScreen;
        Color damageTaken = Color.White;

        public Lovisa(Texture2D nogardPlayer, Texture2D gameOverScreen)
        {
            this.nogardPlayer = nogardPlayer;
            this.gameOverScreen = gameOverScreen;
        }

        void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyUp(Keys.K) && !justDmgd)
            {
                hp--;
                justDmgd = true;
                timer = 0;
                damageTaken = Color.Red;
            }

            if(justDmgd)
            {
                timer += gameTime.ElapsedGameTime.Milliseconds;

                if(timer >= invulnerableTimer)
                {
                    justDmgd = false;
                    damageTaken = Color.White;
                }
            }

            if(gameOver == false && hp <= 0)
            {
                gameOver = true;
            }
        }

        void Draw(SpriteBatch spriteBatch)
        {

            if(gameOver == false)
            {
                spriteBatch.Draw(nogardPlayer, new Vector2(400, 240), damageTaken);
            }

            if (gameOver == true)
            {
                spriteBatch.Draw(gameOverScreen, Vector2.Zero, Color.White);
            }
        }
    }

    

}
