using UnityEngine;

namespace _Scripts.Ammo
{
    public class EnemyFireball : EnemyAmmo
    {
        protected override void OnHit(Collider other)
        {
            Destroy(gameObject);
        }
    }
}