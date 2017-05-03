using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NogardTheDragon.Managers;
using NogardTheDragon.Utilities;

namespace NogardTheDragon
{
    public class NogardGame : Game
    {
        public enum GameStateEnum
        {
            MainMenu,
            GameActive,
            GameOver,
            Pause,
            MapMaker
        }

        public static SpriteBatch SpriteBatch;
        public static int TotalScore, HealthBonus, KillBonus, LevlBonus, TimeBonus;

        public static GameStateEnum GameState = GameStateEnum.MainMenu;

        public static MainMenuManager MainMenuManager;
        public static GamePlayManager GamePlayManager;
        public static GameOverManager GameOverManager;
        public static MapMakerManager MapMakerManager;
        public static ButtonManager ButtonManager;

        public static GraphicsDeviceManager Graphics;

        public NogardGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
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
            MainMenuManager.Init();

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
                Exit();

            TotalScore = KillBonus + HealthBonus;

            switch (GameState)
            {
                case GameStateEnum.MainMenu:
                    MainMenuManager.Update(gameTime);
                    break;
                case GameStateEnum.GameActive:
                    GamePlayManager.Update(gameTime);
                    break;
                case GameStateEnum.GameOver:
                    GameOverManager.Update(gameTime);
                    break;
                case GameStateEnum.Pause:
                    break;
                case GameStateEnum.MapMaker:
                    MapMakerManager.Update(gameTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
                    SpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null,
                        GamePlayManager.ActiveMap?.Cam.GetTransform());
                    GamePlayManager.Draw();
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
                default:
                    throw new ArgumentOutOfRangeException();
            }

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}