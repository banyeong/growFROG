using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int click; //개구리알 클릭
    public Camera MainCamera;

    void Start()
    {
        

        click = 0;
    }

    void Update()
    {
        // 개구리 알일 때
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                click++;
            }
        }
    }
}
