using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FlappyBird {
    public class Player : MonoBehaviour {
        //속도 계산을 위한 RigidBody
        private Rigidbody2D rb2d;
        //오브젝트의 점프력
        [SerializeField] private float jumpForce;
        //속도 조절
        float minSpeed = -10f;
        float maxSpeed = 7f;
        float rightSpeed = 3f;
        //점프 상태 점검; 너무 짧은 시간 내에 반복적으로 점프하는 것을 막기 위함
        private bool jumpCheck = false;
        public float jumpInterval = 0.1f; // 점프 간격
        //물체 회전
        Vector3 rotation = new Vector3(0, 0, 0);
        float maxposrotation = 30;
        float minposrotation = -90;
        [SerializeField] private float rotationSpeed = 30f; // 회전 속도

        //회귀지점
        [SerializeField] Transform recursionPoint;

        void Start() {
            rb2d = GetComponent<Rigidbody2D>();
            rotation = transform.eulerAngles;
            Do_Jump();
        }

        void Update() {
            if (GameManager.IsReady == false) {
                //회전을 고정하고 제자리 점프하게 만들기
                if (transform.position.y < 0) rb2d.linearVelocityY += jumpForce;
                SpeedSetting();
                CheckInput();
                return;
            }

            MoveRight();
            CheckInput();
            SpeedSetting();

            //방향에 따라 회전
            RotateByPos(rb2d.linearVelocity);

            //디버그 : 낙하 방지
            //Debug_DontFall();
        }

        private void MoveRight() {
            transform.Translate(Vector2.right * rightSpeed * Time.deltaTime, Space.World);
        }

        void SpeedSetting() {
            //낙하 속도 조절
            if (rb2d.linearVelocityY < minSpeed || rb2d.linearVelocityY > maxSpeed) {
                rb2d.linearVelocityY = Mathf.Clamp(rb2d.linearVelocity.y, minSpeed, maxSpeed);
            }
        }

        void BackToStart() {
            //회귀지점 도달 시 x = 0으로 되돌아가기
            if (transform.position.x > recursionPoint.position.x) {
                transform.position = new Vector3(0f, transform.position.y, transform.position.z);
            }
        }

        void Debug_DontFall() {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }

        //입력 받기와 실제 물리 연산을 분리
        private void FixedUpdate() {
            if (jumpCheck) {
                jumpCheck = false;
                Do_Jump();
            }
        }

        void CheckInput() {
            //게임 준비 단계에서 스페이 스 바 혹은 마우스 클릭 시 게임 시작
            if (!GameManager.IsReady) {
                GameManager.IsReady |= Input.GetKeyDown(KeyCode.Space);
                GameManager.IsReady |= Input.GetKeyDown(KeyCode.Mouse0);
            }
            //스페이스 바나 마우스 클릭 시 점프
            jumpCheck |= Input.GetKeyDown(KeyCode.Space);
            jumpCheck |= Input.GetKeyDown(KeyCode.Mouse0);
        }
        void Do_Jump() {
            // 점프 높이만큼 위쪽 방향으로 이동하는 속도를 추가
            rb2d.linearVelocity += Vector2.up * jumpForce;
            //너무 짧은 시간 안에 점프를 많이 하는 것을 방지하기 위해 0.1초(기본)의 간격 설정
            //yield return new WaitForSeconds(jumpInterval);
        }

        //점프 시 - 낙하 시에 따라 회전
        void RotateByPos(Vector2 velocity) {
            float direction = velocity.y > 0 ? 1 : -1;
            float targetRotZ = rotation.z;
            // 점프 시 Z축을 기준으로 회전
            if (direction < 0) {
                targetRotZ = Mathf.Clamp(rotation.z + direction * rotationSpeed, minposrotation, maxposrotation);
            }
            else {
                targetRotZ = Mathf.Clamp(rotation.z + direction * rotationSpeed * 2, minposrotation, maxposrotation);
            }

            rotation.z = Mathf.LerpAngle(rotation.z, targetRotZ, Time.deltaTime * 10f);
            transform.rotation = Quaternion.Euler(rotation);
        }

    }

}
