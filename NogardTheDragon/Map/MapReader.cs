﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NogardTheDragon.Objects;
using NogardTheDragon.Utilities;
using NogardTheDragon.Managers;
using NogardTheDragon.Objects.Platforms;

namespace NogardTheDragon.Map
{
    internal class MapReader
    {
        public static Map ReadMap(string fileName)
        {
            var objectList = new List<GameObject>();
            var dummyList = BinarySerializer.ReadFromBinaryFile<List<DummyObject>>("Content\\" + fileName + ".bin");

            foreach (var dObj in dummyList)
                switch (dObj.Type)
                {
                    case DummyObject.TypeEnum.Platform:
                        objectList.Add(new Platform(new Vector2(dObj.PosX, dObj.PosY), NogardGame.PlatformTexture));
                        break;
                    case DummyObject.TypeEnum.MovingPlatform:
                        objectList.Add(new MovingPlatform(new Vector2(dObj.PosX, dObj.PosY), TextureManager.MovingPlatformTex));
                        break;
                    case DummyObject.TypeEnum.SpikePlatform:
                        objectList.Add(new SpikePlatform(new Vector2(dObj.PosX, dObj.PosY), TextureManager.SpikePlatformTex));
                        break;
                    case DummyObject.TypeEnum.CloudPlatform:
                        objectList.Add(new CloudPlatform(new Vector2(dObj.PosX, dObj.PosY), TextureManager.CloudPlatformTex));
                        break;
                    case DummyObject.TypeEnum.IcePlatform:
                        objectList.Add(new IcePlatform(new Vector2(dObj.PosX, dObj.PosY), TextureManager.IcePlatformTex));
                        break;
                    case DummyObject.TypeEnum.Player:
                        objectList.Add(new Player(new Vector2(dObj.PosX, dObj.PosY), NogardGame.PlayerSheet));
                        break;
                    case DummyObject.TypeEnum.Goal:
                        objectList.Add(new Goal(new Vector2(dObj.PosX, dObj.PosY), NogardGame.Goal));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            return new Map(objectList);
        }
    }
}