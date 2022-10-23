using System;
using UnityEngine;

namespace _Scripts.AI
{
    public class BossDragonMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _rayStart;
        [SerializeField] private Transform _rayEnd;
        [SerializeField] private LayerMask _mask;
        
        private float _flightDelay = 3f;
        private Transform _target;
        private Transform _playerTransform;
        private Transform _transform;
        private float _defaultHight;
        public void Start()
        {
            var playerTransform = GetComponent<BossDragonAttack>().PlayerTransform;
            if (playerTransform == null)
                return;
            _playerTransform = GetComponent<Enemy>().PlayerTransform;
            _target = FindObjectOfType<BossDragonTarget>().transform;
            _transform = transform;
            _defaultHight = _transform.position.y;
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

            if (Physics.Linecast(_rayStart.position, _rayEnd.position, _mask))
                _transform.position += Vector3.up * (Time.deltaTime * 10f);
            else
            {
                _transform.position = new Vector3(transform.position.x, Mathf.Lerp(_transform.position.y, _defaultHight, Time.deltaTime * 10f), transform.position.z);
            }
            var position = _transform.position;
            if (Vector3.Distance(_transform.position, _target.position) < 3f)
            {
                transform.LookAt(_playerTransform);
                return;
            }
            _transform.position = Vector3.MoveTowards(position, _target.position, _speed * Time.deltaTime);
            transform.LookAt(_target);
        }
        
        #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Debug.DrawLine(_rayStart.position, _rayEnd.position, Color.magenta);
        }
#endif
    }
}