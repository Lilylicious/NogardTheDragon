﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Managers
{
    public class GameOverManager : BaseManager
    {
        public static Form1 ScoreForm;
        private readonly NogardGame Instance;
        private bool Won;

        public GameOverManager(NogardGame game)
        {
            Instance = game;
        }

        public void Win()
        {
            Won = true;
            Init();
        }

        public void Lose()
        {
            Won = false;
            Init();
        }

        public override void Init()
        {
            NogardGame.GameState = NogardGame.GameStateEnum.GameOver;
            ScoreForm = new Form1(Instance);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var b in NogardGame.ButtonManager.Buttons)
            {
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.SaveScoreButton) && !ScoreForm.GameSaved)
                    ScoreForm.Show();

                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.MainMenuButton))
                {
                    NogardGame.MainMenuManager.Init();
                    break;
                }
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.QuitButton))
                    Instance.Exit();
            }

            if (ScoreForm.GameSaved)
                ScoreForm.Close();
        }

        public override void Draw()
        {
            if (Won)
            {
                Instance.GraphicsDevice.Clear(Color.Blue);
                NogardGame.SpriteBatch.DrawString(TextureManager.Font, "Thank you for saving little Nogard!" +
                                                                       "\n     Play again to beat your record.",
                    new Vector2(150, 70), Color.Orange, 0, Vector2.Zero, 0.4f, SpriteEffects.None, 1);
            }
            else
            {
                Instance.GraphicsDevice.Clear(Color.Black);
                NogardGame.SpriteBatch.DrawString(TextureManager.Font, "Oow, Nogard is too injured to carry on." +
                                                                       "\n         Try again by starting over!",
                    new Vector2(100, 70), Color.Orange, 0, Vector2.Zero, 0.4f, SpriteEffects.None, 1);
            }

            NogardGame.SpriteBatch.DrawString(TextureManager.Font, "Total Score = " + NogardGame.TotalScore,
                new Vector2(260, 260), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 1);
        }
    }
}