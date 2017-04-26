﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NogardTheDragon.Managers;
using NogardTheDragon.Objects;
using NogardTheDragon.Objects.AbilitysPowerups;
using NogardTheDragon.Objects.Platforms;
using NogardTheDragon.Utilities;

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
                        objectList.Add(new Platform(new Vector2(dObj.PosX, dObj.PosY),
                            TextureManager.StandardPlatformTex));
                        break;
                    case DummyObject.TypeEnum.MovingPlatform:
                        objectList.Add(new MovingPlatform(new Vector2(dObj.PosX, dObj.PosY),
                            TextureManager.MovingPlatformTex));
                        break;
                    case DummyObject.TypeEnum.SpikePlatform:
                        objectList.Add(new SpikePlatform(new Vector2(dObj.PosX, dObj.PosY),
                            TextureManager.SpikePlatformTex));
                        break;
                    case DummyObject.TypeEnum.CloudPlatform:
                        objectList.Add(new CloudPlatform(new Vector2(dObj.PosX, dObj.PosY),
                            TextureManager.CloudPlatformTex));
                        break;
                    case DummyObject.TypeEnum.IcePlatform:
                        objectList.Add(new IcePlatform(new Vector2(dObj.PosX, dObj.PosY), TextureManager.IcePlatformTex));
                        break;
                    case DummyObject.TypeEnum.Player:
                        objectList.Add(new Player(new Vector2(dObj.PosX, dObj.PosY), TextureManager.PlayerTex));
                        break;
                    case DummyObject.TypeEnum.Goal:
                        objectList.Add(new Goal(new Vector2(dObj.PosX, dObj.PosY), TextureManager.GoalTex));
                        break;
                    case DummyObject.TypeEnum.Enemy:
                        objectList.Add(new BaseEnemy(new Vector2(dObj.PosX, dObj.PosY), TextureManager.StandardEnemyTex));
                        break;
                    case DummyObject.TypeEnum.UnlimitedPowerPowerup:
                        objectList.Add(new UnlimitedPowerObject(new Vector2(dObj.PosX, dObj.PosY),
                            TextureManager.UnlimitedPowerTex));
                        break;
                    case DummyObject.TypeEnum.SlowWorldPowerup:
                        objectList.Add(new SlowWorldPowerObject(new Vector2(dObj.PosX, dObj.PosY),
                            TextureManager.SlowWorldTex));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            return new Map(objectList);
        }
    }
}