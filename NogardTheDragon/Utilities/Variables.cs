namespace NogardTheDragon.Utilities
{
    internal static class Variables
    {
        //Worldspeed works like: Speed = 1 / WorldSpeed. Increase worldspeed for slower game.
        public const int DefaultWorldSpeed = 1;
        public static int WorldSpeed = DefaultWorldSpeed;
        public static int Ticks;
        public static bool UpdateTick;
        public static bool UnlimitedPower = false;

        public static void Update()
        {
            Ticks++;
            UpdateTick = Ticks % WorldSpeed == 0;
        }
    }
}