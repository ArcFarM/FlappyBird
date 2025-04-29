using UnityEngine;
using UnityEngine.UIElements;

namespace FlappyBird {
    public class BackGround : MonoBehaviour {
        [SerializeField] float moveSpeed = 5f; // 배경 이동 속도
        [SerializeField] Transform recursionPoint; // 배경 회귀 지점
        public Transform playerPos;
        public Transform groundPos;
        float groundResetTimer = 5f;
        float nowTimer = 0f;
        float initialXPos; // 초기 X 위치
        // Update is called once per frame

        private void Start() {
            initialXPos = transform.position.x; // 초기 X 위치 저장
            moveSpeed = initialXPos * 2 / groundResetTimer;
        }

        void Update() {
            nowTimer += Time.deltaTime;
            if (!GameManager.Instance.IsReady) return;
            if(GameManager.Instance.IsDead) return;
            MoveBackGround();
        }

        void MoveBackGround() {
            // 배경을 플레이어와 동기화
            transform.position = new Vector3(playerPos.position.x, transform.position.y, transform.position.z);
            groundPos.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);

            if (nowTimer >= groundResetTimer) {
                nowTimer = 0f;
                groundPos.position = new Vector3(playerPos.position.x + initialXPos, groundPos.position.y, groundPos.position.z);
            }
        }
    }

}
