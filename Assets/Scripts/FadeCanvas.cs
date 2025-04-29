using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyBird {
    public class FadeCanvas : MonoBehaviour {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            GetComponent<CanvasGroup>().alpha = 1f;
            StartCoroutine(Do_FadeIn());
        }

        [SerializeField] float fadeTime = 1.5f;

        public IEnumerator Do_FadeIn() {
            float timer = 0f;
            CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
            while (timer < fadeTime) {
                timer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / fadeTime);
                yield return null;
            }
        }

        public IEnumerator Do_FadeOut(string scene) {
            Debug.Log("FadeOut");
            float timer = 0f;
            CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
            while (timer < fadeTime) {
                timer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeTime);
                yield return null;
            }
            if(scene != "")
            SceneManager.LoadScene(scene);
            else Application.Quit();
        }
    }

}
