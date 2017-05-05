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
    class HighScoreDisplay
    {
        private List<HighScore> scoreList;

        public HighScoreDisplay()
        {
            scoreList = new List<HighScore>();
        }

        public void DisplayScore()
        {
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
        }

        public void Draw()
        {
            for (int i = 0; i < scoreList.Count; i++)
            {
                NogardGame.SpriteBatch.DrawString(TextureManager.Font, (i + 1) + ". " + scoreList[i].NameToString(), 
                    new Vector2(100, 50 * i), Color.Black, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 1);
                NogardGame.SpriteBatch.DrawString(TextureManager.Font, scoreList[i].ScoreToString(), 
                    new Vector2(700, 50 * i), Color.Black, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 1);
            }
        }
    }
}
