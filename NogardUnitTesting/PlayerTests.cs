using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using NogardTheDragon;
using NogardTheDragon.Objects;
using NogardTheDragon.Managers;

namespace NogardUnitTesting
{
    [TestClass]
    public class CollisionTests
    {
        private static Player Player;
        private static PrivateObject PrivatePlayer;
        private bool Result;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            Player = new Player(Vector2.Zero, TextureManager.PlayerTex);
            PrivatePlayer = new PrivateObject(Player);
        }

        [TestMethod]
        public void TestNullCollision()
        {
            PrivatePlayer.SetField("CollidingWith", null);
            Player.SetVelocity(new Vector2(0, 10));

            Result = (bool)PrivatePlayer.Invoke("HandleCollision");

            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestPlatformCollision()
        {

            var platform = new Platform(new Vector2(50, 75), TextureManager.StandardPlatformTex);

            PrivateObject.SetField("CollidingWith", platform);
            Player.SetVelocity(new Vector2(0, 10));

            Result = (bool)PrivateObject.Invoke("HandleCollision");

            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestSpikeCollision()
        {

            var platform = new SpikePlatform(new Vector2(50, 75), TextureManager.StandardPlatformTex);

            PrivateObject.SetField("CollidingWith", platform);
            Player.SetVelocity(new Vector2(0, 10));
            var health = Player.Health;

            PrivateObject.Invoke("HandleCollision");

            Assert.AreEqual(Player.Health, health - 1);
        }

        [TestMethod]
        public void TestCloudPlatform()
        {
            var platform = new CloudPlatform(new Vector2(50, 75), TextureManager.StandardPlatformTex);

            PrivateObject.SetField("CollidingWith", platform);
            PrivateObject.SetField("Airborn", true);
            Player.SetVelocity(new Vector2(0, 10));

            PrivateObject.Invoke("HandleCollision");

            Assert.IsFalse((bool)PrivateObject.GetField("Airborn"));
        }
    }
}
