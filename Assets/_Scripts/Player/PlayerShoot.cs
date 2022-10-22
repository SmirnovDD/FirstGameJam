using _Scripts.General;
using StarterAssets;
using UnityEngine;

namespace _Scripts.Player
{
    public enum ShootState
    {
        Ready,
        Reload
    }

    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private float _reloadTime = 1f;
        [SerializeField] private BallisticMotion _projectilePrefab;
        [SerializeField] private float _shootForce;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private StarterAssetsInputs _inputs;
        
        private Player _player;
        private PlayerAmmunitionController _playerAmmunitionController;
        private ShootState _currentShootState = ShootState.Ready;
        private float _timer;
        private AmmunitionType _relatedAmmunitionType = AmmunitionType.Crossbow;
        private AnimationsController _animationsController;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _playerAmmunitionController = GetComponent<PlayerAmmunitionController>();
            _animationsController = GetComponent<AnimationsController>();
        }

        void Update()
        {
            if (_playerAmmunitionController.ChosenAmmunition.Type != _relatedAmmunitionType)
                return;
            
            if (_inputs.Attack && _currentShootState == ShootState.Ready)
            {
                Shoot();
                StartReloading();
                _animationsController.PlayShootAnimation();
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

        private void Shoot()
        {
            var shootPoint = _shootPoint.position;
            var forward = _player.CameraFollowRoot.forward;
            var projectile = Instantiate(_projectilePrefab, shootPoint, Quaternion.LookRotation(forward));
            projectile.Initialize(shootPoint, Physics.gravity.y);
            projectile.AddImpulse(forward * _shootForce);
        }

        private void StartReloading()
        {
            _currentShootState = ShootState.Reload;
            _timer = _reloadTime;
        }
    }
}
