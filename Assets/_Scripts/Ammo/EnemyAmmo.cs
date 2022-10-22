using _Scripts.General;
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Ammo
{
    public class EnemyAmmo : Ammo
    {
        protected override bool CanDamage(Collider target, out IDamagable damagable)
        {
            var player = target.GetComponentInParent<IPlayer>();
            if (player == null)
            {
                damagable = null;
                return false;
            }

            damagable = player;
            return true;
        }
    }
}