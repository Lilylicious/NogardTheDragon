﻿using System;
using NogardTheDragon.Objects;

namespace NogardTheDragon.Utilities
{
    [Serializable]
    internal class DummyObject
    {
        public enum TypeEnum
        {
            Platform,
            Player
        }

        public float PosX;
        public float PosY;
        public TypeEnum Type;

        public DummyObject(GameObject obj)
        {
            if (obj is Platform)
                Type = TypeEnum.Platform;
            if (obj is Player)
                Type = TypeEnum.Player;

            PosX = obj.GetPosition().X;
            PosY = obj.GetPosition().Y;
        }
    }
}