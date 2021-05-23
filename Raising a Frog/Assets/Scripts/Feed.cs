using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    void Start()
    {
        // 생성 후 3초가 지나면 삭제
        Destroy(gameObject, 3f);
    }

    // collider가 있는 다른 오브젝트와 충돌하는 동안
    void OnTriggerStay2D(Collider2D other)
    {
        // 태그가 "Player"이고 스페이스바를 눌렀다면
        if(other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // 먹은 먹이 개수 증가
                GameObject.Find("GameManager").GetComponent<GameManager>().feedCount++;
                // 즉시 삭제
                Destroy(gameObject, 0f);
            }
        }
    }

    void Update()
    {

    }
}
