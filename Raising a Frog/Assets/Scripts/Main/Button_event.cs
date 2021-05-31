using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_event : MonoBehaviour
{
    // *     인스펙터 관리     *
    // -------------------------------
    public GameObject PopUp_StatUp;
    public GameObject GoADV_BTN;
    public GameObject GoTRAIN_BTN;
    public GameObject Close_BTN;
    public GameObject OK_BTN;
    public GameObject Block_Button; // 팝업창 실행 시 다른 버튼 클릭을 막기 위해

    public GameObject SpaceBar_PopUp; //스페이스바를 연타해주세요!안내창

    public Text MainText;
    public Text MiniText;
    public Text OK_Text;
    // --------------------------------

    public AudioClip audioBTN;
    public AudioClip audioSuccess;
    public AudioClip audioFailure;
    AudioSource audioSource;

    // --------------------------------

    private bool isAVT = false;
    private bool isTRAIN = false;
    private float avt_time = 0f;
    private float train_time = 0f;

    private int random_Num;

    private void Start()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step > 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().spaceON = true;
        }
    }

    private void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().spaceON == false)
        {
            SpaceBar_PopUp.SetActive(true);
            Block_Button.SetActive(true);

            GameObject.Find("GameManager").GetComponent<GameManager>().space_time += Time.deltaTime;

            if (GameObject.Find("GameManager").GetComponent<GameManager>().space_time >= 2f)
            {
                SpaceBar_PopUp.SetActive(false);
                GameObject.Find("GameManager").GetComponent<GameManager>().spaceON = true;
                Block_Button.SetActive(false);
            }
        }
        else
        {
            // *     모험을 시작했는가?     *
            if (isAVT == true)
            {
                avt_time += Time.deltaTime;
                if (avt_time >= 7)
                {
                    avt_time = 0;
                    isAVT = false;
                }
            }
            // *     특훈을 시작했는가?     *
            if (isTRAIN == true)
            {
                train_time += Time.deltaTime;
                if (train_time >= 10)
                {
                    train_time = 0;
                    isTRAIN = false;
                }
            }
        }
    }

    // *     모험 클릭     *
    public void Adventure_Click()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject.Find("Player").GetComponent<Player>().PlaySound("BTN");
        // 개구리알이라면 기능 X
        if (gameManager.step == 0)
        {
            gameManager.isPopUpON = true;

            Block_Button.SetActive(true);
            PopUp_StatUp.SetActive(true);
            OK_BTN.SetActive(true);
            GoADV_BTN.SetActive(false);
            GoTRAIN_BTN.SetActive(false);
            Close_BTN.SetActive(false);

            MainText.text = "성장 2단계 이후부터 모험을 떠날 수 있어!";
            MiniText.text = "";
            OK_Text.text = "알겠어!";
        }
        else
        {
            gameManager.isPopUpON = true;

            // 팝업창도 보이고 실행기능도 보임
            PopUp_StatUp.SetActive(true);
            Block_Button.SetActive(true);

            // 모험 time이 0이라면 실행
            if (isAVT == false)
            {
                GoADV_BTN.SetActive(true);
                Close_BTN.SetActive(true);
                GoTRAIN_BTN.SetActive(false);

                MainText.text = "모험 성공 시 능력 상승!";
                MiniText.text = "단, 실패 시 능력 하락 ㅜ.ㅜ";
            }
            else // 0 이상이라면 실행 X
            {
                OK_BTN.SetActive(true);

                MainText.text = 7 - (int)avt_time + "초 후에 떠날 수 있어!";
                MiniText.text = "";
                OK_Text.text = "알겠어!";
            }
        }
    }
    // *     모험을 떠나자     *
    public void Go_Adventure()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Player player = GameObject.Find("Player").GetComponent<Player>();

        GoADV_BTN.SetActive(false);
        Close_BTN.SetActive(false);
        OK_BTN.SetActive(true);

        isAVT = true;
        random_Num = Random.Range(0, 10);

        OK_Text.text = "확인";
        MiniText.text = "";

        // 모험 실패 0
        if (random_Num == 0)
        {
            player.PlaySound("FAILURE");
            MainText.text = "모험 실패... 모든 능력 15 감소 ㅜㅁㅜ";

            gameManager.charm -= 15;
            gameManager.intell -= 15;
            gameManager.wealth -= 15;
            gameManager.inqMind -= 15;

            gameManager.Stat_MIN();
        }
        // 모험 대성공
        else if (random_Num == 9)
        {
            player.PlaySound("SUCCESS");
            MainText.text = "모험 대성공! 모든 능력 20 증가!!";

            gameManager.charm += 20;
            gameManager.intell += 20;
            gameManager.wealth += 20;
            gameManager.inqMind += 20;
        }
        // 모험 성공
        else
        {
            if (random_Num == 1)
            {
                player.PlaySound("SUCCESS");
                MainText.text = "모험 성공! 매력 20 증가!";
                gameManager.charm += 20;
            }
            else if (random_Num == 2)
            {
                player.PlaySound("FAILURE");
                MainText.text = "모험 실패! 매력 15 감소...";
                gameManager.charm -= 15;
                gameManager.Stat_MIN();
            }
            else if (random_Num == 3)
            {
                player.PlaySound("SUCCESS");
                MainText.text = "모험 성공! 지능 20 증가!";
                gameManager.intell += 20;
            }
            else if (random_Num == 4)
            {
                player.PlaySound("FAILURE");
                MainText.text = "모험 실패! 지능 15 감소...";
                gameManager.intell -= 15;
                gameManager.Stat_MIN();
            }
            else if (random_Num == 5)
            {
                player.PlaySound("SUCCESS");
                MainText.text = "모험 성공! 재력 20 증가!";
                gameManager.wealth += 20;
            }
            else if (random_Num == 6)
            {
                player.PlaySound("FAILURE");
                MainText.text = "모험 실패! 재력 15 감소...";
                gameManager.wealth -= 15;
                gameManager.Stat_MIN();
            }
            else if (random_Num == 7)
            {
                player.PlaySound("SUCCESS");
                MainText.text = "모험 성공! 탐구심 20 증가!";
                gameManager.inqMind += 20;
            }
            else if (random_Num == 8)
            {
                player.PlaySound("FAILURE");
                MainText.text = "모험 실패! 탐구심 15 감소...";
                gameManager.inqMind -= 15;
                gameManager.Stat_MIN();
            }
        }
    }
    // *     특훈 클릭     *
    public void Training_Click()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject.Find("Player").GetComponent<Player>().PlaySound("BTN");

        if (gameManager.step < 2)
        {
            gameManager.isPopUpON = true;

            PopUp_StatUp.SetActive(true);
            OK_BTN.SetActive(true);
            GoADV_BTN.SetActive(false);
            GoTRAIN_BTN.SetActive(false);
            Close_BTN.SetActive(false);
            Block_Button.SetActive(true);

            MainText.text = "성장 3단계 이후부터 특훈을 할 수 있어!";
            MiniText.text = "";
            OK_Text.text = "알겠어!";
        }
        else
        {
            gameManager.isPopUpON = true;

            // 팝업창도 보이고 실행기능도 보임
            PopUp_StatUp.SetActive(true);
            Block_Button.SetActive(true);

            // 특훈 time이 0이라면 실행
            if (isTRAIN == false)
            {
                GoTRAIN_BTN.SetActive(true);
                Close_BTN.SetActive(true);
                GoADV_BTN.SetActive(false);

                MainText.text = "특훈 성공 시 모든 능력 대폭 상승!";
                MiniText.text = "단, 실패 시 능력 하락 ㅜ.ㅜ";
            }
            else // 0 이상이라면 실행 X
            {
                OK_BTN.SetActive(true);

                MainText.text = 10 - (int)train_time + "초 후에 떠날 수 있어!";
                MiniText.text = "";
                OK_Text.text = "알겠어!";
            }
        }
    }
    // *     특훈을 떠나자     *
    public void Go_TRAINING()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Player player = GameObject.Find("Player").GetComponent<Player>();

        GoTRAIN_BTN.SetActive(false);
        Close_BTN.SetActive(false);
        OK_BTN.SetActive(true);

        isTRAIN = true;
        random_Num = Random.Range(0, 2);

        OK_Text.text = "확인";
        MiniText.text = "";

        // 특훈 실패
        if (random_Num == 0)
        {
            player.PlaySound("FAILURE");
            MainText.text = "특훈 실패... 모든 능력 25 감소 ㅜㅁㅜ";

            gameManager.charm -= 25;
            gameManager.intell -= 25;
            gameManager.wealth -= 25;
            gameManager.inqMind -= 25;
        }
        else // 특훈 성공
        {
            player.PlaySound("SUCCESS");
            MainText.text = "특훈 성공! 모든 능력 40 증가!";

            gameManager.charm += 40;
            gameManager.intell += 40;
            gameManager.wealth += 40;
            gameManager.inqMind += 40;
        }
    }

    // *    닫기     *
    public void Close_PopUp()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject.Find("Player").GetComponent<Player>().PlaySound("BTN");
        gameManager.isPopUpON = false;
        Block_Button.SetActive(false);
        PopUp_StatUp.SetActive(false);
        OK_BTN.SetActive(false);
    }

    // *    게임 종료    *
    public void Exit_Game()
    {
        GameObject.Find("Player").GetComponent<Player>().PlaySound("BTN");
#if UNITY_EDITOR //에디터일때
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    // *    저장하기     *
    public void Save()
    {
        GameObject.Find("Player").GetComponent<Player>().PlaySound("BTN");
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        PlayerPrefs.SetInt("charm", gameManager.charm);
        PlayerPrefs.SetInt("intell", gameManager.intell);
        PlayerPrefs.SetInt("inqMind", gameManager.inqMind);
        PlayerPrefs.SetInt("wealth", gameManager.wealth);
        PlayerPrefs.SetInt("step", gameManager.step);
        PlayerPrefs.SetInt("feedCount", gameManager.feedCount);
        PlayerPrefs.SetInt("ani_step", GameObject.Find("Player").GetComponent<Player>().GetComponent<Animator>().GetInteger("step"));
    }
}