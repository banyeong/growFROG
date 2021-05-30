using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    // * �ؽ�Ʈ *
    public GameObject text_obj;
    public Text endText;
    private string m_text = "7�ܰԡ� �츮�� ��ȭ��Ų ��ì�̴�\n����� �����Ͽ� �������� �Ǿ���!";

    // * ����ī�� ���� ���� *
    private const int standard = 620; // ����ī�� ���� ����
    public int endNum = 0; // ����ī�� ����

    // * ����ī�� ������Ʈ *
    public GameObject lonely_1;
    public GameObject enjoy_2;
    public GameObject attract_3;
    public GameObject teacher_4;
    public GameObject explorer_5;
    public GameObject money_6;
    public GameObject idol_7;

    public GameObject BTN;

    IEnumerator coroutine; bool endCoroutine = false;
    void Start()
    {
        Check_End();

        coroutine = _typing();
        StartCoroutine(_typing());
    }

    void Update()
    {
        if (endCoroutine == true)
        {
            StopCoroutine(coroutine);
            text_obj.SetActive(false);
            BTN.SetActive(true);
            show_EndingCard();
        }
    }
    
    // * Ÿ���� ȿ�� *
    IEnumerator _typing()
    {
        yield return new WaitForSeconds(1f);
        // * ù ��° Ÿ���� *
        for (int i = 0; i <= m_text.Length; i++)
        {
            endText.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.12f);
        }

        yield return new WaitForSeconds(1.5f);

        // * �� ��° Ÿ���� *
        m_text = "�츮�� Ű�� �������� �������";
        for (int i = 0; i <= m_text.Length; i++)
        {
            endText.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.12f);
        }

        yield return new WaitForSeconds(1.5f);

        endCoroutine = true;
    }

    // * ����ī�� ���� Ȯ�� *
    void Check_End()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        int statSUM = gameManager.charm + gameManager.intell + gameManager.inqMind + gameManager.wealth;

        if (statSUM < standard) // (1_���� ������)
        {
            endNum = 1;
        }
        else if (statSUM >= standard && statSUM < 730) // (2_��ſ� ������)
        {
            endNum = 2;
        }
        else
        {
            if (gameManager.charm >= 180 && gameManager.intell >= 180
                && gameManager.inqMind >= 180 && gameManager.wealth >= 180) // (7_���̵� ������)
            {
                endNum = 7;
            }
            else if (gameManager.charm >= 180) endNum = 3; // (3_��Ȥ���� ������)
            else if (gameManager.intell >= 180) endNum = 4; // (4_���� ������)
            else if (gameManager.inqMind >= 180) endNum = 5; // (5_Ž�谡 ������)
            else if (gameManager.wealth >= 180) endNum = 6; // (6_��� ������)
        }
    }

    // * ����ī�� ���� *
    void show_EndingCard()
    {
        if (endNum == 1) lonely_1.SetActive(true);
        else if (endNum == 2) enjoy_2.SetActive(true);
        else if (endNum == 3) attract_3.SetActive(true);
        else if (endNum == 4) teacher_4.SetActive(true);
        else if (endNum == 5) explorer_5.SetActive(true);
        else if (endNum == 6) money_6.SetActive(true);
        else if (endNum == 7) idol_7.SetActive(true);
    }
}
