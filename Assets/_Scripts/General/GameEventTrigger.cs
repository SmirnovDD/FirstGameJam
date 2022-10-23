using _Scripts.AI;
using UnityEngine;

namespace _Scripts.General
{
    public class GameEventTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _postProcessing;
        [SerializeField] private float _duration;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private DoorAnimation _doorAnimation;
        [SerializeField] private ParticleSystem _bossAppearanceParticles;
        
        private bool _triggered;
        private float _timer;
        private Player.Player _player;
        private bool _initialized;
        public void Init(Player.Player player)
        {
            _player = player;
            _initialized = true;
        }
    
        private void OnTriggerStay(Collider other)
        {
            if (_triggered || !_initialized)
                return;
            
            _timer = _duration;
            _triggered = true;
        
            if (_postProcessing != null)
                _postProcessing.SetActive(true);
            if (_audioSource != null)
                _audioSource.Play();
            if (_enemySpawner != null)
                _enemySpawner.Init(_player);
            if (_doorAnimation)
                _doorAnimation.Trigger();
            if (_bossAppearanceParticles)
                _bossAppearanceParticles.gameObject.SetActive(true);
        }

        private void Update()
        {
            if (!_triggered)
                return;

            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                if (_postProcessing != null)
                    _postProcessing.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
