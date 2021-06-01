using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // *      캐릭터 스탯       *
    public int charm; //매력
    public int intell; //지능
    public int wealth; //재력
    public int inqMind; //탐구심

    public int step; //성장 단계
                     // 0: 개구리알 / 1: 올챙이 / 2: 올챙이 뒷다리 / 3: 올챙이 앞다리
                     // 4: 꼬리짧아짐

    public int feedCount;

    // *     팝업이 열려있는지 상태 체크     *
    public bool isPopUpON;
    
    // * 스페이스바 안내창 *
    public float space_time = 0f;
    public bool spaceON = false;

    // 로드를 햇다면 true
    public bool is_Load = false;
    public bool blockStat = false; //로드 시 스탯 증가를 막기 위해서

    void Start()
    {
        // * 게임 실행시 모든 스탯 0으로 초기화 *
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
        // 게임 매니저는 파괴되면 X
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }

    // *    스탯이 0 밑으로 내려가지 않도록     *
    public void Stat_MIN()
    {
        if (charm <= 0) charm = 0;
        if (intell <= 0) intell = 0;
        if (wealth <= 0) wealth = 0;
        if (inqMind <= 0) inqMind = 0;
    }
}