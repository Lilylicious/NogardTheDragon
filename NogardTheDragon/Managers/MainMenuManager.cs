using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Managers
{
    public class MainMenuManager : BaseManager
    {
        private readonly NogardGame Game;
        private Texture2D backgroundTex;
        private float timer;
        private Vector2 texPos;

        public MainMenuManager(NogardGame game)
        {
            Game = game;
        }

        public override void Init()
        {
            NogardGame.GameState = NogardGame.GameStateEnum.MainMenu;
        }

        public override void Update(GameTime gameTime)
        {
            texPos.X -= 0.5f;

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

            NogardGame.ButtonManager.Update(gameTime);

            foreach (var b in NogardGame.ButtonManager.Buttons)
            {
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.PlayButton))
                    NogardGame.GamePlayManager.Init();
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.ScoreButton))
                {
                }
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.ExitButton))
                    Game.Exit();
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.MapButton))
                    NogardGame.MapMakerManager.Init();
            }
        }

        public override void Draw()
        {
            NogardGame.SpriteBatch.Draw(TextureManager.MainMenuCloudTex1, new Vector2(texPos.X + 200, texPos.Y + 100), Color.White);
            NogardGame.SpriteBatch.Draw(TextureManager.MainMenuCloudTex2, new Vector2(texPos.X + 700, texPos.Y + 200), Color.White);
            NogardGame.SpriteBatch.Draw(backgroundTex, new Vector2(-100, 0), Color.White);
            NogardGame.ButtonManager.Draw();
        }
    }
}