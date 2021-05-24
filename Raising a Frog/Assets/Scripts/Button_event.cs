using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_event : MonoBehaviour
{
    // *     �ν����� ����     *
    // -------------------------------
    public GameObject PopUp_StatUp;
    public GameObject GoADV_BTN;
    public GameObject GoTRAIN_BTN;
    public GameObject Close_BTN;
    public GameObject OK_BTN;
    public GameObject Block_Button; // �˾�â ���� �� �ٸ� ��ư Ŭ���� ���� ����

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
        // *     ������ �����ߴ°�?     *
        if (isAVT == true)
        {
            avt_time += Time.deltaTime;
            if (avt_time >= 7)
            {
                avt_time = 0;
                isAVT = false;
            }
        }
        // *     Ư���� �����ߴ°�?     *
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

    // *     ���� Ŭ��     *
    public void Adventure_Click()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // ���������̶�� ��� X
        if (gameManager.step == 0)
        {
            gameManager.isPopUpON = true;

            Block_Button.SetActive(true);
            PopUp_StatUp.SetActive(true);
            OK_BTN.SetActive(true);
            GoADV_BTN.SetActive(false);
            GoTRAIN_BTN.SetActive(false);
            Close_BTN.SetActive(false);

            MainText.text = "���� 2�ܰ��� �� ������ ���� �� �־�!";
            MiniText.text = "";
            OK_Text.text = "�˰ھ�!";
        }
        else
        {
            gameManager.isPopUpON = true;

            // �˾�â�� ���̰� �����ɵ� ����
            PopUp_StatUp.SetActive(true);
            Block_Button.SetActive(true);

            // ���� time�� 0�̶�� ����
            if (isAVT == false)
            {
                GoADV_BTN.SetActive(true);
                Close_BTN.SetActive(true);
                GoTRAIN_BTN.SetActive(false);

                MainText.text = "���� ���� �� �ɷ� ���!";
                MiniText.text = "��, ���� �� �ɷ� �϶� ��.��";
            }
            else // 0 �̻��̶�� ���� X
            {
                OK_BTN.SetActive(true);

                MainText.text = 7 - (int)avt_time + "�� �Ŀ� ���� �� �־�!";
                MiniText.text = "";
                OK_Text.text = "�˰ھ�!";
            }
        }
    }
    // *     ������ ������     *
    public void Go_Adventure()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        GoADV_BTN.SetActive(false);
        Close_BTN.SetActive(false);
        OK_BTN.SetActive(true);

        isAVT = true;
        random_Num = Random.Range(0, 7);

        OK_Text.text = "Ȯ��";
        MiniText.text = "";

        // ���� ���� 0
        if (random_Num == 0 || random_Num > 5)
        {
            MainText.text = "���� ����... ��� �ɷ� 15 ���� �̤���";

            gameManager.charm -= 15;
            gameManager.intell -= 15;
            gameManager.wealth -= 15;
            gameManager.inqMind -= 15;

            gameManager.Stat_MIN();
        }
        // ���� �뼺��
        else if (random_Num == 5)
        {
            MainText.text = "���� �뼺��! ��� �ɷ� 10 ����!!";

            gameManager.charm += 10;
            gameManager.intell += 10;
            gameManager.wealth += 10;
            gameManager.inqMind += 10;
        }
        // ���� ����
        else
        {
            if (random_Num == 1)
            {
                MainText.text = "���� ����! �ŷ� 10 ����!";
                gameManager.charm += 10;
            }
            else if (random_Num == 2)
            {
                MainText.text = "���� ����! ���� 10 ����!";
                gameManager.intell += 10;
            }
            else if (random_Num == 3)
            {
                MainText.text = "���� ����! ��� 10 ����!";
                gameManager.wealth += 10;
            }
            else if (random_Num == 4)
            {
                MainText.text = "���� ����! Ž���� 10 ����!";
                gameManager.inqMind += 10;
            }
        }
    }
    // *     Ư�� Ŭ��     *
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

            MainText.text = "���� 3�ܰ��� �� Ư���� �� �� �־�!";
            MiniText.text = "";
            OK_Text.text = "�˰ھ�!";
        }
        else
        {
            gameManager.isPopUpON = true;

            // �˾�â�� ���̰� �����ɵ� ����
            PopUp_StatUp.SetActive(true);
            Block_Button.SetActive(true);

            // Ư�� time�� 0�̶�� ����
            if (isTRAIN == false)
            {
                GoTRAIN_BTN.SetActive(true);
                Close_BTN.SetActive(true);
                GoADV_BTN.SetActive(false);

                MainText.text = "Ư�� ���� �� �ɷ� ���� ���!";
                MiniText.text = "��, ���� �� �ɷ� �϶� ��.��";
            }
            else // 0 �̻��̶�� ���� X
            {
                OK_BTN.SetActive(true);

                MainText.text = 10 - (int)train_time + "�� �Ŀ� ���� �� �־�!";
                MiniText.text = "";
                OK_Text.text = "�˰ھ�!";
            }
        }
    }
    // *     Ư���� ������     *
    public void Go_TRAINING()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        GoTRAIN_BTN.SetActive(false);
        Close_BTN.SetActive(false);
        OK_BTN.SetActive(true);

        isTRAIN = true;
        random_Num = Random.Range(0, 3);

        OK_Text.text = "Ȯ��";
        MiniText.text = "";

        // Ư�� ����
        if (random_Num == 0)
        {
            MainText.text = "Ư�� ����... ��� �ɷ� 25 ���� �̤���";

            gameManager.charm -= 25;
            gameManager.intell -= 25;
            gameManager.wealth -= 25;
            gameManager.inqMind -= 25;
        }
        else // Ư�� ����
        {
            MainText.text = "Ư�� ����! ��� �ɷ� 30 ����!";

            gameManager.charm += 30;
            gameManager.intell += 30;
            gameManager.wealth += 30;
            gameManager.inqMind += 30;
        }
    }

    // *    �ݱ�     *
    public void Close_PopUp()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.isPopUpON = false;
        Block_Button.SetActive(false);
        PopUp_StatUp.SetActive(false);
        OK_BTN.SetActive(false);
    }
}
