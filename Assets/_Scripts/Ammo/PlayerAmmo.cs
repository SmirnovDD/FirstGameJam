using _Scripts.General;
using UnityEngine;

namespace _Scripts.Ammo
{
    public class PlayerAmmo : Ammo
    {
        protected override bool CanDamage(Collider target, out IDamagable damagable)
        {
            var enemy = target.GetComponentInParent<IEnemy>();
            if (enemy == null)
            {
                damagable = null;
                return false;
            }

            damagable = enemy;
            return true;
        }
    }
}