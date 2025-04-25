using UnityEngine;
using UnityEngine.UIElements;

namespace FlappyBird {
    public class BackGround : MonoBehaviour {
        [SerializeField] float moveSpeed = 2f; // 배경 이동 속도
        [SerializeField] float length; //배경 길이 (단수)
        [SerializeField] float totalLength; //배경 길이 (전체)
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            // 배경을 왼쪽으로 이동
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (transform.position.x < -1 * (totalLength / 2 - length / 2)) {
                float new_x = totalLength / 2 - length / 2;
                transform.position = new Vector3(new_x, transform.position.y, transform.position.z);
            }
        }
    }

}
