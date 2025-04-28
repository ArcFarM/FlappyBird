using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;
    static bool isReady = false;
    void Awake()
    {
        if(instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public static bool IsReady {
        get { return isReady; }
        set { isReady = value; }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
