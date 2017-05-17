using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NogardTheDragon.Map;
using NogardTheDragon.Objects;
using NogardTheDragon.Objects.AbilitysPowerups;
using NogardTheDragon.Objects.Enemies;
using NogardTheDragon.Objects.Platforms;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Managers
{
    public class MapMakerManager : BaseManager
    {
        private readonly NogardGame Game;
        private readonly SpriteBatch Sb = NogardGame.SpriteBatch;
        public Camera Cam;
        public Vector2 CamPos;
        private int ClickCounter;
        private Vector2 MousePosition;
        public List<GameObject> Objects = new List<GameObject>();
        private Vector2 PlacePosition;
        private ObjectEnum SelectedObject = ObjectEnum.Platform;

        public MapMakerManager(NogardGame game)
        {
            Game = game;
            Cam = new Camera(game.GraphicsDevice.Viewport);
            CamPos = new Vector2(game.Window.ClientBounds.Width / 2, game.Window.ClientBounds.Height / 2);
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

        private void ReadFromFile()
        {
            Objects = MapReader.ReadFile("Map");
        }

        public override void Update(GameTime gameTime)
        {
            if (KeyMouseReader.KeyPressed(Keys.P))
            {
                ClickCounter++;

                switch (ClickCounter % 7)
                {
                    case 0:
                        SelectedObject = ObjectEnum.Platform;
                        break;
                    case 1:
                        SelectedObject = ObjectEnum.VerticalPlatform;
                        break;
                    case 2:
                        SelectedObject = ObjectEnum.HorizontalPlatform;
                        break;
                    case 3:
                        SelectedObject = ObjectEnum.SpikePlatform;
                        break;
                    case 4:
                        SelectedObject = ObjectEnum.CloudPlatform;
                        break;
                    case 5:
                        SelectedObject = ObjectEnum.IcePlatform;
                        break;
                    case 6:
                        SelectedObject = ObjectEnum.FadingPlatform;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            if (KeyMouseReader.KeyPressed(Keys.U))
                SelectedObject = ObjectEnum.Player;
            if (KeyMouseReader.KeyPressed(Keys.G))
                SelectedObject = ObjectEnum.Goal;
            if (Keyboard.GetState().IsKeyDown(Keys.E))
                SelectedObject = ObjectEnum.Enemy;
            if (Keyboard.GetState().IsKeyDown(Keys.C))
                SelectedObject = ObjectEnum.None;
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                SelectedObject = ObjectEnum.UnlimitedPower;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                SelectedObject = ObjectEnum.SlowWorld;
            if (Keyboard.GetState().IsKeyDown(Keys.H))
                SelectedObject = ObjectEnum.HpGain;
            if (KeyMouseReader.KeyPressed(Keys.S))
                SaveToFile();
            if(KeyMouseReader.KeyPressed(Keys.L))
                ReadFromFile();
            if (KeyMouseReader.KeyDown(Keys.Right))
            {
                CamPos.X += 1;
                CamPos.Y += 0;
            }
            else if (KeyMouseReader.KeyDown(Keys.Left))
            {
                CamPos.X += -1;
                CamPos.Y += 0;
            }

            if (KeyMouseReader.KeyDown(Keys.Up))
            {
                CamPos.X += 0;
                CamPos.Y += -1;
            }
            else if (KeyMouseReader.KeyDown(Keys.Down))
            {
                CamPos.X += 0;
                CamPos.Y += 1;
            }

            Cam.SetPos(CamPos);


            MousePosition = KeyMouseReader.MousePosition;
            var transform = Matrix.Invert(Cam.GetTransform());
            Vector2.Transform(ref MousePosition, ref transform, out MousePosition);

            PlacePosition = MousePosition;

            if (Objects.Count > 0 && SelectedObject != ObjectEnum.Player)
            {
                var closestObj = Objects[0];
                foreach (var obj in Objects)
                    if (Vector2.Distance(obj.GetCenter(), MousePosition) <
                        Vector2.Distance(closestObj.GetCenter(), MousePosition))
                        closestObj = obj;

                if (Vector2.Distance(closestObj.GetCenter(), MousePosition) < 25)
                    PlacePosition = closestObj.GetCenter().X - MousePosition.X < 0 ? new Vector2(closestObj.Dest.Right, closestObj.Dest.Top) : new Vector2(closestObj.Dest.Left - closestObj.Dest.Width, closestObj.Dest.Top);
            }


            if (KeyMouseReader.LeftClick())
                switch (SelectedObject)
                {
                    case ObjectEnum.Platform:
                        Objects.Add(new Platform(PlacePosition, TextureManager.StandardPlatformTex));
                        break;
                    case ObjectEnum.VerticalPlatform:
                        Objects.Add(new VerticalPlatform(PlacePosition, TextureManager.MovingPlatformTex));
                        break;
                    case ObjectEnum.HorizontalPlatform:
                        Objects.Add(new HorizontalPlatform(PlacePosition, TextureManager.MovingPlatformTex2));
                        break;
                    case ObjectEnum.SpikePlatform:
                        Objects.Add(new SpikePlatform(PlacePosition, TextureManager.SpikePlatformTex));
                        break;
                    case ObjectEnum.CloudPlatform:
                        Objects.Add(new CloudPlatform(PlacePosition, TextureManager.CloudPlatformTex));
                        break;
                    case ObjectEnum.IcePlatform:
                        Objects.Add(new IcePlatform(PlacePosition, TextureManager.IcePlatformTex));
                        break;
                    case ObjectEnum.FadingPlatform:
                        Objects.Add(new FadingPlatform(PlacePosition, TextureManager.FadingPlatformTex));
                        break;
                    case ObjectEnum.Player:
                        Objects.Add(new Player(PlacePosition, TextureManager.PlayerTex));
                        break;
                    case ObjectEnum.Enemy:
                        Objects.Add(new BaseEnemy(MousePosition, TextureManager.StandardEnemyTex));
                        break;
                    case ObjectEnum.Goal:
                        Objects.Add(new Goal(PlacePosition, TextureManager.GoalTex));
                        break;
                    case ObjectEnum.None:
                        Objects.RemoveAll(item => Vector2.Distance(item.GetCenter(), MousePosition) < 25);
                        break;
                    case ObjectEnum.UnlimitedPower:
                        Objects.Add(new UnlimitedPowerObject(PlacePosition, TextureManager.UnlimitedPowerTex));
                        break;
                    case ObjectEnum.SlowWorld:
                        Objects.Add(new SlowWorldPowerObject(PlacePosition, TextureManager.SlowWorldTex));
                        break;
                    case ObjectEnum.HpGain:
                        Objects.Add(new HealthGain(PlacePosition, TextureManager.HpGainTex));
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
                    Sb.Draw(TextureManager.StandardPlatformTex, PlacePosition);
                    Sb.Draw(TextureManager.IndicatorLineTex, PlacePosition + new Vector2(0, 200));
                    break;
                case ObjectEnum.VerticalPlatform:
                    Sb.Draw(TextureManager.MovingPlatformTex, PlacePosition);
                    break;
                case ObjectEnum.HorizontalPlatform:
                    Sb.Draw(TextureManager.MovingPlatformTex2, PlacePosition);
                    break;
                case ObjectEnum.SpikePlatform:
                    Sb.Draw(TextureManager.SpikePlatformTex, PlacePosition);
                    break;
                case ObjectEnum.CloudPlatform:
                    Sb.Draw(TextureManager.CloudPlatformTex, PlacePosition);
                    break;
                case ObjectEnum.IcePlatform:
                    Sb.Draw(TextureManager.IcePlatformTex, PlacePosition);
                    break;
                case ObjectEnum.FadingPlatform:
                    Sb.Draw(TextureManager.FadingPlatformTex, PlacePosition);
                    break;
                case ObjectEnum.Player:
                    Sb.Draw(TextureManager.PlayerTex, PlacePosition);
                    break;
                case ObjectEnum.Enemy:
                    Sb.Draw(TextureManager.StandardEnemyTex, MousePosition);
                    break;
                case ObjectEnum.Goal:
                    Sb.Draw(TextureManager.GoalTex, PlacePosition);
                    break;
                case ObjectEnum.None:
                    break;
                case ObjectEnum.UnlimitedPower:
                    Sb.Draw(TextureManager.UnlimitedPowerTex, PlacePosition);
                    break;
                case ObjectEnum.SlowWorld:
                    Sb.Draw(TextureManager.SlowWorldTex, PlacePosition);
                    break;
                case ObjectEnum.HpGain:
                    Sb.Draw(TextureManager.HpGainTex, PlacePosition);
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
            VerticalPlatform,
            HorizontalPlatform,
            SpikePlatform,
            CloudPlatform,
            IcePlatform,
            FadingPlatform,
            Player,
            Enemy,
            Goal,
            UnlimitedPower,
            SlowWorld,
            HpGain,
            None
        }
    }
}