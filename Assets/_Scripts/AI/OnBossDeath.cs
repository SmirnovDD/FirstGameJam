using UnityEngine;

namespace _Scripts.AI
{
    public class OnBossDeath : MonoBehaviour
    {
        [SerializeField] private Transform _spawner;
        [SerializeField] private GameObject _trigger;
        [SerializeField] private GameObject _particles;
        private Transform _playerTransform;

        public void Init(Player.Player player)
        {
            _playerTransform = player.transform;
            Enemy.SpawnFinalBoss += GO;
        }

        private void GO(Transform targetTransform)
        {
            _spawner.position = targetTransform.position;
            _particles.transform.position = targetTransform.position;
            _particles.SetActive(true);
            _trigger.transform.position = _playerTransform.position;
        }
    }
}