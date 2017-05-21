using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Animation;
using NogardTheDragon.Utilities;
using System.Collections.Generic;
using System.IO;
using NogardTheDragon.Managers;
using System.Windows.Forms;

namespace NogardTheDragon.Managers
{
    public class MainMenuManager : BaseManager
    {
        private readonly NogardGame Game;
        private MainMenuBackground MainMenuBackground;

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
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.ExitButton))
                    Game.Exit();
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.MapButton))
                {
                    if (NogardGame.Admin == true)
                    NogardGame.MapMakerManager.Init();
                    else
                    MessageBox.Show("Must be game administrator\nto access the mapmaker.");
                }
            }
        }

        public override void Draw()
        {
                MainMenuBackground.Draw();
        }
    }
}