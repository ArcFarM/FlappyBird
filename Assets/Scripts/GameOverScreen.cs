using TMPro;
using UnityEngine;

namespace FlappyBird {
    public class GameOverScreen : MonoBehaviour {

        [SerializeField] TextMeshProUGUI curr_score;
        [SerializeField] TextMeshProUGUI best_score;
        [SerializeField] TextMeshProUGUI new_best;
        [SerializeField] FadeCanvas fadePanel;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            curr_score.text = GameManager.Score.ToString();
            best_score.text = GameManager.HighScore.ToString();

            new_best.gameObject.SetActive(false);
            if (GameManager.Score > GameManager.HighScore) {
                //점수 갱신 연출
                float scoreAnimTime = 1.5f;
                float timer = 0f;
                while(timer < scoreAnimTime) {
                    timer+= Time.deltaTime;
                    curr_score.text = Mathf.Lerp(GameManager.HighScore, GameManager.Score, timer / scoreAnimTime).ToString("F0");
                }
                //점수 정보 갱신
                GameManager.Instance.UpdateScore();
                new_best.gameObject.SetActive(true);
            }
        }

        public void RetryButton() {
            //게임 재시작
            StartCoroutine(fadePanel.Do_FadeOut("PlayScene"));
        }

        public void ExitButton() {
            //메인으로 되돌아가기
            StartCoroutine(fadePanel.Do_FadeOut("TitleScene"));
        }


    }

}
