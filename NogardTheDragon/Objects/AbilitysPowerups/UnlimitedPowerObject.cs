using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Abilities;

namespace NogardTheDragon.Objects.AbilitysPowerups
{
    internal class UnlimitedPowerObject : PowerupObject
    {
        public UnlimitedPowerObject(Vector2 pos, Texture2D tex) : base(pos, tex)
        {
        }

        public override void AddPowerup(GameTime gameTime)
        {
            ((Player) CollidingWith).AddPowerup(new UnlimitedPower(gameTime));
            Active = false;
        }

        protected override bool HandleCollision(GameTime gameTime)
        {
            var p = CollidingWith as Player;
            if (p == null) return false;

            AddPowerup(gameTime);
            return true;
        }
    }
}