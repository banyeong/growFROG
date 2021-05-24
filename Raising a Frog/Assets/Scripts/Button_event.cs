using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_event : MonoBehaviour
{
    public GameObject PopUp_StatUp;

    // *     모험     *
    public void Adventure_Click()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager.step == 0)
        {
            Debug.Log("2단계 올챙이부터 가능한 기능입니다!");
        }
        else
        {
            PopUp_StatUp.SetActive(true);
        }
    }
    // *     특훈     *
    public void Training_Click()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager.step < 2)
        {
            Debug.Log("3단계 올챙이부터 가능한 기능입니다!");
        }
    }
}
