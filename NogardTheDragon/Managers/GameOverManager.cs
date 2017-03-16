﻿using Microsoft.Xna.Framework;
using NogardTheDragon.Objects;

namespace NogardTheDragon.Managers
{
    public class GameOverManager
    {
        private readonly NogardGame Instance;
        private Player Player;

        public GameOverManager(NogardGame game)
        {
            Instance = game;
        }

        public void Init()
        {
            foreach (var gameObject in NogardGame.GamePlayManager.ActiveMap.Objects)
            {
                var o = gameObject as Player;
                if (o != null)
                    Player = o;
            }
        }

        public void Update()
        {
        }

        public void Draw()
        {
            Instance.GraphicsDevice.Clear(Color.Black);
        }
    }
}