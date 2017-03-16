using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using NogardTheDragon.Objects;

namespace NogardTheDragon.Map
{
    internal class MapReader
    {
        public static Map ReadMap(string fileName)
        {
            var strings = new List<string>();
            var sr = new StreamReader(fileName + ".txt");

            while (!sr.EndOfStream)
                strings.Add(sr.ReadLine());

            sr.Close();
            //kiiiiiiiii
            //k
            //k

            var objectList = new List<GameObject>();

            var placeholder = "";

            for (var i = 0; i < strings.Count; i++)
            for (var k = 0; k < strings[i].Length; k++)
            {
                placeholder = strings[i][k].ToString();

                var pos = new Vector2(Platform.PlatformWidth * k, Platform.PlatformWidth * i);

                if (placeholder == "p")
                    objectList.Add(new Platform(pos, NogardGame.PlatformTexture));
                if (placeholder == "u")
                {
                    var p = new Player(pos + new Vector2(0, -25), NogardGame.PlayerSheet);
                    objectList.Add(p);
                    NogardGame.GamePlayManager.Player = p;
                }
                if (placeholder == "g")
                    //objectList.Add(new Goal(pos, MarioGame.GenSheet));
                if (placeholder == "d")
                    //objectList.Add(new DinoEnemy(pos, MarioGame.GenSheet));


                        placeholder = "";
            }

            return new Map(objectList);
        }
    }
}