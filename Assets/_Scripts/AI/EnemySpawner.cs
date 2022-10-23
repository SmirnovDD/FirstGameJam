using System;
using System.Collections.Generic;
using _Scripts.General;
using _Scripts.Infrastructure;
using UnityEngine;

namespace _Scripts.AI
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPointsRoot;
        [SerializeField] private bool _active;
        [SerializeField] private UIRoot _uiRoot;
        
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
                if (_uiRoot != null)
                {
                    _uiRoot.SetBossHealth(enemy.GetComponent<Health>());
                }
            }
        }
    }
}
