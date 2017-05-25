using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Managers;

namespace NogardTheDragon.Animation
{
    internal class MainMenuBackground
    {
        private Texture2D backgroundTex;
        private readonly List<Vector2> cloud1;
        private readonly List<Vector2> cloud2;
        private readonly List<string> strings;
        private float timer;
        private readonly GameWindow window;

        public MainMenuBackground(GameWindow window)
        {
            this.window = window;

            var sr = new StreamReader(@"Content\\Clouds.txt");
            strings = new List<string>();

            while (!sr.EndOfStream)
                strings.Add(sr.ReadLine());
            sr.Close();

            cloud1 = new List<Vector2>();
            cloud2 = new List<Vector2>();

            for (var j = 0; j < 12; j++)
            for (var i = 0; i < 2; i++)
                if (strings[i][j] == 'c')
                    cloud1.Add(new Vector2(j * 150, 50 + i * 80));
                else if (strings[i][j] == 'C')
                    cloud2.Add(new Vector2(j * 150, 20 + i * 120));
        }

        public void Update(GameTime gameTime)
        {
            CloudUpdate(cloud1);
            CloudUpdate(cloud2);

            timer += (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > 10)
                timer = 0;

            if (timer > 6.9f && timer < 7)
                backgroundTex = TextureManager.MainMenuBackTex2;
            else if (timer > 1.9f && timer < 2)
                backgroundTex = TextureManager.MainMenuBackTex3;
            else
                backgroundTex = TextureManager.MainMenuBackTex1;
        }

        public void CloudUpdate(List<Vector2> listName)
        {
            for (var i = 0; i < listName.Count; i++)
            {
                listName[i] = new Vector2(listName[i].X - 0.4f, listName[i].Y);

                if (listName[i].X <= -800)
                {
                    var j = i - 1;
                    if (j < 0)
                        j = listName.Count - 1;

                    listName[i] = new Vector2(window.ClientBounds.Width + 100, listName[i].Y);
                }
            }
        }

        public void Draw()
        {
            foreach (var pos in cloud1)
                NogardGame.SpriteBatch.Draw(TextureManager.MainMenuCloudTex1, pos, Color.White);
            foreach (var pos in cloud2)
                NogardGame.SpriteBatch.Draw(TextureManager.MainMenuCloudTex2, pos, Color.White);

            NogardGame.SpriteBatch.Draw(backgroundTex, new Vector2(-100, 0), Color.White);
        }
    }
}