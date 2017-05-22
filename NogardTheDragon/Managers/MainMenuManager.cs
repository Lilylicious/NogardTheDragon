using System.Windows.Forms;
using Microsoft.Xna.Framework;
using NogardTheDragon.Animation;

namespace NogardTheDragon.Managers
{
    public class MainMenuManager : BaseManager
    {
        private readonly NogardGame Game;
        private readonly MainMenuBackground MainMenuBackground;

        public MainMenuManager(NogardGame game)
        {
            Game = game;
            MainMenuBackground = new MainMenuBackground(game.Window);
        }

        public override void Init()
        {
            NogardGame.GameState = NogardGame.GameStateEnum.MainMenu;
            NogardGame.KillBonus = 0;
            NogardGame.TotalScore = 0;
            NogardGame.LevelBonus = 0;
        }

        public override void Update(GameTime gameTime)
        {
            MainMenuBackground.Update(gameTime);

            foreach (var b in NogardGame.ButtonManager.Buttons)
            {
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.PlayButton))
                {
                    NogardGame.LevelSelectorManager.Init();
                    NogardGame.MapsComplete = 0;
                }

                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.ScoreButton))
                {
                    NogardGame.HighScoreDisplay.Init();
                    break;
                }

                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.InstuctionsButton))
                {
                    MessageBox.Show(
                        "Movement:  Right & left keys." +
                        "\n\nJump:  Up key once for single jump," +
                        "\ntwice for double jump." +
                        "\n\nShoot projectile:  Space key." +
                        "\n\nPause game:  ESC key.");
                    break;
                }

                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.AboutNogardButton))
                {
                    NogardGame.StoryMode.Init();
                    break;
                }

                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.ExitButton))
                    Game.Exit();
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.MapButton))
                    if (NogardGame.Admin)
                        NogardGame.MapMakerManager.Init();
                    else
                        MessageBox.Show("Must be game administrator\nto access the mapmaker.");
            }
        }

        public override void Draw()
        {
            MainMenuBackground.Draw();
        }
    }
}