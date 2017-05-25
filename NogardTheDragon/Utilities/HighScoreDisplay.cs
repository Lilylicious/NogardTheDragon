using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Managers;

namespace NogardTheDragon.Utilities
{
    public class HighScoreDisplay : BaseManager
    {
        private List<HighScore> scoreList;

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

            var file = new StreamReader(@"Content/HighScore.txt");
            string line;
            scoreList.Clear();
            while (!file.EndOfStream)
            {
                line = file.ReadLine();
                var temp = line.Split(',');
                var score = int.Parse(temp[1]);
                var h = new HighScore(temp[0], score);
                scoreList.Add(h);
            }
            file.Close();

            scoreList.Sort((h1, h2) => { return h2.score.CompareTo(h1.score); });

            if (NogardGame.ButtonManager.BackButton.ButtonClicked)
                NogardGame.MainMenuManager.Init();
        }

        public override void Draw()
        {
            NogardGame.Graphics.GraphicsDevice.Clear(Color.Azure);

            for (var i = 0; i < 10; i++)
                NogardGame.SpriteBatch.DrawString(TextureManager.Font, i + 1 + ".",
                    new Vector2(100, 100 + 50 * i), Color.Goldenrod, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 1);

            for (var i = 0; i < scoreList.Count; i++)
            {
                NogardGame.SpriteBatch.DrawString(TextureManager.Font, scoreList[i].NameToString(),
                    new Vector2(180, 100 + 50 * i), Color.Goldenrod, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 1);
                NogardGame.SpriteBatch.DrawString(TextureManager.Font, scoreList[i].ScoreToString(),
                    new Vector2(700, 100 + 50 * i), Color.Goldenrod, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 1);
                if (i >= 9)
                    break;
            }
        }
    }
}