using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    // * 텍스트 *
    public GameObject text_obj;
    public Text endText;
    private string m_text = "7단계… 우리가 부화시킨 올챙이는\n충분히 성장하여 개구리가 되었다!";

    // * 엔딩카드 관련 변수 *
    private const int standard = 600; // 엔딩카드 기준 숫자
    public int endNum = 0; // 엔딩카드 숫자

    // * 엔딩카드 오브젝트 *
    public GameObject lonely_1;
    public GameObject enjoy_2;
    public GameObject attract_3;
    public GameObject teacher_4;
    public GameObject explorer_5;
    public GameObject money_6;
    public GameObject idol_7;

    public GameObject BTN;

    // * 오디오 관리 *
    bool isAudio = false;
    public AudioClip audioBase;
    public AudioClip audioLonely;
    public AudioClip audioSuccess;
    public AudioClip audioIdol;
    AudioSource audioSource;

    // 엔딩카드 조건 배열
    int[] endArr = new int[4];
    int i = 0;

    IEnumerator coroutine; bool endCoroutine = false;
    void Start()
    {
        EndPlaySound("BASE");
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        endArr[0] = gameManager.charm;
        endArr[1] = gameManager.intell;
        endArr[2] = gameManager.inqMind;
        endArr[3] = gameManager.wealth;

        Check_End();

        coroutine = _typing();
        StartCoroutine(_typing());
    }
    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (endCoroutine == true)
        {
            StopCoroutine(coroutine);
            text_obj.SetActive(false);
            BTN.SetActive(true);

            if (isAudio == false)
            {
                show_EndingCard();
                isAudio = true;
            }
            init_stat();
        }
    }

    // * 타이핑 효과 *
    IEnumerator _typing()
    {
        yield return new WaitForSeconds(0.5f);
        // * 첫 번째 타이핑 *
        for (int i = 0; i <= m_text.Length; i++)
        {
            endText.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.12f);
        }

        yield return new WaitForSeconds(1.5f);

        // * 두 번째 타이핑 *
        m_text = "우리가 키운 개구리의 모습은…";
        for (int i = 0; i <= m_text.Length; i++)
        {
            endText.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.12f);
        }

        yield return new WaitForSeconds(1.5f);

        endCoroutine = true;
    }

    // * 엔딩카드 조건 확인 *
    void Check_End()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        int statSUM = gameManager.charm + gameManager.intell + gameManager.inqMind + gameManager.wealth;

        if (statSUM < standard) // (1_고독한 개구리)
        {
            endNum = 1;
        }
        else if (statSUM >= standard && statSUM < 670) // (2_즐거운 개구리)
        {
            endNum = 2;
        }
        else
        {
            if (gameManager.charm >= 300 && gameManager.intell >= 300
                && gameManager.inqMind >= 300 && gameManager.wealth >= 300) // (7_아이돌 개구리)
            {
                endNum = 7;
            }
            else
            {
                int highNum = 0, check = 3;
                for (i = 0; i < 4; i++)
                {
                    if (highNum < endArr[i])
                    {
                        highNum = endArr[i];
                        check = i;
                    }
                }
                if (check == 0) endNum = 3; // (3_매혹적인 개구리)
                else if (check == 1) endNum = 4; // (4_교사 개구리)
                else if (check == 2) endNum = 5; // (5_탐험가 개구리)
                else if (check == 3) endNum = 6; // (6_재벌 개구리)
            }

        }
    }

    // * 엔딩카드 띄우기 *
    void show_EndingCard()
    {
        if (endNum == 1)
        {
            EndPlaySound("LONELY");
            lonely_1.SetActive(true);
        }
        else
        {
            if (endNum == 7)
            {
                EndPlaySound("IDOL");
                idol_7.SetActive(true);
            }
            else
            {
                EndPlaySound("SUCCESS");
                if (endNum == 2) enjoy_2.SetActive(true);
                else if (endNum == 3) attract_3.SetActive(true);
                else if (endNum == 4) teacher_4.SetActive(true);
                else if (endNum == 5) explorer_5.SetActive(true);
                else if (endNum == 6) money_6.SetActive(true);
            }
        }

    }

    // 게임 매니저에 있는 모든 변수 0으로 초기화
    void init_stat()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        gameManager.step = 0;
        gameManager.feedCount = 0;

        gameManager.charm = 0;
        gameManager.intell = 0;
        gameManager.inqMind = 0;
        gameManager.wealth = 0;
    }

    void EndPlaySound(string sound)
    {
        switch (sound)
        {
            case "BASE":
                audioSource.clip = audioBase;
                break;
            case "LONELY":
                audioSource.clip = audioLonely;
                break;
            case "SUCCESS":
                audioSource.clip = audioSuccess;
                break;
            case "IDOL":
                audioSource.clip = audioIdol;
                break;
        }
        audioSource.Play();
    }
}
