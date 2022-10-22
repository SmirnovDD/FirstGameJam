using _Scripts.General;
using UnityEngine;

namespace _Scripts.AI
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private Health _health;
        private AnimationsController _animationsController;
        private Player.Player _player;
        public Player.Player Player => _player;
        public Transform PlayerTransform { get; private set; }
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
            _animationsController.PlayHitAnimation();
        }
    }
}