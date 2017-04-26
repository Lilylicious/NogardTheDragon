using System;
using NogardTheDragon.Objects;
using NogardTheDragon.Objects.AbilitysPowerups;
using NogardTheDragon.Objects.Platforms;

namespace NogardTheDragon.Utilities
{
    [Serializable]
    internal class DummyObject
    {
        public enum TypeEnum
        {
            Platform,
            MovingPlatform,
            SpikePlatform,
            CloudPlatform,
            IcePlatform,
            Player,
            Goal,
            Enemy,
            UnlimitedPowerPowerup,
            SlowWorldPowerup
        }

        public float PosX;
        public float PosY;
        public TypeEnum Type;

        public DummyObject(GameObject obj)
        {
            if (obj is Platform)
                Type = TypeEnum.Platform;
            if (obj is MovingPlatform)
                Type = TypeEnum.MovingPlatform;
            if (obj is SpikePlatform)
                Type = TypeEnum.SpikePlatform;
            if (obj is CloudPlatform)
                Type = TypeEnum.CloudPlatform;
            if (obj is IcePlatform)
                Type = TypeEnum.IcePlatform;
            if (obj is Player)
                Type = TypeEnum.Player;
            if (obj is Goal)
                Type = TypeEnum.Goal;
            if (obj is BaseEnemy)
                Type = TypeEnum.Enemy;
            if (obj is UnlimitedPowerObject)
                Type = TypeEnum.UnlimitedPowerPowerup;
            if (obj is SlowWorldPowerObject)
                Type = TypeEnum.SlowWorldPowerup;

            PosX = obj.GetPosition().X;
            PosY = obj.GetPosition().Y;
        }
    }
}