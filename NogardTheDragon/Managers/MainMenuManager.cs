using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Animation;
using System.Collections.Generic;
using System.IO;

namespace NogardTheDragon.Managers
{
    public class MainMenuManager : BaseManager
    {
        private readonly NogardGame Game;
        private MainMenuBackground MainMenuBackground;

        public MainMenuManager(NogardGame game)
        {
            this.Game = game;
            MainMenuBackground = new MainMenuBackground(game.Window);
        }

        public override void Init()
        {
            NogardGame.GameState = NogardGame.GameStateEnum.MainMenu;
        }

        public override void Update(GameTime gameTime)
        {
            MainMenuBackground.Update(gameTime);

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
            MainMenuBackground.Draw();
            NogardGame.ButtonManager.Draw();
        }
    }
}