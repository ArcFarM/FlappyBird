using UnityEngine;
using UnityEngine.UIElements;

namespace FlappyBird {
    public class BackGround : MonoBehaviour {
        [SerializeField] float moveSpeed = 5f; // 배경 이동 속도
        [SerializeField] Transform recursionPoint; // 배경 회귀 지점
        public Transform playerPos;
        public Transform groundPos;
        // Update is called once per frame
        void Update() {
            if (!GameManager.IsReady) return;
            MoveBackGround();
        }

        void MoveBackGround() {
            // 배경을 플레이어와 동기화
            transform.position = new Vector3(playerPos.position.x, transform.position.y, transform.position.z);
            groundPos.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);

            if (groundPos.position.x <= recursionPoint.position.x * -1)
                groundPos.position = new Vector3(recursionPoint.position.x, groundPos.position.y, groundPos.position.z);
        }
    }

}
