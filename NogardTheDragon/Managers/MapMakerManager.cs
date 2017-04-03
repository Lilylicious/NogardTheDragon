using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NogardTheDragon.Objects;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Managers
{
    public class MapMakerManager : BaseManager
    {
        private readonly NogardGame Game;
        private readonly SpriteBatch Sb = NogardGame.SpriteBatch;
        private KeyboardState KState;
        private bool LastWasPressed;
        private Vector2 MousePosition;
        public List<GameObject> Objects = new List<GameObject>();
        private ObjectEnum SelectedObject = ObjectEnum.Platform;
        public Camera cam;
        public Vector2 camPos;
        float countX;
        float countY;

        public MapMakerManager(NogardGame game)
        {
            Game = game;
            cam = new Camera(game.GraphicsDevice.Viewport);
            camPos = new Vector2(game.Window.ClientBounds.Width / 2, game.Window.ClientBounds.Height / 2);
        }

        public void StartMapMaker()
        {
            NogardGame.GameState = NogardGame.GameStateEnum.MapMaker;
            Game.IsMouseVisible = true;
            Objects.Clear();
        }

        private void SaveToFile()
        {
            var dummyList = Objects.Select(obj => new DummyObject(obj)).ToList();
            BinarySerializer.WriteToBinaryFile(Game.Content.RootDirectory + "/SavedMap.bin", dummyList);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P))
                SelectedObject = ObjectEnum.Platform;
            if (Keyboard.GetState().IsKeyDown(Keys.U))
                SelectedObject = ObjectEnum.Player;
            if (Keyboard.GetState().IsKeyDown(Keys.C))
                SelectedObject = ObjectEnum.None;
            if (Keyboard.GetState().IsKeyDown(Keys.S) && !KState.IsKeyDown(Keys.S))
                SaveToFile();

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                camPos.X += 1;
                camPos.Y += 0;
                countX += 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                camPos.X += -1;
                camPos.Y += 0;
                countX += -1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                camPos.X += 0;
                camPos.Y += -1;
                countY += -1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                camPos.X += 0;
                camPos.Y += 1;
                countY += 1;
            }

            cam.SetPos(camPos);

            var mState = Mouse.GetState();
            MousePosition = new Vector2(mState.Position.X, Mouse.GetState().Position.Y);

            if (mState.LeftButton == ButtonState.Pressed && !LastWasPressed)
                switch (SelectedObject)
                {
                    case ObjectEnum.Platform:
                        Objects.Add(new Platform(MousePosition + new Vector2(countX, countY), NogardGame.PlatformTexture));
                        break;
                    case ObjectEnum.Player:
                        Objects.Add(new Player(MousePosition + new Vector2(countX, countY), NogardGame.PlayerSheet));
                        break;
                    case ObjectEnum.Enemy:
                        throw new NotImplementedException();
                    case ObjectEnum.Goal:
                        throw new NotImplementedException();
                    case ObjectEnum.None:
                        Objects.RemoveAll(item => Vector2.Distance(item.GetCenter(), MousePosition) < 25);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            LastWasPressed = Mouse.GetState().LeftButton == ButtonState.Pressed;
            KState = Keyboard.GetState();
        }

        public void Draw()
        {
            switch (SelectedObject)
            {
                case ObjectEnum.Platform:
                    Sb.Draw(NogardGame.PlatformTexture, MousePosition + new Vector2(countX, countY));
                    break;
                case ObjectEnum.Player:
                    Sb.Draw(NogardGame.PlayerSheet, MousePosition + new Vector2(countX, countY));
                    break;
                case ObjectEnum.Enemy:
                    throw new NotImplementedException();
                case ObjectEnum.Goal:
                    throw new NotImplementedException();
                case ObjectEnum.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            foreach (var obj in Objects)
                obj.Draw(Sb);
        }

        private enum ObjectEnum
        {
            Platform,
            Player,
            Enemy,
            Goal,
            None
        }
    }
}