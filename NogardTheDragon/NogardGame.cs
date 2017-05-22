using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            HighScoreView,
            Story,
            GameOver,
            Pause,
            MapMaker,
            LevelSelector
        }

        public static bool Admin = true;
        public static SpriteBatch SpriteBatch;
        public static int TotalScore, HealthBonus, KillBonus, LevelBonus, MapsComplete;

        public static GameStateEnum GameState = GameStateEnum.MainMenu;

        public static MainMenuManager MainMenuManager;
        public static GamePlayManager GamePlayManager;
        public static StoryMode StoryMode;
        public static GameOverManager GameOverManager;
        public static MapMakerManager MapMakerManager;
        public static LevelSelectorManager LevelSelectorManager;
        public static ButtonManager ButtonManager;
        public static HighScoreDisplay HighScoreDisplay;
        public static PauseManager PauseManager;
        public static MusicManager MusicManager;


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
            StoryMode = new StoryMode();
            GameOverManager = new GameOverManager(this);
            MapMakerManager = new MapMakerManager(this);
            ButtonManager = new ButtonManager();
            HighScoreDisplay = new HighScoreDisplay();
            LevelSelectorManager = new LevelSelectorManager();
            PauseManager = new PauseManager();
            MusicManager = new MusicManager();
            MainMenuManager.Init();
            ButtonManager.Init();
            MusicManager.Init();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();
            Variables.Update();

            TotalScore = KillBonus + HealthBonus + LevelBonus;

            MusicManager.Update(gameTime);
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
                case GameStateEnum.Story:
                    StoryMode.Update(gameTime);
                    break;
                case GameStateEnum.GameOver:
                    GameOverManager.Update(gameTime);
                    break;
                case GameStateEnum.Pause:
                    PauseManager.Update(gameTime);
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
            GraphicsDevice.Clear(new Color(240, 240, 240, 255));

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
                case GameStateEnum.Story:
                    SpriteBatch.Begin();
                    StoryMode.Draw();
                    break;
                case GameStateEnum.GameOver:
                    SpriteBatch.Begin();
                    GameOverManager.Draw();
                    break;
                case GameStateEnum.Pause:
                    SpriteBatch.Begin(SpriteSortMode.FrontToBack, null, null, null, null, null,
                        GamePlayManager.ActiveMap?.Cam.GetTransform());
                    GamePlayManager.Draw();
                    SpriteBatch.End();
                    SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                    PauseManager.Draw();
                    break;
                case GameStateEnum.MapMaker:
                    SpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null,
                        MapMakerManager?.Cam.GetTransform());
                    MapMakerManager?.Draw();
                    break;
                case GameStateEnum.LevelSelector:
                    SpriteBatch.Begin();
                    GraphicsDevice.Clear(Color.Purple);
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