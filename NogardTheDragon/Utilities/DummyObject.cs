using System;
using NogardTheDragon.Objects;
using NogardTheDragon.Objects.AbilitysPowerups;
using NogardTheDragon.Objects.Enemies;
using NogardTheDragon.Objects.Platforms;

namespace NogardTheDragon.Utilities
{
    [Serializable]
    internal class DummyObject
    {
        public enum TypeEnum
        {
            Platform,
            VerticalPlatform,
            HorizontalPlatform,
            SpikePlatform,
            CloudPlatform,
            IcePlatform,
            FadingPlatform,
            Player,
            Goal,
            Enemy,
            WalkingEnemy,
            FlyingEnemy,
            UnlimitedPowerPowerup,
            SlowWorldPowerup,
            HealthGain
        }

        public float PosX;
        public float PosY;
        public TypeEnum Type;

        public DummyObject(GameObject obj)
        {
            if (obj is Platform)
                Type = TypeEnum.Platform;
            if (obj is VerticalPlatform)
                Type = TypeEnum.VerticalPlatform;
            if (obj is HorizontalPlatform)
                Type = TypeEnum.HorizontalPlatform;
            if (obj is SpikePlatform)
                Type = TypeEnum.SpikePlatform;
            if (obj is CloudPlatform)
                Type = TypeEnum.CloudPlatform;
            if (obj is IcePlatform)
                Type = TypeEnum.IcePlatform;
            if (obj is FadingPlatform)
                Type = TypeEnum.FadingPlatform;
            if (obj is Player)
                Type = TypeEnum.Player;
            if (obj is Goal)
                Type = TypeEnum.Goal;
            if (obj is BaseEnemy)
                Type = TypeEnum.Enemy;
            if (obj is StandardEnemy)
                Type = TypeEnum.WalkingEnemy;
            if (obj is FlyingEnemy)
                Type = TypeEnum.FlyingEnemy;
            if (obj is UnlimitedPowerObject)
                Type = TypeEnum.UnlimitedPowerPowerup;
            if (obj is SlowWorldPowerObject)
                Type = TypeEnum.SlowWorldPowerup;
            if (obj is HealthGain)
                Type = TypeEnum.HealthGain;

            PosX = obj.GetPosition().X;
            PosY = obj.GetPosition().Y;
        }
    }
}