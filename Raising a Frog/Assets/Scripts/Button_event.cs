using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text MainText;
    public Text MiniText;
    public Text OK_Text;
    // --------------------------------

    private bool isAVT = false;
    private bool isTRAIN = false;
    private float avt_time = 0f;
    private float train_time = 0f;

    private int random_Num;

    private void Update()
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

    // *     모험 클릭     *
    public void Adventure_Click()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

            MainText.text = "성장 2단계일 때 모험을 떠날 수 있어!";
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

        GoADV_BTN.SetActive(false);
        Close_BTN.SetActive(false);
        OK_BTN.SetActive(true);

        isAVT = true;
        random_Num = Random.Range(0, 7);

        OK_Text.text = "확인";
        MiniText.text = "";

        // 모험 실패 0
        if (random_Num == 0 || random_Num > 5)
        {
            MainText.text = "모험 실패... 모든 능력 15 감소 ㅜㅁㅜ";

            gameManager.charm -= 15;
            gameManager.intell -= 15;
            gameManager.wealth -= 15;
            gameManager.inqMind -= 15;

            gameManager.Stat_MIN();
        }
        // 모험 대성공
        else if (random_Num == 5)
        {
            MainText.text = "모험 대성공! 모든 능력 10 증가!!";

            gameManager.charm += 10;
            gameManager.intell += 10;
            gameManager.wealth += 10;
            gameManager.inqMind += 10;
        }
        // 모험 성공
        else
        {
            if (random_Num == 1)
            {
                MainText.text = "모험 성공! 매력 10 증가!";
                gameManager.charm += 10;
            }
            else if (random_Num == 2)
            {
                MainText.text = "모험 성공! 지능 10 증가!";
                gameManager.intell += 10;
            }
            else if (random_Num == 3)
            {
                MainText.text = "모험 성공! 재력 10 증가!";
                gameManager.wealth += 10;
            }
            else if (random_Num == 4)
            {
                MainText.text = "모험 성공! 탐구심 10 증가!";
                gameManager.inqMind += 10;
            }
        }
    }
    // *     특훈 클릭     *
    public void Training_Click()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (gameManager.step < 2)
        {
            gameManager.isPopUpON = true;

            PopUp_StatUp.SetActive(true);
            OK_BTN.SetActive(true);
            GoADV_BTN.SetActive(false);
            GoTRAIN_BTN.SetActive(false);
            Close_BTN.SetActive(false);
            Block_Button.SetActive(true);

            MainText.text = "성장 3단계일 때 특훈을 할 수 있어!";
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

                MainText.text = "특훈 성공 시 능력 대폭 상승!";
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

        GoTRAIN_BTN.SetActive(false);
        Close_BTN.SetActive(false);
        OK_BTN.SetActive(true);

        isTRAIN = true;
        random_Num = Random.Range(0, 3);

        OK_Text.text = "확인";
        MiniText.text = "";

        // 특훈 실패
        if (random_Num == 0)
        {
            MainText.text = "특훈 실패... 모든 능력 25 감소 ㅜㅁㅜ";

            gameManager.charm -= 25;
            gameManager.intell -= 25;
            gameManager.wealth -= 25;
            gameManager.inqMind -= 25;
        }
        else // 특훈 성공
        {
            MainText.text = "특훈 성공! 모든 능력 30 증가!";

            gameManager.charm += 30;
            gameManager.intell += 30;
            gameManager.wealth += 30;
            gameManager.inqMind += 30;
        }
    }

    // *    닫기     *
    public void Close_PopUp()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.isPopUpON = false;
        Block_Button.SetActive(false);
        PopUp_StatUp.SetActive(false);
        OK_BTN.SetActive(false);
    }
}
