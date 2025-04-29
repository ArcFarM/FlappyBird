using System.Collections;
using UnityEngine;

namespace FlappyBird {
    public class Obstacle : MonoBehaviour {

        [SerializeField] bool isPillar = true;
        [SerializeField] float timer = 5f;

        private void Start() {
            if (isPillar) {
                StartCoroutine(SelfDestroy());
            }
        }

        IEnumerator SelfDestroy() {
            yield return new WaitForSeconds(timer); // Wait for 5 seconds before destroying the object
            Destroy(gameObject); // Destroy the obstacle
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("Player")) {
                GameManager.Instance.GameOver();
            }
        }
    }
}
