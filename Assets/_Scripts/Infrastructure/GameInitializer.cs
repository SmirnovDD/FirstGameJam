using _Scripts.AI;
using Cinemachine;
using UnityEngine;

namespace _Scripts.Infrastructure
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private UIRoot _uiRoot;
        [SerializeField] private Player.Player _playerPrefab;
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private EnemySpawner _enemySpawner;
        
        void Start()
        {
            var player = SpawnPlayer();
            SpawnPlayerCamera(player);
            SpawnEnemies(player);
            InitUI(player);
        }

        private void InitUI(Player.Player player)
        {
            _uiRoot.Init(player);
        }

        private void SpawnEnemies(Player.Player player)
        {
            if (_enemySpawner != null)
                _enemySpawner.Init(player);
        }

        private void SpawnPlayerCamera(Player.Player player)
        {
            var cinemachineVirtualCamera = Instantiate(_cinemachineVirtualCamera);
            cinemachineVirtualCamera.Follow = player.CameraFollowRoot;
        }

        private Player.Player SpawnPlayer() => Instantiate(_playerPrefab, _playerSpawnPoint.position, _playerSpawnPoint.rotation);
    
        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(hasFocus);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}
