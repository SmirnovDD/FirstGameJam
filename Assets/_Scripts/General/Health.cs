using System;
using UnityEngine;

namespace _Scripts.General
{
    public class Health : MonoBehaviour
    {
        [SerializeField] protected float _initial;

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
            Destroy(gameObject);
        }
    }
}
