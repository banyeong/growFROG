using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        // * ���� ����� ��� ���� 0���� �ʱ�ȭ *
        charm = 0;
        intell = 0;
        wealth = 0;
        inqMind = 0;
        step = 0;

        feedCount = 0;
    }

    void Update()
    {
        
    }
}