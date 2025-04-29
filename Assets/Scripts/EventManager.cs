using UnityEngine;

namespace FlappyBird {
    public class EventManager : MonoBehaviour {
        //싱글톤 인스턴스

        private static EventManager instance;
        public static EventManager Instance { get { return instance; } }

        private void Awake() {
            if(instance == null) {
                instance = this;
            }
            else {
                Destroy(gameObject);
            }
        }

        //GameManager의 Score 점수 변동이 생겼을 때 업데이트하는 이벤트

    }
}