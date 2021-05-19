using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int click; //개구리알_스페이스바 연타시 증가

    void Start()
    {
        click = 0;
    }

    void Update()
    {
        // 개구리 알일 때
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //스페이스바
            {
                click++;
            }
            if (click >= 100)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().step = 1;
                Evolution();
            }
        }
    }

    public void Evolution() //개구리 진화
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 1)
        {
            GetComponent<Animator>().SetInteger("step", 1);
        }
    }
}
