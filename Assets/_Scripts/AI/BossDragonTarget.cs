using System;
using UnityEngine;

namespace _Scripts.AI
{
    public class BossDragonTarget : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private Transform _rotator;

        private void Awake()
        {
            _rotator.SetParent(null);
        }

        private void Update()
        {
            if (_player == null)
                return;
            _rotator.position = _player.position;
            _rotator.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
        }
    }
}