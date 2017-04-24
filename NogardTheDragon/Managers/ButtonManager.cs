using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Managers
{
    public class ButtonManager : BaseManager
    {
        public StandardButton PlayButton;
        public StandardButton ScoreButton;
        public StandardButton ExitButton;
        public StandardButton MapButton;

        public List<StandardButton> Buttons;
        Color color;

        public override void Init()
        {
            switch (NogardGame.GameState)
            {
                case (NogardGame.GameStateEnum.MainMenu):
                    MainMenuButtons();
                    break;
                case (NogardGame.GameStateEnum.GameActive):
                    break;
                case (NogardGame.GameStateEnum.Pause):
                    break;
                case (NogardGame.GameStateEnum.GameOver):
                    break;
                case (NogardGame.GameStateEnum.MapMaker):
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            switch (NogardGame.GameState)
            {
                case (NogardGame.GameStateEnum.MainMenu):
                    foreach (StandardButton b in Buttons)
                    {
                        b.Update(Color.Yellow);
                    }
                    break;
                case (NogardGame.GameStateEnum.GameActive):
                    break;
                case (NogardGame.GameStateEnum.Pause):
                    break;
                case (NogardGame.GameStateEnum.GameOver):
                    break;
                case (NogardGame.GameStateEnum.MapMaker):
                    break;
            }
        }

        public override void Draw()
        {
            switch (NogardGame.GameState)
            {
                case (NogardGame.GameStateEnum.MainMenu):
                    color = Color.Goldenrod;
                    PlayButton.DrawStandardButton(5, "Play", 1);
                    ScoreButton.DrawStandardButton(5, "Highscore", 0.5f);
                    ExitButton.DrawStandardButton(5, "Exit", 0.4f);
                    MapButton.DrawStandardButton(5, "MapMaker", 0.4f);
                    break;
                case (NogardGame.GameStateEnum.GameActive):
                    break;
                case (NogardGame.GameStateEnum.Pause):
                    break;
                case (NogardGame.GameStateEnum.GameOver):
                    break;
                case (NogardGame.GameStateEnum.MapMaker):
                    break;
            }
        }

        public void MainMenuButtons()
        {
            Buttons = new List<StandardButton>();
            PlayButton = new StandardButton(new Rectangle(600, 110, 250, 120));
            Buttons.Add(PlayButton);
            ScoreButton = new StandardButton(new Rectangle(600, 250, 250, 70));
            Buttons.Add(ScoreButton);
            ExitButton = new StandardButton(new Rectangle(680, 340, 90, 55));
            Buttons.Add(ExitButton);
            MapButton = new StandardButton(new Rectangle(10, 635, 230, 55));
            Buttons.Add(MapButton);
        }
    }
}
