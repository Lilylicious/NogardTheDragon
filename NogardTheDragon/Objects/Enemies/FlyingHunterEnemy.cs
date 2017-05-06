using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon.Objects.Enemies
{
    internal class FlyingHunterEnemy : BaseEnemy
    {
        FlyingHunterEnemy Flyinghunterenemy;
        private int MaxDist;
        private int MinDist;

        public FlyingHunterEnemy(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
            MaxDist = 10;
            MinDist = 5;
        }

        public override void Update(GameTime gameTime)
        {
            Flyinghunterenemy.LookAt(Player);

            if (Vector3.Distance(Flyinghunterenemy.position, Player.position) >= MinDist)
            {

                Flyinghunterenemy.position += Flyinghunterenemy.forward * Speed * Time.deltaTime;



                if (Vector3.Distance(Flyinghunterenemy.position, Player.position) <= MaxDist)
                {
                    //Here Call any function U want Like Shoot at here or something
                }
            }
        }
    }
}
