﻿using Microsoft.Xna.Framework;
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
            Pause
        }

        public static SpriteBatch SpriteBatch;

        public static GameStateEnum GameState = GameStateEnum.MainMenu;

        public static GamePlayManager GamePlayManager;
        public static GameOverManager GameOverManager;
        private GraphicsDeviceManager Graphics;


        public NogardGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public static Texture2D PlatformTexture { get; private set; }

        public static Texture2D PlayerSheet { get; private set; }

        public static Texture2D GenSheet { get; private set; }

        public static SpriteFont Font { get; private set; }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            PlatformTexture = Content.Load<Texture2D>(@"plattform");
            PlayerSheet = Content.Load<Texture2D>(@"playersquare");
            Font = Content.Load<SpriteFont>(@"font1");

            GamePlayManager = new GamePlayManager();
            GameOverManager = new GameOverManager(this);
        }

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                GamePlayManager.StartGame();

            switch (GameState)
            {
                case GameStateEnum.MainMenu:
                    break;
                case GameStateEnum.GameActive:
                    GamePlayManager.Update(gameTime);
                    break;
                case GameStateEnum.GameOver:
                    GameOverManager.Update();
                    break;
                case GameStateEnum.Pause:
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            SpriteBatch.Begin();
            switch (GameState)
            {
                case GameStateEnum.MainMenu:
                    break;
                case GameStateEnum.GameActive:
                    GamePlayManager.Draw();
                    break;
                case GameStateEnum.GameOver:
                    GameOverManager.Draw();
                    break;
                case GameStateEnum.Pause:
                    break;
            }
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}