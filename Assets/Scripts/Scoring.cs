using TMPro;
using UnityEngine;

namespace FlappyBird {
    public class Scoring : MonoBehaviour {

        [SerializeField] TextMeshProUGUI scoreObject;
        [SerializeField] TextMeshProUGUI highScoreObject; // Prefab for the score text
        static TextMeshProUGUI scoreText;
        static TextMeshProUGUI highScoreText;

        static bool highScoreCheck = false;
        float timer = 0f;
        float changeTime = 2f; //색상변경주기

        private void Awake() {
            scoreText = scoreObject;
            highScoreText = highScoreObject;
        }

        void Start() {
            highScoreText.gameObject.SetActive(false);
        }

        public static void SettingScore() {
            // 점수 업데이트
            scoreText.text = GameManager.Score.ToString();
        }

        public static void BestScoreEffect() {
            //최고 점수 갱신 시 무지개빛으로 빛나는 highScoreText 표시
            highScoreText.gameObject.SetActive(true);

            highScoreCheck = true;
        }

        private void Update() {
            if (highScoreCheck) {
                // 점수 텍스트의 색상을 무지개색으로 변경
                if (timer < changeTime) {
                    timer += Time.deltaTime;
                    float hue = Mathf.PingPong(timer / changeTime, 1f);
                    highScoreText.color = Color.HSVToRGB(hue, 1, 1);
                }
                else timer = 0f;
            }
        }
    }

}
