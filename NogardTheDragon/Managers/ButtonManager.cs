﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Managers
{
    public class ButtonManager : BaseManager
    {
        public StandardButton BackButton;
        public List<StandardButton> Buttons;
        public StandardButton LevelOneButton, LevelTwoButton, LevelThreeButton, SelectorBackButton;

        public StandardButton PlayButton,
            ScoreButton,
            AboutNogardButton,
            InstuctionsButton,
            ExitButton,
            MapButton;

        public StandardButton ResumeButton, PauseMenuButton;
        public StandardButton SaveScoreButton, MainMenuButton, QuitButton, ContinueButton;

        public override void Init()
        {
            Buttons = new List<StandardButton>();

            MainMenuButtons();
            HighScoreButtons();
            GameOverButtons();
            LevelSelectorButtons();
            PauseButtons();
            StoryModeButtons();
        }

        public override void Update(GameTime gameTime)
        {
            switch (NogardGame.GameState)
            {
                case NogardGame.GameStateEnum.MainMenu:
                    foreach (var b in Buttons)
                        b.Update(Color.Goldenrod, Color.Yellow);
                    break;
                case NogardGame.GameStateEnum.Story:
                    if (StoryMode.IntroStory)
                        BackButton.Update(Color.Goldenrod, Color.Black);
                    else
                        ContinueButton.Update(Color.Goldenrod, Color.Black);
                    break;
                case NogardGame.GameStateEnum.GameActive:
                    break;
                case NogardGame.GameStateEnum.HighScoreView:
                    foreach (var b in Buttons)
                        b.Update(Color.Goldenrod, Color.Black);
                    break;
                case NogardGame.GameStateEnum.Pause:
                    foreach (var b in Buttons)
                        b.Update(Color.Goldenrod, Color.Yellow);
                    break;
                case NogardGame.GameStateEnum.GameOver:
                    foreach (var b in Buttons)
                    {
                        b.Update(Color.White, Color.Black);
                        if (b.Equals(SaveScoreButton) && GameOverManager.ScoreForm.GameSaved)
                            b.Update(Color.Transparent, Color.Transparent);
                    }
                    break;
                case NogardGame.GameStateEnum.MapMaker:
                    break;
                case NogardGame.GameStateEnum.LevelSelector:
                    foreach (var b in Buttons)
                        b.Update(Color.Goldenrod, Color.Yellow);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
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
                case NogardGame.GameStateEnum.Story:
                    if (StoryMode.IntroStory)
                        BackButton.DrawStandardButton(5, " Back", 0.5f);
                    else
                        ContinueButton.DrawStandardButton(5, "  Continue", 0.5f);
                    break;
                case NogardGame.GameStateEnum.GameActive:
                    break;
                case NogardGame.GameStateEnum.HighScoreView:
                    BackButton.DrawStandardButton(5, " Back", 0.5f);
                    break;
                case NogardGame.GameStateEnum.Pause:
                    ResumeButton.DrawStandardButton(5, "Resume", 0.5f);
                    PauseMenuButton.DrawStandardButton(5, "MainMenu", 0.5f);
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
                case NogardGame.GameStateEnum.LevelSelector:
                    LevelOneButton.DrawStandardButton(5, " Level One", 0.5f);
                    LevelTwoButton.DrawStandardButton(5, " Level Two", 0.5f);
                    LevelThreeButton.DrawStandardButton(5, " Level Three", 0.5f);
                    SelectorBackButton.DrawStandardButton(5, " Back", 0.4f);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void MainMenuButtons()
        {
            PlayButton = new StandardButton(new Rectangle(610, 20, 260, 120));
            Buttons.Add(PlayButton);
            ScoreButton = new StandardButton(new Rectangle(610, 150, 260, 70));
            Buttons.Add(ScoreButton);
            AboutNogardButton = new StandardButton(new Rectangle(610, 230, 260, 60));
            Buttons.Add(AboutNogardButton);
            InstuctionsButton = new StandardButton(new Rectangle(610, 300, 260, 60));
            Buttons.Add(InstuctionsButton);
            ExitButton = new StandardButton(new Rectangle(690, 370, 90, 55));
            Buttons.Add(ExitButton);
            MapButton = new StandardButton(new Rectangle(10, 635, 210, 55));
            Buttons.Add(MapButton);
        }

        public void GameOverButtons()
        {
            SaveScoreButton = new StandardButton(new Rectangle(300, 350, 260, 70));
            Buttons.Add(SaveScoreButton);
            MainMenuButton = new StandardButton(new Rectangle(230, 460, 185, 55));
            Buttons.Add(MainMenuButton);
            QuitButton = new StandardButton(new Rectangle(460, 460, 190, 55));
            Buttons.Add(QuitButton);
        }

        public void HighScoreButtons()
        {
            BackButton = new StandardButton(new Rectangle(380, 635, 130, 55));
            Buttons.Add(BackButton);
        }

        public void LevelSelectorButtons()
        {
            LevelOneButton = new StandardButton(new Rectangle(300, 100, 300, 55));
            Buttons.Add(LevelOneButton);
            LevelTwoButton = new StandardButton(new Rectangle(300, 170, 300, 55));
            Buttons.Add(LevelTwoButton);
            LevelThreeButton = new StandardButton(new Rectangle(300, 240, 300, 55));
            Buttons.Add(LevelThreeButton);
            SelectorBackButton = new StandardButton(new Rectangle(400, 635, 110, 50));
            Buttons.Add(SelectorBackButton);
        }

        public void PauseButtons()
        {
            ResumeButton = new StandardButton(new Rectangle(257, 350, 170, 55));
            Buttons.Add(ResumeButton);
            PauseMenuButton = new StandardButton(new Rectangle(487, 350, 220, 55));
            Buttons.Add(PauseMenuButton);
        }

        public void StoryModeButtons()
        {
            BackButton = new StandardButton(new Rectangle(380, 635, 130, 55));
            Buttons.Add(BackButton);
            ContinueButton = new StandardButton(new Rectangle(330, 620, 240, 70));
            Buttons.Add(ContinueButton);
        }
    }
}