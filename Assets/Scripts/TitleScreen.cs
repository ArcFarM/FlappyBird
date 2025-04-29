using UnityEngine;

namespace FlappyBird {
    public class TitleScreen : MonoBehaviour {

        [SerializeField] FadeCanvas fadePanel;

        private void Start() {
            fadePanel.gameObject.SetActive(true);
        }

        public void OnPlayButtonPressed() {
            StartCoroutine(fadePanel.Do_FadeOut("PlayScene"));
        }

        public void OnExitButtonPressed() {
            StartCoroutine(fadePanel.Do_FadeOut(""));
        }
    }
}
