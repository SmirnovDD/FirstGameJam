using UnityEngine;

namespace _Scripts.AI
{
    public class BossDragonMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private float _flightDelay = 5f;
        private Transform _target;
        private Transform _transform;
        public void Start()
        {
            var playerTransform = GetComponent<BossDragonAttack>().PlayerTransform;
            if (playerTransform == null)
                return;
            
            _target = FindObjectOfType<BossDragonTarget>().transform;
            _transform = transform;
        }

        private void Update()
        {
            if (_target == null)
                return;
            
            if (_flightDelay > 0)
            {
                _flightDelay -= Time.deltaTime;
                return;
            }

            var position = _transform.position;
            _transform.position = Vector3.Lerp(position, _target.position, Time.deltaTime * _speed);
            transform.LookAt(_target);
        }
    }
}