using UnityEngine;

namespace FlappyBird {
    public class ScoreZone : MonoBehaviour {
        //점수 획득
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag("Player")) {

                GameManager.Score++;
                //점수 획득 사운드 재생
                GetComponent<AudioSource>().Play();
                Scoring.SettingScore();

                if (GameManager.Score > GameManager.HighScore) {
                    Scoring.BestScoreEffect();
                }
            }
        }
    }

}
