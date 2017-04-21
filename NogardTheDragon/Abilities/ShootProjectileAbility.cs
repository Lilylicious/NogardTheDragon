using Microsoft.Xna.Framework;
using NogardTheDragon.Managers;
using NogardTheDragon.Objects;

namespace NogardTheDragon.Abilities
{
    internal class ShootProjectileAbility : BaseAbility
    {
        public ShootProjectileAbility(MovingObject owner) : base(owner)
        {
        }

        public override void TriggerAbility()
        {
            NogardGame.GamePlayManager.ActiveMap.ProjectilesToAdd.Add(new Projectile(
                new Vector2(Owner.GetVelocity().X > 0 ? Owner.Dest.Right : Owner.Dest.Left, Owner.Dest.Top),
                TextureManager.PlayerTex,
                new Vector2(Owner.GetVelocity().X > 0 ? 1 : -1, 0),
                Owner));
        }
    }
}