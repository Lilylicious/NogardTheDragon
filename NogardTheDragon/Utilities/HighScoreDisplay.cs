using Microsoft.Xna.Framework;
using NogardTheDragon.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Utilities
{
    public class HighScoreDisplay : BaseManager
    {
        List<HighScore> scoreList;

        public HighScoreDisplay()
        {
            scoreList = new List<HighScore>();
        }

        public override void Init()
        {
            NogardGame.GameState = NogardGame.GameStateEnum.HighScoreView;
        }

        public override void Update(GameTime gameTime)
        {
            scoreList = new List<HighScore>();

            StreamReader file = new StreamReader(@"HighScore.txt");
            string line;
            scoreList.Clear();
            while (!file.EndOfStream)
            {
                line = file.ReadLine();
                string[] temp = line.Split(',');
                int score = int.Parse(temp[1]);
                HighScore h = new HighScore(temp[0], score);
                scoreList.Add(h);
            }
            file.Close();

            scoreList.Sort((HighScore h1, HighScore h2) => { return h2.score.CompareTo(h1.score); });

            if (NogardGame.ButtonManager.BackButton.ButtonClicked)
                NogardGame.MainMenuManager.Init();

        }

        public override void Draw()
        {
            NogardGame.Graphics.GraphicsDevice.Clear(Color.Azure);

            for (int i = 0; i < 10; i++)
            {
                NogardGame.SpriteBatch.DrawString(TextureManager.Font, (i + 1) + ".",
                    new Vector2(100, 100 + (50 * i)), Color.Goldenrod, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 1);
            }

            for (int i = 0; i < scoreList.Count; i++)
            {
                NogardGame.SpriteBatch.DrawString(TextureManager.Font, scoreList[i].NameToString(),
                    new Vector2(180, 100 + (50 * i)), Color.Goldenrod, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 1);
                NogardGame.SpriteBatch.DrawString(TextureManager.Font, scoreList[i].ScoreToString(),
                    new Vector2(700, 100 + (50 * i)), Color.Goldenrod, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 1);
                if (i >= 9)
                    break;
            }
        }
    }
}
