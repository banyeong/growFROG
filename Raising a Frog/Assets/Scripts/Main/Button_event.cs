using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public GameObject SpaceBar_PopUp; //�����̽��ٸ� ��Ÿ���ּ���!�ȳ�â

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

            if (GameObject.Find("GameManager").GetComponent<GameManager>().space_time >= 2.5f)
            {
                SpaceBar_PopUp.SetActive(false);
                GameObject.Find("GameManager").GetComponent<GameManager>().spaceON = true;
                Block_Button.SetActive(false);
            }
        }
        else
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
    }

    // *     ���� Ŭ��     *
    public void Adventure_Click()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject.Find("Player").GetComponent<Player>().PlaySound("BTN");
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

            MainText.text = "���� 2�ܰ� ���ĺ��� ������ ���� �� �־�!";
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
        SoundManager soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        GoADV_BTN.SetActive(false);
        Close_BTN.SetActive(false);
        OK_BTN.SetActive(true);

        isAVT = true;
        random_Num = Random.Range(0, 10);

        OK_Text.text = "Ȯ��";
        MiniText.text = "";

        // ���� ���� 0
        if (random_Num == 0)
        {
            soundManager.ExtraSound("FAILURE");
            MainText.text = "���� ����... ��� �ɷ� 15 ���� �̤���";

            gameManager.charm -= 15;
            gameManager.intell -= 15;
            gameManager.wealth -= 15;
            gameManager.inqMind -= 15;

            gameManager.Stat_MIN();
        }
        // ���� �뼺��
        else if (random_Num == 9)
        {
            soundManager.ExtraSound("SUCCESS");
            MainText.text = "���� �뼺��! ��� �ɷ� 20 ����!!";

            gameManager.charm += 20;
            gameManager.intell += 20;
            gameManager.wealth += 20;
            gameManager.inqMind += 20;
        }
        // ���� ����
        else
        {
            if (random_Num == 1)
            {
                soundManager.ExtraSound("SUCCESS");
                MainText.text = "���� ����! �ŷ� 20 ����!";
                gameManager.charm += 20;
            }
            else if (random_Num == 2)
            {
                soundManager.ExtraSound("FAILURE");
                MainText.text = "���� ����! �ŷ� 15 ����...";
                gameManager.charm -= 15;
                gameManager.Stat_MIN();
            }
            else if (random_Num == 3)
            {
                soundManager.ExtraSound("SUCCESS");
                MainText.text = "���� ����! ���� 20 ����!";
                gameManager.intell += 20;
            }
            else if (random_Num == 4)
            {
                soundManager.ExtraSound("FAILURE");
                MainText.text = "���� ����! ���� 15 ����...";
                gameManager.intell -= 15;
                gameManager.Stat_MIN();
            }
            else if (random_Num == 5)
            {
                soundManager.ExtraSound("SUCCESS");
                MainText.text = "���� ����! ��� 20 ����!";
                gameManager.wealth += 20;
            }
            else if (random_Num == 6)
            {
                soundManager.ExtraSound("FAILURE");
                MainText.text = "���� ����! ��� 15 ����...";
                gameManager.wealth -= 15;
                gameManager.Stat_MIN();
            }
            else if (random_Num == 7)
            {
                soundManager.ExtraSound("SUCCESS");
                MainText.text = "���� ����! Ž���� 20 ����!";
                gameManager.inqMind += 20;
            }
            else if (random_Num == 8)
            {
                soundManager.ExtraSound("FAILURE");
                MainText.text = "���� ����! Ž���� 15 ����...";
                gameManager.inqMind -= 15;
                gameManager.Stat_MIN();
            }
        }
    }
    // *     Ư�� Ŭ��     *
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

            MainText.text = "���� 3�ܰ� ���ĺ��� Ư���� �� �� �־�!";
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

                MainText.text = "Ư�� ���� �� ��� �ɷ� ���� ���!";
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
        SoundManager soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        GoTRAIN_BTN.SetActive(false);
        Close_BTN.SetActive(false);
        OK_BTN.SetActive(true);

        isTRAIN = true;
        random_Num = Random.Range(0, 2);

        OK_Text.text = "Ȯ��";
        MiniText.text = "";

        // Ư�� ����
        if (random_Num == 0)
        {
            soundManager.ExtraSound("FAILURE");
            MainText.text = "Ư�� ����... ��� �ɷ� 25 ���� �̤���";

            gameManager.charm -= 25;
            gameManager.intell -= 25;
            gameManager.wealth -= 25;
            gameManager.inqMind -= 25;
        }
        else // Ư�� ����
        {
            soundManager.ExtraSound("SUCCESS");
            MainText.text = "Ư�� ����! ��� �ɷ� 40 ����!";

            gameManager.charm += 40;
            gameManager.intell += 40;
            gameManager.wealth += 40;
            gameManager.inqMind += 40;
        }
    }

    // *    �ݱ�     *
    public void Close_PopUp()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject.Find("Player").GetComponent<Player>().PlaySound("BTN");
        gameManager.isPopUpON = false;
        Block_Button.SetActive(false);
        PopUp_StatUp.SetActive(false);
        OK_BTN.SetActive(false);
    }

    // *    ���� ����    *
    public void Exit_Game()
    {
        GameObject.Find("Player").GetComponent<Player>().PlaySound("BTN");
#if UNITY_EDITOR //�������϶�
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    // *    �����ϱ�     *
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