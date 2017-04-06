using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NogardTheDragon.Objects;
using NogardTheDragon.Utilities;
using NogardTheDragon.Managers;

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
                        objectList.Add(new Platform(new Vector2(dObj.PosX, dObj.PosY), TextureManager.StandardPlatformTex));
                        break;
                    case DummyObject.TypeEnum.Player:
                        objectList.Add(new Player(new Vector2(dObj.PosX, dObj.PosY), TextureManager.PlayerTex));
                        break;
                    case DummyObject.TypeEnum.Goal:
                        objectList.Add(new Goal(new Vector2(dObj.PosX, dObj.PosY), TextureManager.GoalTex));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            return new Map(objectList);
        }
    }
}