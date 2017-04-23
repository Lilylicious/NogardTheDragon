using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.Managers
{
    public static class TextureManager
    {
        public static Texture2D PlayerTex { get; private set; }

        public static Texture2D StandardEnemyTex { get; private set; }
        public static Texture2D ScoreEnemyTex { get; private set; }
        public static Texture2D FlyingEnemyTex { get; private set; }

        public static Texture2D StandardPlatformTex { get; private set; }
        public static Texture2D MovingPlatformTex { get; private set; }
        public static Texture2D CloudPlatformTex { get; private set; }
        public static Texture2D SpikePlatformTex { get; private set; }
        public static Texture2D IcePlatformTex { get; private set; }

        public static Texture2D IndicatorLineTex { get; private set; }
        public static Texture2D GoalTex { get; private set; }

        public static Texture2D UnlimitedPowerTex { get; private set; }
        public static Texture2D SlowWorldTex { get; private set; }

        public static void LoadTextures(ContentManager c)
        {
            PlayerTex = c.Load<Texture2D>(@"playersquare");

            StandardEnemyTex = c.Load<Texture2D>(@"BaseEnemysquare");
            //ScoreEnemyTex = c.Load<Texture2D>(@"FILENAME");
            //FlyingEnemyTex = c.Load<Texture2D>(@"FILENAME");

            StandardPlatformTex = c.Load<Texture2D>(@"plattform");
            MovingPlatformTex = c.Load<Texture2D>(@"movingplatform");
            CloudPlatformTex = c.Load<Texture2D>(@"cloudplatform");
            SpikePlatformTex = c.Load<Texture2D>(@"spikeplatform");
            IcePlatformTex = c.Load<Texture2D>(@"iceplatform");

            IndicatorLineTex = c.Load<Texture2D>(@"indicatorline");
            GoalTex = c.Load<Texture2D>(@"goal");

            UnlimitedPowerTex = c.Load<Texture2D>(@"UnlimitedPower");
            SlowWorldTex = c.Load<Texture2D>(@"SlowWorld");
        }
    }
}