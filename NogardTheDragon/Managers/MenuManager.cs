using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// By Lovisa, used on Caspers pc...

namespace NogardTheDragon.Managers
{
    public class MenuManager : BaseManager
    {
        Texture2D menuBG;
        NogardGame game;
        private readonly SpriteBatch Sb = NogardGame.SpriteBatch;
        Rectangle buttonRect;
        List<string> buttonTitles;
        List<Rectangle> buttonRects;
        Vector2 startButtonPos = new Vector2(400, 240);

        SpriteFont font;


        public MenuManager(NogardGame game)
        {
            this.game = game;
        }

        public override void Init()
        {
            // Hämtar texturer, titta i LoadContent av NogardGame för hur den lägger in
            menuBG = AssetManager.GetTexture("menuButtonBG");
            font = AssetManager.GetFont("menuFont");

            buttonRect = new Rectangle(0, 0, 200, 40);
            buttonTitles = new List<string>();
            buttonRects = new List<Rectangle>();

            buttonTitles.Add("START");
            buttonTitles.Add("MAPMAKER");
            buttonTitles.Add("QUIT");

            for (int i = 0; i < buttonTitles.Count; i++)
            {
                buttonRects.Add(new Rectangle((int)startButtonPos.X - (buttonRect.Width / 2), (int)(startButtonPos.Y + (50 * i)) - (buttonRect.Height / 2), buttonRect.Width, buttonRect.Height));
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (KeyMouseReader.LeftClick())
            {
                for (int i = 0; i < buttonRects.Count; i++)
                {
                    if (buttonRects[i].Contains(KeyMouseReader.mousePosition))
                    {
                        //Console.WriteLine("Player clicked: " + buttonTitles[i]);
                        
                        if(buttonTitles[i] == "START")
                        {
                            game.StartGame();
                        }
                        else if (buttonTitles[i] == "MAPMAKER")
                        {
                            game.StartMapMaker();
                        }
                        else if (buttonTitles[i] == "QUIT")
                        {
                            game.QuitGame();
                        }
                    }
                }
            }

            for (int i = 0; i < buttonRects.Count; i++)
            {
                if (buttonRects[i].Contains(KeyMouseReader.mousePosition))
                {
                    // Här kan man ha speciella funktioner om spelaren har musen över en knapp, ex bytar färg...
                }
            }
        }

        public override void Draw()
        {
            for (int i = 0; i < buttonTitles.Count; i++)
            {
                Vector2 pos = new Vector2(startButtonPos.X, startButtonPos.Y + (50 * i));
                
                Sb.Draw(menuBG, pos, buttonRect, Color.White, 0, new Vector2(buttonRect.Width / 2, buttonRect.Height / 2), 1, SpriteEffects.None, 0);
                Sb.DrawString(font, buttonTitles[i], pos, Color.Black, 0, new Vector2((buttonTitles[i].Length * 10) / 2, 12 / 2), 1, SpriteEffects.None, 0);
            }
        }
    }
}
