using UnityEngine;

namespace _Scripts.AI
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        public Enemy EnemyPrefab => _enemyPrefab;
    }
}