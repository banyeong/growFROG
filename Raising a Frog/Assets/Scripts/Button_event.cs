using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_event : MonoBehaviour
{
    public GameObject PopUp_StatUp;

    // *     ����     *
    public void Adventure_Click()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager.step == 0)
        {
            Debug.Log("2�ܰ� ��ì�̺��� ������ ����Դϴ�!");
        }
        else
        {
            PopUp_StatUp.SetActive(true);
        }
    }
    // *     Ư��     *
    public void Training_Click()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager.step < 2)
        {
            Debug.Log("3�ܰ� ��ì�̺��� ������ ����Դϴ�!");
        }
    }
}
