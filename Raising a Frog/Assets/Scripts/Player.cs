using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int click; //��������_�����̽��� ��Ÿ�� ����

    void Start()
    {
        click = 0;
    }

    void Update()
    {
        // ������ ���� ��
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //�����̽���
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

    public void Evolution() //������ ��ȭ
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 1)
        {
            GetComponent<Animator>().SetInteger("step", 1);
        }
    }
}
