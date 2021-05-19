using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // *      캐릭터 스탯       *
    private int charm; //매력
    private int intell; //지능
    private int wealth; //재력
    private int inqMind; //탐구심
    
    // *      캐릭터 성장       *
    private int step; //성장 단계

    void Start()
    {
        // * 게임 실행시 모든 스탯 0으로 초기화 *
        charm = 0;
        intell = 0;
        wealth = 0;
        inqMind = 0;
    }

    void Update()
    {
        
    }
}
