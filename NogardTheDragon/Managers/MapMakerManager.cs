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
        private Vector2 MousePosition;
        private Vector2 PlacePosition;
        public List<GameObject> Objects = new List<GameObject>();
        private ObjectEnum SelectedObject = ObjectEnum.Platform;
        public Camera cam;
        public Vector2 camPos;

        public MapMakerManager(NogardGame game)
        {
            Game = game;
            cam = new Camera(game.GraphicsDevice.Viewport);
            camPos = new Vector2(game.Window.ClientBounds.Width / 2, game.Window.ClientBounds.Height / 2);
        }

        public override void Init()
        {
            NogardGame.GameState = NogardGame.GameStateEnum.MapMaker;
            Game.IsMouseVisible = true;
            Objects.Clear();
        }


        private void SaveToFile()
        {
            var dummyList = Objects.Select(obj => new DummyObject(obj)).ToList();
            BinarySerializer.WriteToBinaryFile(Game.Content.RootDirectory + "/" + DateTime.Now.Ticks + ".bin", dummyList);
        }

        public override void Update(GameTime gameTime)
        {
            if (KeyMouseReader.KeyPressed(Keys.P))
                SelectedObject = ObjectEnum.Platform;
            if (KeyMouseReader.KeyPressed(Keys.U))
                SelectedObject = ObjectEnum.Player;
            if (KeyMouseReader.KeyPressed(Keys.C))
                SelectedObject = ObjectEnum.None;
            if (KeyMouseReader.KeyPressed(Keys.S))
                SaveToFile();

            if (KeyMouseReader.KeyDown(Keys.Right))
            {
                camPos.X += 1;
                camPos.Y += 0;
            }
            else if (KeyMouseReader.KeyDown(Keys.Left))
            {
                camPos.X += -1;
                camPos.Y += 0;
            }

            if (KeyMouseReader.KeyDown(Keys.Up))
            {
                camPos.X += 0;
                camPos.Y += -1;
            }
            else if (KeyMouseReader.KeyDown(Keys.Down))
            {
                camPos.X += 0;
                camPos.Y += 1;
            }

            cam.SetPos(camPos);


            MousePosition = KeyMouseReader.mousePosition;
            var transform = Matrix.Invert(cam.GetTransform());
            Vector2.Transform(ref MousePosition, ref transform, out MousePosition);
            
            PlacePosition = MousePosition;

            if(Objects.Count > 0)
            {
                var closestObj = Objects[0];
                foreach (GameObject obj in Objects)
                    if (Vector2.Distance(obj.GetCenter(), MousePosition) < Vector2.Distance(closestObj.GetCenter(), MousePosition))
                        closestObj = obj;

                if (Vector2.Distance(closestObj.GetCenter(), MousePosition) < 25)
                {
                    if(closestObj.GetCenter().X - MousePosition.X < 0)
                        PlacePosition = new Vector2(closestObj.Dest.Right, closestObj.Dest.Top);
                    else
                        PlacePosition = new Vector2(closestObj.Dest.Left - closestObj.Dest.Width, closestObj.Dest.Top);
                }
            }


            if (KeyMouseReader.LeftClick())
                switch (SelectedObject)
                {
                    case ObjectEnum.Platform:
                        Objects.Add(new Platform(PlacePosition, NogardGame.PlatformTexture));
                        break;
                    case ObjectEnum.Player:
                        Objects.Add(new Player(PlacePosition, NogardGame.PlayerSheet));
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
        }

        public override void Draw()
        {
            switch (SelectedObject)
            {
                case ObjectEnum.Platform:
                    Sb.Draw(NogardGame.PlatformTexture, PlacePosition);
                    break;
                case ObjectEnum.Player:
                    Sb.Draw(NogardGame.PlayerSheet, PlacePosition);
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