using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using NogardTheDragon.Objects;
using NogardTheDragon.Objects.Enemies;
using NogardTheDragon.Objects.Platforms;

namespace NogardUnitTesting
{
    [TestClass]
    public class InteractionTests
    {
        /* Notes!
         * Test projectile collision with several targets (platforms, enemy, player)
         * Test abilities, adding/removing/using
         * Test powerups, adding/removing/using
         */
        private static Platform Platform;
        private static PrivateObject PrivatePlatform;
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
        }


        //### Start of Projectiles ###
        [TestMethod]
        public void TestPlatformNullCollision()
        {
            //Platform.Collides.Clear();

            //Result = (bool) PrivatePlatform.Invoke("HandleCollision");
            //Assert.IsFalse(Result);
        }
        //### End of Projectiles ###
    }
}