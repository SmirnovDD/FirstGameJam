using _Scripts.General;
using UnityEngine;

namespace _Scripts.Player
{
    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField] private Transform _cameraFollowRoot;
        public Transform CameraFollowRoot => _cameraFollowRoot;
        
        [SerializeField] private Health _health;

        public void Damage(float damage)
        {
            _health.Current -= damage;
        }
    }
}
