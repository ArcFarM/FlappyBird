using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ChangeBackGround : MonoBehaviour
{
    //1. 낮 배경의 투명도가 1인 경우
    //매초 밤 배경의 투명도가 1씩 감소 (alpha + 1)
    //매초 낮 배경의 투명도가 1씩 증가 (alpha - 1)

    //2. 밤 배경의 투명도가 1인 경우
    //매초 낮 배경의 투명도가 1씩 감소 (alpha + 1)
    //매초 밤 배경의 투명도가 1씩 증가 (alpha - 1)

    //3. 1 상태에서 매초 Player의 조명 투명도 1씩 감소, 2 상태에서 매초 조명 투명도 1씩 증가

    [SerializeField] GameObject nightBackground;
    SpriteRenderer sr;

    [SerializeField] GameObject player;
    SpriteRenderer playerSr;


    private void Start() {
        sr = nightBackground.GetComponent<SpriteRenderer>();
        playerSr = player.GetComponent<SpriteRenderer>();

        StartCoroutine(DaytoNight());
    }

    IEnumerator DaytoNight() {
        Debug.Log("DaytoNight");
        //게임 종료 시 중지
        while(GameManager.Instance.IsDead || !GameManager.Instance.IsReady) {
            yield return null;
        }
        //밤 배경을 불투명하게 하기
        float new_alpha = sr.color.a + (5 / 255f);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, new_alpha);
        yield return new WaitForSeconds(1f);
        //완전한 밤이 됐으면
        if(sr.color.a >= 1) StartCoroutine(NighttoDay());
        else StartCoroutine(DaytoNight());
    }

    IEnumerator NighttoDay() {
        Debug.Log("NighttoDay");
        while (GameManager.Instance.IsDead || !GameManager.Instance.IsReady) {
            yield return null;
        }
        //밤 배경을 투명하게 하기
        float new_alpha = sr.color.a - (5 / 255f);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, new_alpha);
        yield return new WaitForSeconds(1f);
        //완전한 낮이 됐으면
        if (sr.color.a <= 0) StartCoroutine(DaytoNight());
        else StartCoroutine(NighttoDay());
    }

}
