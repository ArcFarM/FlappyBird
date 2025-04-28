using UnityEngine;

namespace FlappyBird {
    public class CameraControl : MonoBehaviour {
        [SerializeField] float moveSpeed = 3f; // 카메라 이동 속도

        public Transform playerPos;

        private void Start() {
            transform.position = new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z - 10f);
        }

        void Update() {
            // 카메라를 플레이어 위치에 맞추기
            transform.position = new Vector3(playerPos.position.x, transform.position.y, transform.position.z);
        }
    }
}