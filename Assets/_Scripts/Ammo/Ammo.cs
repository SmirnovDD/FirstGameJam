using _Scripts.General;
using UnityEngine;

namespace _Scripts.Ammo
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private BallisticMotion _ballisticMotion;
        private void OnTriggerEnter(Collider other)
        {
            if (CanDamage(other, out var damagable))
            {
                var damage = GetDamageMultiplier(other);
                damagable.Damage(damage);
            }

            transform.parent = other.transform;
            Destroy(this);
            if (_ballisticMotion)
                Destroy(_ballisticMotion);
        }

        private float GetDamageMultiplier(Collider other)
        {
            var damage = _damage;
            var damageMultiplierZone = other.GetComponent<DamageMultiplierZone>();
            if (damageMultiplierZone != null)
                damage *= damageMultiplierZone.Amount;
            return damage;
        }

        protected virtual bool CanDamage(Collider target, out IDamagable damagable)
        {
            damagable = null;
            return false;
        }
    }
}
