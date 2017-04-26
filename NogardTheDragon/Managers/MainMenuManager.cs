using Microsoft.Xna.Framework;

namespace NogardTheDragon.Managers
{
    public class MainMenuManager : BaseManager
    {
        private readonly NogardGame Game;

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
            NogardGame.SpriteBatch.Draw(TextureManager.MainMenuBackTex, new Vector2(-100, 0), Color.White);
            NogardGame.ButtonManager.Draw();
        }
    }
}