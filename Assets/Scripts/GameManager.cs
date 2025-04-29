using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;
    //게임 시작/종료 변수
    bool isReady = false;
    bool isDead = false;
    //디버그 : 최고기록 초기화 치트
    [SerializeField] bool resetFlag = false;
    [SerializeField] Button resetButton;
    //TODO : 게임 진행 정도에 따라 플레이어 속도 증가, 장애물 소환 간격 단축
    static float SpeedMultiplier = 1f;
    static int score = 0;
    static int highScore = 0;

    static public float Speed {
        get { return SpeedMultiplier; }
        set { SpeedMultiplier = value; }
    }

    static public int Score {
        get { return score; }
        set { score = value; }
    }

    static public int HighScore {
        get { return highScore; }
        set { highScore = value; }
    }

    //타이틀화면, 시작화면, 종료 화면
    [SerializeField] GameObject readyScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject scoreScreen;
    //플레이어
    [SerializeField] GameObject player;
    void Awake()
    {
        if(instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;

        if (!resetFlag) {
            resetButton.gameObject.SetActive(false);
        } else {
            resetButton.GetComponent<Button>().onClick.AddListener(ResetData);
        }

        StartGame();
    }

    public static GameManager Instance {
        get { return instance; }
    }

    public bool IsReady {
        get { return isReady; }
        set { isReady = value; }
    }

    public bool IsDead {
        get { return isDead; }
    }
    // Update is called once per frame
    void Start()
    {
        //다른 팝업 비활성화
        readyScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        scoreScreen.SetActive(false);
        player.SetActive(true);

        //현재 최고 점수 등록
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void StartGame() {
        //게임 시작
        scoreScreen.SetActive(true);
    }

    public void GameOver() {
        // 게임 오버 처리
        Debug.Log("Game Over");
        isDead = true;
        // 게임 오버 화면 팝업
        gameOverScreen.SetActive(true);
    }

    //최고 점수 갱신
    public void UpdateScore() {
        if(score > highScore) {
            highScore = score;
        }
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    void ResetData() {
        if (resetFlag) {
            PlayerPrefs.DeleteKey("HighScore");
            resetFlag = false;
            resetButton.gameObject.SetActive(false);
        }
    }
}
