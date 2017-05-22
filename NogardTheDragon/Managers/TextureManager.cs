using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace NogardTheDragon.Managers
{
    public static class TextureManager
    {
        public static Texture2D PlayerTex { get; private set; }
        public static Texture2D HpTex { get; private set; }
        public static Texture2D LostHPTex { get; private set; }

        public static Texture2D StandardEnemyTex { get; private set; }
        public static Texture2D ScoreEnemyTex { get; private set; }
        public static Texture2D FlyingEnemyTex { get; private set; }

        public static Texture2D StandardPlatformTex { get; private set; }
        public static Texture2D MovingPlatformTex { get; private set; }
        public static Texture2D MovingPlatformTex2 { get; private set; }
        public static Texture2D CloudPlatformTex { get; private set; }
        public static Texture2D SpikePlatformTex { get; private set; }
        public static Texture2D IcePlatformTex { get; private set; }
        public static Texture2D FadingPlatformTex { get; private set; }

        public static Texture2D MainMenuBackTex1 { get; private set; }
        public static Texture2D MainMenuBackTex2 { get; private set; }
        public static Texture2D MainMenuBackTex3 { get; private set; }
        public static Texture2D MainMenuCloudTex1 { get; private set; }
        public static Texture2D MainMenuCloudTex2 { get; private set; }

        public static Texture2D GameBackgroundTex1 { get; private set; }

        public static Texture2D RectButton { get; private set; }
        public static Texture2D IndicatorLineTex { get; private set; }
        public static Texture2D GoalTex { get; private set; }

        public static SpriteFont Font { get; private set; }
        public static Texture2D UnlimitedPowerTex { get; private set; }
        public static Texture2D SlowWorldTex { get; private set; }
        public static Texture2D HpGainTex { get; private set; }


        public static Texture2D NogardAbilitySpritesheet { get; private set; }
        public static Texture2D EnemySpritesheet { get; private set; }
        public static Texture2D PlatformSpritesheet { get; private set; }

        public static Song Song1 { get; private set; }
        public static Song Song2 { get; private set; }

        public static void LoadTextures(ContentManager c)
        {
            PlayerTex = c.Load<Texture2D>(@"playersquare");
            HpTex = c.Load<Texture2D>(@"hpTex");
            LostHPTex = c.Load<Texture2D>(@"noHpTex");

            StandardEnemyTex = c.Load<Texture2D>(@"BaseEnemysquare");
            //ScoreEnemyTex = c.Load<Texture2D>(@"FILENAME");
            //FlyingEnemyTex = c.Load<Texture2D>(@"FILENAME");

            StandardPlatformTex = c.Load<Texture2D>(@"plattform");
            MovingPlatformTex = c.Load<Texture2D>(@"movingplatform");
            MovingPlatformTex2 = c.Load<Texture2D>(@"movingplatform2");
            CloudPlatformTex = c.Load<Texture2D>(@"cloudplatform");
            SpikePlatformTex = c.Load<Texture2D>(@"spikeplatform");
            IcePlatformTex = c.Load<Texture2D>(@"iceplatform");
            FadingPlatformTex = c.Load<Texture2D>(@"dissplatform");

            MainMenuBackTex1 = c.Load<Texture2D>(@"MainMenuBack1.0");
            MainMenuBackTex2 = c.Load<Texture2D>(@"MainMenuBack1.1");
            MainMenuBackTex3 = c.Load<Texture2D>(@"MainMenuBack1.2");
            MainMenuCloudTex1 = c.Load<Texture2D>(@"cloud1");
            MainMenuCloudTex2 = c.Load<Texture2D>(@"cloud2");

            //GameBackgroundTex1 = c.Load<Texture2D>(@"fileName");

            IndicatorLineTex = c.Load<Texture2D>(@"indicatorline");
            GoalTex = c.Load<Texture2D>(@"goal");
            Font = c.Load<SpriteFont>(@"font1");
            RectButton = new Texture2D(NogardGame.SpriteBatch.GraphicsDevice, 1, 1);
            RectButton.SetData(new[] {Color.White});

            UnlimitedPowerTex = c.Load<Texture2D>(@"UnlimitedPower");
            SlowWorldTex = c.Load<Texture2D>(@"SlowWorld");

            NogardAbilitySpritesheet = c.Load<Texture2D>(@"Spritesheets/NogardAbilitySpritesheet");
            EnemySpritesheet = c.Load<Texture2D>(@"Spritesheets/EnemySpritesheet");
            PlatformSpritesheet = c.Load<Texture2D>(@"Spritesheets/PlatformSpritesheet");
            HpGainTex = c.Load<Texture2D>(@"HpGain");

            Song1 = c.Load<Song>("Music/Glor");
            Song2 = c.Load<Song>("Music/Toy");
        }
    }
}