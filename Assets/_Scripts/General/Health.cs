using System;
using _Scripts.AI;
using UnityEngine;

namespace _Scripts.General
{
    public class Health : MonoBehaviour
    {
        [SerializeField] protected float _initial;
        [SerializeField] private bool _finalBoss;
        [SerializeField] private ParticleSystem _particles;
        public float Initial => _initial;

        private float _current;

        private void Awake()
        {
            _current = _initial;
        }

        public float Current
        {
            get => _current;
            set
            {
                _current = value;
                if (_current <= 0)
                    Die();
            }
        }

        private void Die()
        {
            if (!_finalBoss)
                Destroy(gameObject);
            else
            {
                Instantiate(_particles, transform.position, Quaternion.identity);
                Destroy(GetComponent<BossDragonAttack>());
                Destroy(GetComponent<BossDragonMovement>());
                GetComponent<AnimationsController>().PlayDeathAnimation();
                _finalBoss = false;
                Invoke(nameof(Die), 1f);
            }
        }
    }
}
