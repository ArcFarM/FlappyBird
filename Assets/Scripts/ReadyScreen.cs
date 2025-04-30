using UnityEngine;

namespace FlappyBird {
    
    public class ReadyScreen : MonoBehaviour {

        [SerializeField] GameObject readyText;
        bool blinkSwitch = false;
        // Update is called once per frame
        private void Start() {
            //점수 초기화
            GameManager.Score = 0;
            TextBlink();
        }
        void Update() {
            if(GameManager.instance.IsReady) {
                // 게임 시작
                GameManager.Instance.StartGame();
            }
            else if(!blinkSwitch) {
                blinkSwitch = true;
                TextBlink();
            }
        }

        void TextBlink() {
            // Tap to Start 문구 점멸
            
            readyText.GetComponent<CanvasGroup>().alpha = Mathf.PingPong(Time.time, 1f);
            blinkSwitch = false;
        }
    }
}