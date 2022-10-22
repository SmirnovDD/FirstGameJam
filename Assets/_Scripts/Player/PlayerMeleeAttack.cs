using System;
using _Scripts.General;
using StarterAssets;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerMeleeAttack : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _rechargeAttackTime = 1f;
        [SerializeField] private StarterAssetsInputs _inputs;
        [SerializeField] private Vector2 _attackSphereCenter;
        [SerializeField] private float _attackSphereRadius;
        [SerializeField] private LayerMask _attackMask;
        
        private PlayerAmmunitionController _playerAmmunitionController;
        private ShootState _currentShootState = ShootState.Ready;
        private float _timer;
        private AmmunitionType _relatedAmmunitionType = AmmunitionType.Axe;
        private AnimationsController _animationsController;
        
        private void Awake()
        {
            _inputs = GetComponent<StarterAssetsInputs>();
            _playerAmmunitionController = GetComponent<PlayerAmmunitionController>();
            _animationsController = GetComponent<AnimationsController>();
        }

        void Update()
        {
            if (_playerAmmunitionController.ChosenAmmunition.Type != _relatedAmmunitionType)
                return;
            
            if (_inputs.Attack && _currentShootState == ShootState.Ready)
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
            var thisTransform = transform;
            var attackBoxCenter = thisTransform.position + thisTransform.forward * _attackSphereCenter.x + thisTransform.up * _attackSphereCenter.y;
            var hits = Physics.OverlapSphere(attackBoxCenter, _attackSphereRadius, _attackMask, QueryTriggerInteraction.Collide);
            for (var i = hits.Length - 1; i >= 0; i--)
            {
                var hit = hits[i];
                var enemy = hit.transform.GetComponent<IEnemy>();
                enemy?.Damage(_damage);
            }
        }

        private void StartRecharging()
        {
            _currentShootState = ShootState.Reload;
            _timer = _rechargeAttackTime;
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position + transform.forward * _attackSphereCenter.x + transform.up * _attackSphereCenter.y, _attackSphereRadius);
        }
#endif
    }
}