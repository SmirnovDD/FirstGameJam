using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.AI
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPointsRoot;
        [SerializeField] private bool _active;
        private EnemySpawnPoint[] _spawnPoints;
        
        public void Init(Player.Player player)
        {
            if (!_active)
                return;

            _spawnPoints = _spawnPointsRoot.GetComponentsInChildren<EnemySpawnPoint>();
            foreach (var spawnPoint in _spawnPoints)
            {
                var spawnPointTransform = spawnPoint.transform;
                var enemy = Instantiate(spawnPoint.EnemyPrefab, spawnPointTransform.position, spawnPointTransform.rotation);
                enemy.Init(player);
                var destinationSetter = enemy.GetComponent<DestinationSetter>();
                if (destinationSetter != null)
                    destinationSetter.Init(player.transform);
            }
        }
    }
}
