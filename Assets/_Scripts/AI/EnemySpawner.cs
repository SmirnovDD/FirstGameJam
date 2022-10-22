using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.AI
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemySpawnPoint> _spawnPoints = new List<EnemySpawnPoint>();
        [SerializeField] private bool _active;
        
        public void Init(Player.Player player)
        {
            if (!_active)
                return;
            
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
