using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // *      ĳ���� ����       *
    public int charm; //�ŷ�
    public int intell; //����
    public int wealth; //���
    public int inqMind; //Ž����

    public int step; //���� �ܰ�
                     // 0: �������� / 1: ��ì�� / 2: ��ì�� �޴ٸ� / 3: ��ì�� �մٸ�
                     // 4: ����ª����

    public int feedCount;

    // *     �ؽ�Ʈ     *
    public Text stat_Text; //���� �ؽ�Ʈ
    public Text step_Text; //���� �ؽ�Ʈ

    void Start()
    {
        // * ���� ����� ��� ���� 0���� �ʱ�ȭ *
        charm = 0;
        intell = 0;
        wealth = 0;
        inqMind = 0;
        step = 0;

        feedCount = 0;

        stat_Text.text = "1�ܰ�\n��������";
    }

    void Update()
    {
        // *     ���� ��ġ �ؽ�Ʈ ����     *
        stat_Text.text = "�ŷ� " + charm + "\n\n" + "���� " + intell + "\n\n" + "��� " + wealth
                        + "\n\n" + "Ž���� " + inqMind;
    }
}