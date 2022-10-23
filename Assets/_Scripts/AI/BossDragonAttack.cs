using System;
using System.Collections;
using _Scripts.General;
using UnityEngine;

namespace _Scripts.AI
{
    public class BossDragonAttack : MonoBehaviour
    {
        [SerializeField] private GameObject _fireballStraitPrefab;
        [SerializeField] private GameObject _fireballHomingPrefab;
        [SerializeField] private float _timeBetweenAttacks;
        [SerializeField] private Transform _mouth;

        private bool _secondAttack;
        private AnimationsController _animationsController;
        private float _timer = 5f;
        private Transform _playerTransform;
        public Transform PlayerTransform => _playerTransform;

        private Transform _transform;
        private WaitForSeconds _shotsDelay = new WaitForSeconds(0.2f);
        private WaitForSeconds _shotsDelaySecondAttack = new WaitForSeconds(0.4f);
        
        private void Awake()
        {
            _animationsController = GetComponent<AnimationsController>();
            _playerTransform = FindObjectOfType<Player.Player>()?.transform;
            _transform = transform;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                StartCoroutine(Attack());
                _timer = _timeBetweenAttacks;
            }
        }

        private IEnumerator Attack()
        {
            if (_playerTransform == null)
                yield return null;
            
            _animationsController.PlayShootAnimation();
            
            var mouthPosition = _mouth.position;
            var playerPosition = _playerTransform.position + Vector3.up * 1.5f;
            
            if (!_secondAttack)
            {
                Instantiate(_fireballStraitPrefab, mouthPosition, Quaternion.LookRotation(playerPosition - mouthPosition));
                yield return _shotsDelay;
                Instantiate(_fireballStraitPrefab, mouthPosition, Quaternion.LookRotation(playerPosition - mouthPosition));
                yield return _shotsDelay;
                Instantiate(_fireballStraitPrefab, mouthPosition, Quaternion.LookRotation(playerPosition - mouthPosition));
                yield return _shotsDelay;
                Instantiate(_fireballStraitPrefab, mouthPosition, Quaternion.LookRotation(playerPosition - mouthPosition));
                yield return _shotsDelay;
                Instantiate(_fireballStraitPrefab, mouthPosition, Quaternion.LookRotation(playerPosition - mouthPosition));
            }
            else
            {
                var position = _transform.position;
                Instantiate(_fireballHomingPrefab, mouthPosition, Quaternion.LookRotation(playerPosition - position));
                yield return _shotsDelaySecondAttack;
                Instantiate(_fireballHomingPrefab, mouthPosition, Quaternion.LookRotation(playerPosition - position));
                yield return _shotsDelaySecondAttack;
                Instantiate(_fireballHomingPrefab, mouthPosition, Quaternion.LookRotation(playerPosition - position));
            }
        }
    }
}