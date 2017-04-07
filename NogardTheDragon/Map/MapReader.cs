using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NogardTheDragon.Objects;
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
                        objectList.Add(new Platform(new Vector2(dObj.PosX, dObj.PosY), NogardGame.PlatformTexture));
                        break;
                    case DummyObject.TypeEnum.Player:
                        objectList.Add(new Player(new Vector2(dObj.PosX, dObj.PosY), NogardGame.PlayerSheet));
                        break;
                    case DummyObject.TypeEnum.Enemy:
                        objectList.Add(new BaseEnemy(new Vector2(dObj.PosX, dObj.PosY), NogardGame.EnemySheet));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            return new Map(objectList);
        }
    }
}