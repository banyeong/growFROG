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

    // *     텍스트     *
    public Text stat_Text; //스탯 텍스트
    public Text step_Text; //성장 텍스트

    void Start()
    {
        // * 게임 실행시 모든 스탯 0으로 초기화 *
        charm = 0;
        intell = 0;
        wealth = 0;
        inqMind = 0;
        step = 0;

        feedCount = 0;

        stat_Text.text = "1단계\n개구리알";
    }

    void Update()
    {
        // *     스탯 수치 텍스트 변경     *
        stat_Text.text = "매력 " + charm + "\n\n" + "지능 " + intell + "\n\n" + "재력 " + wealth
                        + "\n\n" + "탐구심 " + inqMind;
    }
}