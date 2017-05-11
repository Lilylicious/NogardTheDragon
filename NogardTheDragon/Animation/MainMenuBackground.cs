using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.Animation
{
    class MainMenuBackground
    {
        private List<Vector2> cloud1, cloud2;
        private List<string> strings;
        private float timer;
        private Texture2D backgroundTex;
        private GameWindow window;

        public MainMenuBackground(GameWindow window)
        {
            this.window = window;

            StreamReader sr = new StreamReader(@"Content\\Clouds.txt");
            strings = new List<string>();

            while (!sr.EndOfStream)
            {
                strings.Add(sr.ReadLine());
            }
            sr.Close();

            cloud1 = new List<Vector2>();
            cloud2 = new List<Vector2>();

            for (int j = 0; j < 12; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (strings[i][j] == 'c')
                    {
                        cloud1.Add(new Vector2(j * 150, 50 + i * 80));
                    }
                    else if (strings[i][j] == 'C')
                    {
                        cloud2.Add(new Vector2(j * 150, 20 + i * 120));
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            CloudUpdate(cloud1);
            CloudUpdate(cloud2);

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > 10)
            {
                timer = 0;
            }

            if (timer > 6.9f && timer < 7)
            {
                backgroundTex = TextureManager.MainMenuBackTex2;
            }
            else if (timer > 1.9f && timer < 2)
            {
                backgroundTex = TextureManager.MainMenuBackTex3;
            }
            else
                backgroundTex = TextureManager.MainMenuBackTex1;
        }

        public void CloudUpdate(List<Vector2> listName)
        {
            for (int i = 0; i < listName.Count; i++)
            {
                listName[i] = new Vector2(listName[i].X - 0.4f, listName[i].Y);

                if (listName[i].X <= -800)
                {
                    int j = i - 1;
                    if (j < 0)
                    {
                        j = listName.Count - 1;
                    }

                    listName[i] = new Vector2(window.ClientBounds.Width + 100, listName[i].Y);
                }
            }
        }

        public void Draw()
        {
            foreach (Vector2 pos in cloud1)
            {
                NogardGame.SpriteBatch.Draw(TextureManager.MainMenuCloudTex1, pos, Color.White);
            }
            foreach (Vector2 pos in cloud2)
            {
                NogardGame.SpriteBatch.Draw(TextureManager.MainMenuCloudTex2, pos, Color.White);
            }

            NogardGame.SpriteBatch.Draw(backgroundTex, new Vector2(-100, 0), Color.White);
        }
    }
}
