using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Managers
{
    public class ButtonManager : BaseManager
    {
        public List<StandardButton> Buttons;
        public StandardButton PlayButton, ScoreButton, AboutNogardButton, 
            InstuctionsButton, ExitButton, MapButton;

        public StandardButton SaveScoreButton, MainMenuButton, QuitButton;

        public override void Init()
        {
            switch (NogardGame.GameState)
            {
                case NogardGame.GameStateEnum.MainMenu:
                    MainMenuButtons();
                    break;
                case NogardGame.GameStateEnum.GameActive:
                    break;
                case NogardGame.GameStateEnum.Pause:
                    break;
                case NogardGame.GameStateEnum.GameOver:
                    Buttons.Clear();
                    GameOverButtons();
                    break;
                case NogardGame.GameStateEnum.MapMaker:
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            switch (NogardGame.GameState)
            {
                case NogardGame.GameStateEnum.MainMenu:
                    foreach (var b in Buttons)
                        b.Update(Color.Goldenrod, Color.Yellow);
                    break;
                case NogardGame.GameStateEnum.GameActive:
                    break;
                case NogardGame.GameStateEnum.Pause:
                    break;
                case NogardGame.GameStateEnum.GameOver:
                    foreach (var b in Buttons)
                    {
                        b.Update(Color.BlueViolet, Color.White);
                        if (b.Equals(SaveScoreButton) && GameOverManager.ScoreForm.GameSaved == true)
                            b.Update(Color.White, Color.White);
                    }
                    break;
                case NogardGame.GameStateEnum.MapMaker:
                    break;
            }
        }

        public override void Draw()
        {
            switch (NogardGame.GameState)
            {
                case NogardGame.GameStateEnum.MainMenu:
                    PlayButton.DrawStandardButton(5, "Play", 1);
                    ScoreButton.DrawStandardButton(5, " Highscore", 0.5f);
                    AboutNogardButton.DrawStandardButton(5, "About Nogard", 0.4f);
                    InstuctionsButton.DrawStandardButton(5, "  How to play", 0.4f);
                    ExitButton.DrawStandardButton(5, " Exit", 0.4f);
                    MapButton.DrawStandardButton(5, " MapMaker", 0.4f);
                    break;
                case NogardGame.GameStateEnum.GameActive:
                    break;
                case NogardGame.GameStateEnum.Pause:
                    break;
                case NogardGame.GameStateEnum.GameOver:
                    if (GameOverManager.ScoreForm.GameSaved == false)
                        SaveScoreButton.DrawStandardButton(5, "Save Score", 0.5f);
                    else
                        SaveScoreButton.DrawStandardButton(5, "Score saved", 0.45f);
                    MainMenuButton.DrawStandardButton(5, " MainMenu", 0.4f);
                    QuitButton.DrawStandardButton(5, " Quit Game", 0.4f);
                    break;
                case NogardGame.GameStateEnum.MapMaker:
                    break;
            }
        }

        public void MainMenuButtons()
        {
            Buttons = new List<StandardButton>();
            PlayButton = new StandardButton(new Rectangle(620, 30, 260, 120));
            Buttons.Add(PlayButton);
            ScoreButton = new StandardButton(new Rectangle(620, 160, 260, 70));
            Buttons.Add(ScoreButton);
            AboutNogardButton = new StandardButton(new Rectangle(620, 240, 260, 60));
            Buttons.Add(AboutNogardButton);
            InstuctionsButton = new StandardButton(new Rectangle(620, 310, 260, 60));
            Buttons.Add(InstuctionsButton);
            ExitButton = new StandardButton(new Rectangle(795, 635, 90, 55));
            Buttons.Add(ExitButton);
            MapButton = new StandardButton(new Rectangle(10, 635, 210, 55));
            Buttons.Add(MapButton);
        }

        public void GameOverButtons()
        {
            Buttons = new List<StandardButton>();
            SaveScoreButton = new StandardButton(new Rectangle(300, 300, 260, 70));
            Buttons.Add(SaveScoreButton);
            MainMenuButton = new StandardButton(new Rectangle(230, 410, 185, 55));
            Buttons.Add(MainMenuButton);
            QuitButton = new StandardButton(new Rectangle(460, 410, 190, 55));
            Buttons.Add(QuitButton);
        }
    }
}