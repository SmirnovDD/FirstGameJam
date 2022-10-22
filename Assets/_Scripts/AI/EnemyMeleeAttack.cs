using _Scripts.General;
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.AI
{
    public class EnemyMeleeAttack : MonoBehaviour
    {
        [SerializeField] private float _attackRangeSquared = 1.75f * 1.75f;
        [SerializeField] private float _damage;
        [SerializeField] private float _rechargeAttackTime = 1f;
        [SerializeField] private Vector2 _attackSphereCenter;
        [SerializeField] private float _attackSphereRadius;
        [SerializeField] private LayerMask _attackMask;
        
        private ShootState _currentShootState = ShootState.Ready;
        private float _timer;
        private AnimationsController _animationsController;
        private Enemy _enemy;
        private Transform _transform;
        private void Awake()
        {
            _transform = transform;
            _animationsController = GetComponent<AnimationsController>();
            _enemy = GetComponent<Enemy>();
        }

        void Update()
        {
            if (_currentShootState == ShootState.Ready && PlayerInRange())
            {
                Attack();
                StartRecharging();
                _animationsController.PlayMeleeAttackAnimation();
            }
            else if (_currentShootState == ShootState.Reload)
            {
                Reload();
            }
        }

        private void Reload()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
                _currentShootState = ShootState.Ready;
        }

        private void Attack()
        {
            var attackBoxCenter = _transform.position + _transform.forward * _attackSphereCenter.x + _transform.up * _attackSphereCenter.y;
            var hits = Physics.OverlapSphere(attackBoxCenter, _attackSphereRadius, _attackMask, QueryTriggerInteraction.Collide);
            for (var i = hits.Length - 1; i >= 0; i--)
            {
                var hit = hits[i];
                var player = hit.transform.GetComponent<IPlayer>();
                player?.Damage(_damage);
            }
        }

        private void StartRecharging()
        {
            _currentShootState = ShootState.Reload;
            _timer = _rechargeAttackTime;
        }

        private bool PlayerInRange()
        {
            if (_enemy.PlayerTransform == null)
                return false;
            
            if ((_enemy.PlayerTransform.position - _transform.position).sqrMagnitude <= _attackRangeSquared)
                return true;
            return false;
        }
    }
}