using System;
using _Scripts.General;
using UnityEngine;

namespace _Scripts.AI
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private Health _health;
        [SerializeField] private bool _spawnFinalBoss;
        private AnimationsController _animationsController;
        private Player.Player _player;
        public Player.Player Player => _player;
        public Transform PlayerTransform { get; private set; }
        public static event Action<Transform> SpawnFinalBoss;
        
        private void Awake()
        {
            _animationsController = GetComponent<AnimationsController>();
        }

        public void Init(Player.Player player)
        {
            _player = player;
            PlayerTransform = player.transform;
        }
        
        public void Damage(float damage)
        {
            _health.Current -= damage;
            if (_animationsController)
                _animationsController.PlayHitAnimation();
        }

        private void OnDestroy()
        {
            if (_spawnFinalBoss)
                SpawnFinalBoss?.Invoke(transform);
        }
    }
}