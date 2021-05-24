using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    void Start()
    {
        // ���� �� 3�ʰ� ������ ����
        Destroy(gameObject, 3f);
    }

    // collider�� �ִ� �ٸ� ������Ʈ�� �浹�ϴ� ����
    void OnTriggerStay2D(Collider2D other)
    {
        // �±װ� "Player"�̰� �����̽��ٸ� �����ٸ�
        if(other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

                GameObject.Find("Player").GetComponent<Player>().isEating = true;
                // ���� ���� ���� ����
                gameManager.feedCount++;
                // ���� ����
                gameManager.charm += 1;
                gameManager.intell += 1;
                gameManager.wealth += 1;
                gameManager.inqMind += 1;
                // ��� ����
                Destroy(gameObject, 0f);
            }
        }
    }

    void Update()
    {

    }
}
