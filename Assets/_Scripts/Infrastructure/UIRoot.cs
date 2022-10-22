using System;
using _Scripts.General;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Infrastructure
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private Image _playerHealthBar;
        private PlayerHealth _playerHealth;
        private bool _initialized;

        public void Init(Player.Player player)
        {
            _playerHealth = player.GetComponent<PlayerHealth>();
            _initialized = true;
        }

        private void Update()
        {
            if (!_initialized)
                return;

            _playerHealthBar.fillAmount = _playerHealth.Current / _playerHealth.Initial;
        }
    }
}