using _Scripts.General;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Infrastructure
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private Image _playerHealthBar;
        [SerializeField] private Image _bossHealthBar;
        
        private PlayerHealth _playerHealth;
        private bool _initialized;
        private Health _bossHealth;

        public void Init(Player.Player player)
        {
            _playerHealth = player.GetComponent<PlayerHealth>();
            _initialized = true;
        }

        public void SetBossHealth(Health health)
        {
            _bossHealth = health;
            _bossHealthBar.enabled = true;
        }
        
        private void Update()
        {
            if (!_initialized)
                return;

            if (_playerHealth != null)
                _playerHealthBar.fillAmount = _playerHealth.Current / _playerHealth.Initial;
            if (_bossHealth != null)
                _bossHealthBar.fillAmount = _bossHealth.Current / _bossHealth.Initial;
            else
            {
                _bossHealthBar.enabled = false;
            }
                
        }
    }
}