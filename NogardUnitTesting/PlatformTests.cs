using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using NogardTheDragon.Objects;
using NogardTheDragon.Objects.Enemies;
using NogardTheDragon.Objects.Platforms;
using NogardTheDragon.Managers;
using NogardTheDragon.Utilities;

namespace NogardUnitTesting
{
    [TestClass]
    public class PlatformTests
    {
        private static Platform Platform;
        private static PrivateObject PrivatePlatform;
        private static SpikePlatform SpikePlatform;
        private static PrivateObject PrivateSpikePlatform;
        private static HorizontalPlatform HorizontalPlatform;
        private static PrivateObject PrivateHorizontal;
        private static VerticalPlatform VerticalPlatform;
        private static PrivateObject PrivateVertical;
        private static IcePlatform IcePlatform;
        private static PrivateObject PrivateIcePlatform;
        private static CloudPlatform CloudPlatform;
        private static PrivateObject PrivateCloudPlatform;

        private static Player Player;
        private static PrivateObject PrivatePlayer;
        private static BaseEnemy Enemy;
        private static PrivateObject PrivateEnemy;

        private bool Result;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            //Textures used don't matter, as none of them are initialized
            Player = new Player(Vector2.Zero);
            PrivatePlayer = new PrivateObject(Player);
            Enemy = new BaseEnemy(Vector2.Zero);
            PrivateEnemy = new PrivateObject(Enemy);

            Platform = new Platform(Vector2.Zero);
            PrivatePlatform = new PrivateObject(Platform);
            SpikePlatform = new SpikePlatform(Vector2.Zero);
            PrivateSpikePlatform = new PrivateObject(SpikePlatform);
            HorizontalPlatform = new HorizontalPlatform(Vector2.Zero);
            PrivateHorizontal = new PrivateObject(HorizontalPlatform);
            VerticalPlatform = new VerticalPlatform(Vector2.Zero);
            PrivateVertical = new PrivateObject(VerticalPlatform);
            IcePlatform = new IcePlatform(Vector2.Zero);
            PrivateIcePlatform = new PrivateObject(IcePlatform);
            CloudPlatform = new CloudPlatform(Vector2.Zero); 
            PrivateCloudPlatform = new PrivateObject(CloudPlatform);
        }


        //### Start of Standard Platform ###
        [TestMethod]
        public void TestPlatformNullCollision()
        {
            Platform.Collides.Clear();

            Result = (bool)PrivatePlatform.Invoke("HandleCollision");
            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestPlatformPlayerCollision()
        {
            Platform.Collides.Clear();

            Platform.Collides.Add(Player);

            Result = (bool)PrivatePlatform.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestPlatformEnemyCollision()
        {
            Platform.Collides.Clear();

            Platform.Collides.Add(Enemy);

            Result = (bool)PrivatePlatform.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestPlatformPlatformCollision()
        {
            Platform.Collides.Clear();

            Platform.Collides.Add(new Platform(Vector2.One));

            Result = (bool)PrivatePlatform.Invoke("HandleCollision");
            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestPlatformPlatformAndPlayerCollision()
        {
            Platform.Collides.Clear();

            Platform.Collides.Add(new Platform(Vector2.One));
            Platform.Collides.Add(Player);

            Result = (bool)PrivatePlatform.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }
        //### End of Standard Platform ###

        //### Start of Cloud Platform ###
        [TestMethod]
        public void TestCloudNullCollision()
        {
            CloudPlatform.Collides.Clear();

            CloudPlatform.Collides.Add(new Platform(Vector2.One));

            Result = (bool)PrivateCloudPlatform.Invoke("HandleCollision");
            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestCloudPlayerCollision()
        {
            CloudPlatform.Collides.Clear();

            CloudPlatform.Collides.Add(Player);

            Result = (bool)PrivateCloudPlatform.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestCloudEnemyCollision()
        {
            CloudPlatform.Collides.Clear();

            CloudPlatform.Collides.Add(Enemy);

            Result = (bool)PrivateCloudPlatform.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestCloudPlatformCollision()
        {
            CloudPlatform.Collides.Clear();

            CloudPlatform.Collides.Add(new Platform(Vector2.One));

            Result = (bool)PrivateCloudPlatform.Invoke("HandleCollision");
            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestCloudPlatformAndPlayerCollision()
        {
            CloudPlatform.Collides.Clear();

            CloudPlatform.Collides.Add(new Platform(Vector2.One));
            CloudPlatform.Collides.Add(Player);

            Result = (bool)PrivateCloudPlatform.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestCloudFail()
        {
            CloudPlatform.Collides.Clear();
            CloudPlatform.Collides.Add(Player);
            Player.SetVelocity(new Vector2(0, -5));

            Result = Player.LandOnCloudPlatform();
            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestCloudSuccess()
        {
            CloudPlatform.Collides.Clear();
            CloudPlatform.Collides.Add(Player);
            Player.SetVelocity(new Vector2(0, 5));

            Result = Player.LandOnCloudPlatform();
            Player.SetVelocity(new Vector2(0, 0));
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestCloudVelocity()
        {
            CloudPlatform.Collides.Clear();
            CloudPlatform.Collides.Add(Player);
            Player.SetVelocity(new Vector2(0, 10));

            Player.LandOnCloudPlatform();

            Result = Player.GetVelocity().Y == 2;

            Player.SetVelocity(new Vector2(0, 0));
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestCloudLanding()
        {
            CloudPlatform.Collides.Clear();
            CloudPlatform.Collides.Add(Player);
            Player.SetVelocity(new Vector2(0, 10));
            Player.Airborn = true;

            Player.LandOnCloudPlatform();

            Result = Player.Airborn == false;

            Player.SetVelocity(new Vector2(0, 0));
            Assert.IsTrue(Result);
        }
        //### End of Cloud Platform ###

        //### Start of Ice Platform ###
        [TestMethod]
        public void TestIceNullCollision()
        {
            IcePlatform.Collides.Clear();

            Result = (bool)PrivateIcePlatform.Invoke("HandleCollision");
            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestIcePlayerCollision()
        {
            IcePlatform.Collides.Clear();

            IcePlatform.Collides.Add(Player);

            Result = (bool)PrivateIcePlatform.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestIceEnemyCollision()
        {
            IcePlatform.Collides.Clear();

            IcePlatform.Collides.Add(Enemy);

            Result = (bool)PrivateIcePlatform.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestIcePlatformCollision()
        {
            IcePlatform.Collides.Clear();

            IcePlatform.Collides.Add(new Platform(Vector2.One));

            Result = (bool)PrivateIcePlatform.Invoke("HandleCollision");
            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestIcePlatformAndPlayerCollision()
        {
            IcePlatform.Collides.Clear();

            IcePlatform.Collides.Add(new Platform(Vector2.One));
            IcePlatform.Collides.Add(Player);

            Result = (bool)PrivateIcePlatform.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestIceFail()
        {
            IcePlatform.Collides.Clear();
            IcePlatform.Collides.Add(Player);
            Player.SetVelocity(new Vector2(0, -5));

            Result = Player.LandOnIcePlatform(IcePlatform);
            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestIceSuccess()
        {
            IcePlatform.Collides.Clear();
            IcePlatform.Collides.Add(Player);
            Player.SetVelocity(new Vector2(0, 5));

            Result = Player.LandOnIcePlatform(IcePlatform);
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestIceMovementRight()
        {
            IcePlatform.Collides.Clear();
            IcePlatform.Collides.Add(Player);
            Player.SetVelocity(new Vector2(0, 10));
            Player.SetPosition(Vector2.Zero);
            PrivatePlayer.SetField("LastFacing", MovingObject.Facing.Right);

            Player.LandOnIcePlatform(IcePlatform);

            Result = Player.GetVelocity().X == 1;

            Player.SetVelocity(new Vector2(0, 0));
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestIceMovementLeft()
        {
            IcePlatform.Collides.Clear();
            IcePlatform.Collides.Add(Player);
            Player.SetVelocity(new Vector2(0, 10));
            Player.SetPosition(Vector2.Zero);
            PrivatePlayer.SetField("LastFacing", MovingObject.Facing.Left);

            Player.LandOnIcePlatform(IcePlatform);

            Result = Player.GetVelocity().X == -1;

            Player.SetVelocity(new Vector2(0, 0));
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestIceGliding()
        {
            IcePlatform.Collides.Clear();
            IcePlatform.Collides.Add(Player);
            Player.Gliding = true;

            Result = (bool)PrivateIcePlatform.Invoke("HandleCollision");
            Assert.IsFalse(Result);
        }

        //### End of Ice Platform ###

        //### Start of Horizontal Platform ###
        [TestMethod]
        public void TestHorizontalPlatformNullCollision()
        {
            HorizontalPlatform.Collides.Clear();

            Result = (bool)PrivateHorizontal.Invoke("HandleCollision");
            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestHorizontalPlatformPlayerCollision()
        {
            HorizontalPlatform.Collides.Clear();

            HorizontalPlatform.Collides.Add(Player);

            Result = (bool)PrivateHorizontal.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestHorizontalPlatformEnemyCollision()
        {
            HorizontalPlatform.Collides.Clear();

            HorizontalPlatform.Collides.Add(Enemy);

            Result = (bool)PrivateHorizontal.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestHorizontalPlatformPlatformCollision()
        {
            HorizontalPlatform.Collides.Clear();

            HorizontalPlatform.Collides.Add(new Platform(Vector2.One));

            Result = (bool)PrivateHorizontal.Invoke("HandleCollision");
            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestHorizontalPlatformPlatformAndPlayerCollision()
        {
            HorizontalPlatform.Collides.Clear();

            HorizontalPlatform.Collides.Add(new Platform(Vector2.One));
            HorizontalPlatform.Collides.Add(Player);
            Player.Moving = false;

            Result = (bool)PrivateHorizontal.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }
        //### End of Horizontal Platform ###

        //### Start of Vertical Platform ###
        [TestMethod]
        public void TestVerticalPlatformNullCollision()
        {
            VerticalPlatform.Collides.Clear();

            Result = (bool)PrivateVertical.Invoke("HandleCollision");
            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestVerticalPlatformPlayerCollision()
        {
            VerticalPlatform.Collides.Clear();

            VerticalPlatform.Collides.Add(Player);

            Result = (bool)PrivateVertical.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestVerticalPlatformEnemyCollision()
        {
            VerticalPlatform.Collides.Clear();

            VerticalPlatform.Collides.Add(Enemy);

            Result = (bool)PrivateVertical.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestVerticalPlatformPlatformCollision()
        {
            VerticalPlatform.Collides.Clear();

            VerticalPlatform.Collides.Add(new Platform(Vector2.One));

            Result = (bool)PrivateVertical.Invoke("HandleCollision");
            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestVerticalPlatformPlatformAndPlayerCollision()
        {
            VerticalPlatform.Collides.Clear();

            VerticalPlatform.Collides.Add(new Platform(Vector2.One));
            VerticalPlatform.Collides.Add(Player);

            Result = (bool)PrivateVertical.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }
        //### End of Vertical Platform ###

        //### Start of Spike Platform ###
        [TestMethod]
        public void TestSpikePlatformDamagePlayer()
        {
            SpikePlatform.Collides.Clear();
            SpikePlatform.Collides.Add(Player);
            Player.SetVelocity(new Vector2(0, 5));
            Player.Health = 3;

            PrivateSpikePlatform.Invoke("HandleCollision");

            Result = Player.Health == 2;
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestSpikePlatformNullCollision()
        {
            SpikePlatform.Collides.Clear();

            Result = (bool)PrivateSpikePlatform.Invoke("HandleCollision");
            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestSpikePlatformPlayerCollision()
        {
            SpikePlatform.Collides.Clear();
            SpikePlatform.Collides.Add(Player);

            Result = (bool)PrivateSpikePlatform.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestSpikePlatformEnemyCollision()
        {
            SpikePlatform.Collides.Clear();

            SpikePlatform.Collides.Add(Enemy);

            Result = (bool)PrivateSpikePlatform.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void TestSpikePlatformPlatformCollision()
        {
            SpikePlatform.Collides.Clear();

            SpikePlatform.Collides.Add(new Platform(Vector2.One));

            Result = (bool)PrivateSpikePlatform.Invoke("HandleCollision");
            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void TestSpikePlatformPlatformAndPlayerCollision()
        {
            SpikePlatform.Collides.Clear();

            SpikePlatform.Collides.Add(new Platform(Vector2.One));
            SpikePlatform.Collides.Add(Player);

            Result = (bool)PrivateSpikePlatform.Invoke("HandleCollision");
            Assert.IsTrue(Result);
        }


        [TestMethod]
        public void TestSpikePlatformDamageEnemy()
        {
            SpikePlatform.Collides.Clear();
            SpikePlatform.Collides.Add(Enemy);
            Enemy.Health = 3;

            PrivateSpikePlatform.Invoke("HandleCollision");

            Result = Enemy.Health == 2;
            Assert.IsTrue(Result);
        }
        //### End of Spike Platform ###
    }
}
