using NogardTheDragon.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.MenuManager
{
    class MenuManager : BaseManager  
    {
        private Vector2 pos;
        private Texture2D tex;


        List<Rectangle> gameObjects = new List<Rectangle>();

        //spriteBatch = new SpriteBatch(GraphicsDevice);
        //Texture2D tex = Content.Load<Texture2D>("Golden_rectangle.png");
        


        public void MenuButton(Texture2D rectTex, Vector2 pos)
        {
            this.tex = rectTex;
            this.pos = pos;
        }


       public override void Draw()
        {
            tex = Content.Load<Texture2D>("Golden_rectangle.png");
            //SpriteBatch.Draw(new Texture2D ("Golden_rectangle.png"), pos, Color.White);
            throw new NotImplementedException();
        }

        public override void Init()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
