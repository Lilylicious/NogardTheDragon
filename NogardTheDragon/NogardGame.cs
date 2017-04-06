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

        public static GameStateEnum GameState = GameStateEnum.MainMenu;

        public static GamePlayManager GamePlayManager;
        public static GameOverManager GameOverManager;
        public static MapMakerManager MapMakerManager;
        public static MenuManager MenuManager;
        public static GraphicsDeviceManager Graphics;

        public NogardGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public static SpriteFont Font { get; private set; }

        protected override void Initialize()
        {
            base.Initialize();

            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            TextureManager.LoadTextures(Content);
            Font = Content.Load<SpriteFont>(@"font1");

            // Lägger in mediafiler, kolla i MenuManager för att se hur de hämtas
            AssetManager.AddTexture("menuButtonBG", Content.Load<Texture2D>(@"playersquare"));
            AssetManager.AddFont("menuFont", Content.Load<SpriteFont>("menufont"));

            MenuManager = new MenuManager(this);
            MenuManager.Init();

            GamePlayManager = new GamePlayManager();
            GameOverManager = new GameOverManager(this);
            MapMakerManager = new MapMakerManager(this);
        }

        internal void QuitGame()
        {
            //Kanske ha en prompt först som frågar om man är säker

            Exit();
        }

        internal void StartMapMaker()
        {
            MapMakerManager.Init();
        }

        internal void StartGame()
        {
            GamePlayManager.Init();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                GamePlayManager.Init();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Tab))
                MapMakerManager.Init();

            switch (GameState)
            {
                case GameStateEnum.MainMenu:
                    MenuManager.Update(gameTime);
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
                    MenuManager.Draw();
                    break;
                case GameStateEnum.GameActive:
                    SpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, GamePlayManager.ActiveMap?.cam.GetTransform());
                    GamePlayManager.Draw();
                    break;
                case GameStateEnum.GameOver:
                    GameOverManager.Draw();
                    break;
                case GameStateEnum.Pause:
                    break;
                case GameStateEnum.MapMaker:
                    SpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, MapMakerManager?.cam.GetTransform());
                    MapMakerManager.Draw();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}