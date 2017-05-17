using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NogardTheDragon.Managers;
using NogardTheDragon.Utilities;
using System.IO;
using System.Collections.Generic;
using NogardTheDragon.Objects;

namespace NogardTheDragon
{
    public class NogardGame : Game
    {
        public enum GameStateEnum
        {
            MainMenu,
            GameActive,
            HighScoreView,
            GameOver,
            Pause,
            MapMaker,
            LevelSelector
        }

        public static SpriteBatch SpriteBatch;
        public static int TotalScore, HealthBonus, KillBonus, LevlBonus, TimeBonus;

        public static GameStateEnum GameState = GameStateEnum.MainMenu;

        public static MainMenuManager MainMenuManager;
        public static GamePlayManager GamePlayManager;
        public static GameOverManager GameOverManager;
        public static MapMakerManager MapMakerManager;
        public static LevelSelectorManager LevelSelectorManager;
        public static ButtonManager ButtonManager;
        public static HighScoreDisplay HighScoreDisplay;

        public static GraphicsDeviceManager Graphics;

        public NogardGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Window.Title = "Nogard the Dragon";
            Graphics.PreferredBackBufferWidth = 900;
            Graphics.PreferredBackBufferHeight = 700;
            Graphics.ApplyChanges();
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.LoadTextures(Content);

            MainMenuManager = new MainMenuManager(this);
            GamePlayManager = new GamePlayManager();
            GameOverManager = new GameOverManager(this);
            MapMakerManager = new MapMakerManager(this);
            ButtonManager = new ButtonManager();
            HighScoreDisplay = new HighScoreDisplay();
            LevelSelectorManager = new LevelSelectorManager();
            MainMenuManager.Init();
            ButtonManager.Init();
            

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();
            Variables.Update();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                MainMenuManager.Init();

            TotalScore = KillBonus + HealthBonus;

            switch (GameState)
            {
                case GameStateEnum.MainMenu:
                    MainMenuManager.Update(gameTime);
                    break;
                case GameStateEnum.GameActive:
                    GamePlayManager.Update(gameTime);
                    break;
                case GameStateEnum.HighScoreView:
                    HighScoreDisplay.Update(gameTime);
                    break;
                case GameStateEnum.GameOver:
                    GameOverManager.Update(gameTime);
                    break;
                case GameStateEnum.Pause:
                    break;
                case GameStateEnum.MapMaker:
                    MapMakerManager.Update(gameTime);
                    break;
                case GameStateEnum.LevelSelector:
                    LevelSelectorManager.Update(gameTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            ButtonManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            switch (GameState)
            {
                case GameStateEnum.MainMenu:
                    SpriteBatch.Begin();
                    GraphicsDevice.Clear(Color.DeepSkyBlue);
                    MainMenuManager.Draw();
                    break;
                case GameStateEnum.GameActive:
                    SpriteBatch.Begin(SpriteSortMode.FrontToBack, null, null, null, null, null,
                    GamePlayManager.ActiveMap?.Cam.GetTransform());
                    GamePlayManager.Draw();
                    break;
                case GameStateEnum.HighScoreView:
                    SpriteBatch.Begin();
                    HighScoreDisplay.Draw();
                    break;
                case GameStateEnum.GameOver:
                    SpriteBatch.Begin();
                    GameOverManager.Draw();
                    break;
                case GameStateEnum.Pause:
                    break;
                case GameStateEnum.MapMaker:
                    SpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null,
                    MapMakerManager?.Cam.GetTransform());
                    MapMakerManager?.Draw();
                    break;
                case GameStateEnum.LevelSelector:
                    SpriteBatch.Begin();
                    LevelSelectorManager.Draw();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            ButtonManager.Draw();
            if (GameState == GameStateEnum.GameActive ||
                GameState == GameStateEnum.Pause ||
                GameState == GameStateEnum.GameOver)
                Window.Title = TotalScore.ToString();
            else
                Window.Title = "Nogard the Dragon";

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}