using System.Collections;
using UnityEngine;

namespace FlappyBird {
    public class ObstacleSpawn : MonoBehaviour {

        [SerializeField] GameObject obstaclePrefab; // Prefab for the obstacle
        [SerializeField] float spawnInterval = 2f; // Time interval between spawns
        [SerializeField] float minInterval = 1f; // Minimum X position for spawning
        [SerializeField] float minY = -4f; // Minimum Y position for spawning
        [SerializeField] float maxY = 4f; // Maximum Y position for spawning
        float timer = 0;
        float distance = 5f;
        public Transform playerPos;

        void Start() {

        }

        void Update() {
            timer += Time.deltaTime;
            if(timer > spawnInterval && playerPos.position.y > -50f) {
                timer = 0;
                SpawnObstacle();
            }
        }

        void SpawnObstacle() {
            if (!GameManager.Instance.IsReady) return;
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(playerPos.position.x + distance, randomY, 0);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }

        void MoreDifficult() {
            if(GameManager.Score % 10 == 0 && spawnInterval > minInterval) {
                distance *= 1.05f;
                spawnInterval = Mathf.Max(minInterval, spawnInterval*0.95f);
            }
        }
    }
}
