using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Objects;

namespace NogardTheDragon.Managers
{
    public class GameOverManager : BaseManager
    {
        private readonly NogardGame Instance;
        private bool Won;
        public static Form1 ScoreForm;

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
            base.Init();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var b in NogardGame.ButtonManager.Buttons)
            {
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.SaveScoreButton) && !ScoreForm.GameSaved)
                    ScoreForm.Show();
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.MainMenuButton))
                    NogardGame.MainMenuManager.Init();
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.QuitButton))
                    Instance.Exit();
            }

            if (ScoreForm.GameSaved)
                ScoreForm.Close();

            base.Update(gameTime);
        }

        public override void Draw()
        {
            Instance.GraphicsDevice.Clear(Color.Black);


            if(Won)
                NogardGame.SpriteBatch.Draw(TextureManager.PlayerTex, Vector2.One, Color.White);
            else
                NogardGame.SpriteBatch.Draw(TextureManager.StandardEnemyTex, Vector2.One, Color.White);


            NogardGame.SpriteBatch.DrawString(TextureManager.Font, "Total Score = " + NogardGame.TotalScore,
                new Vector2(260, 200), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 1);

            base.Draw();



        }
    }
}