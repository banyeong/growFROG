using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BoxCollider2D playerCollider;

    [SerializeField] //인스펙터 창에 보이기 하기 위함
    private int spaceBar; //개구리알_스페이스바 연타시 증가

    public Rigidbody2D playerRigidbody; //플레이어 리지드바디
    public float speed = 8f;

    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        spaceBar = 0;
    }

    void Update()
    {
        // 개구리 알일 때
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //스페이스바
            {
                spaceBar++;
            }
            if (spaceBar >= 50)
            {
                //step을 1로 만듦
                GameObject.Find("GameManager").GetComponent<GameManager>().step++;
                Evolution();
            }
        }
        else
        {
            Player_Move();
        }
    }

    // *     움직임 함수     *
    void Player_Move()
    {
        // *       움직임 구현        *
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);

        playerRigidbody.velocity = newVelocity;

        // *     방향 전환     *
        if (xInput < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (xInput > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        // *      헤엄치는 중인가?      *
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            GetComponent<Animator>().SetBool("isSwimming", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isSwimming", false);
        }
    }

    // *     개구리 진화     *
    public void Evolution()
    {
        //2, 막 부화한 올챙이로 변경
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 1)
        {
            GetComponent<Animator>().SetInteger("step", 1); //애니메이터 변수 step 1로 바꿈
            playerCollider.size = new Vector3(2.7f, 1.516f, 1f); //콜라이더 사이즈 변경

            // *     스탯 10씩 증가     *
            GameObject.Find("GameManager").GetComponent<GameManager>().charm += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().intell += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().wealth += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().inqMind += 10;
        }
        //3, 뒷다리가 나온 올챙이로 변경
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 2)
        {
            GetComponent<Animator>().SetInteger("step", 2);
            speed = 10f;
            GameObject.Find("GameManager").GetComponent<GameManager>().feedCount = 0;

            // *     스탯 10씩 증가     *
            GameObject.Find("GameManager").GetComponent<GameManager>().charm += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().intell += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().wealth += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().inqMind += 10;
        }
        //4, 앞다리가 나온 올챙이로 변경
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 3)
        {
            GetComponent<Animator>().SetInteger("step", 3); //애니메이터 변수 step 3로 바꿈
            speed = 11f;
            playerCollider.size = new Vector3(3.723f, 1.646f, 1f); //콜라이더 사이즈 변경
            GameObject.Find("GameManager").GetComponent<GameManager>().feedCount = 0;

            // *     스탯 10씩 증가     *
            GameObject.Find("GameManager").GetComponent<GameManager>().charm += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().intell += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().wealth += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().inqMind += 10;
        }
        //5, 꼬리 짧은 개구리로 변경
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 4)
        {
            GetComponent<Animator>().SetInteger("step", 4); //애니메이터 변수 step 4로 바꿈
            playerCollider.size = new Vector3(3.402719f, 1.952039f, 1f); //콜라이더 사이즈 변경
            GameObject.Find("GameManager").GetComponent<GameManager>().feedCount = 0;

            // *     스탯 10씩 증가     *
            GameObject.Find("GameManager").GetComponent<GameManager>().charm += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().intell += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().wealth += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().inqMind += 10;
        }
    }
}
