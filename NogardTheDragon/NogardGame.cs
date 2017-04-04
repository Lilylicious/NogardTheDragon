using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NogardTheDragon.Managers;

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
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            TextureManager.LoadTextures(Content);
            Font = Content.Load<SpriteFont>(@"font1");

            GamePlayManager = new GamePlayManager();
            GameOverManager = new GameOverManager(this);
            MapMakerManager = new MapMakerManager(this);
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