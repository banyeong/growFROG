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

    // *     �˾��� �����ִ��� ���� üũ     *
    public bool isPopUpON;
    
    // * �����̽��� �ȳ�â *
    public float space_time = 0f;
    public bool spaceON = false;

    // �ε带 �޴ٸ� true
    public bool is_Load = false;
    public bool blockStat = false; //�ε� �� ���� ������ ���� ���ؼ�

    void Start()
    {
        // * ���� ����� ��� ���� 0���� �ʱ�ȭ *
        charm = 0;
        intell = 0;
        wealth = 0;
        inqMind = 0;
        step = 0;

        feedCount = 0;
        isPopUpON = false;
    }

    private void Awake()
    {
        // ���� �Ŵ����� �ı��Ǹ� X
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }

    // *    ������ 0 ������ �������� �ʵ���     *
    public void Stat_MIN()
    {
        if (charm <= 0) charm = 0;
        if (intell <= 0) intell = 0;
        if (wealth <= 0) wealth = 0;
        if (inqMind <= 0) inqMind = 0;
    }
}