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

    // 먹이를 먹고 있는지, 수영하는 중인지 체크 for 애니메이션
    public bool isEating = false;
    private bool isSwimming = true;

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
                //step을 1로 만듦 -> 부화
                GameObject.Find("GameManager").GetComponent<GameManager>().step++;
                Evolution();
            }
        }
        else
        {
            // *     먹이를 섭취했을 때 애니메이션 변경
            if (isEating == true)
            {
                isSwimming = false;
                GetComponent<Animator>().SetBool("isEating", true);

                if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    isEating = false;
                    isSwimming = true;
                }
            }
            else
            {
                GetComponent<Animator>().SetBool("isEating", false);
            }

            // *     팝업이 닫혀있을 때만 움직임     *
            if (GameObject.Find("GameManager").GetComponent<GameManager>().isPopUpON == false)
            {
                Player_Move();
            }
            else
            {
                Vector2 newVelocity = new Vector2(0, 0);
                playerRigidbody.velocity = newVelocity;
            }
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
        if (isSwimming == true)
        {
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                GetComponent<Animator>().SetBool("isSwimming", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("isSwimming", false);
            }
        }
    }

    // *     개구리 진화     *
    public void Evolution()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //2, 막 부화한 올챙이로 변경
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 1)
        {
            GetComponent<Animator>().SetInteger("step", 1); //애니메이터 변수 step 1로 바꿈
            playerCollider.size = new Vector2(1.9f, 1f); //콜라이더 사이즈 변경
            gameManager.step_Text.text = "2단계\n올챙이";

            // *     스탯 10씩 증가     *
            gameManager.charm += 10;
            gameManager.intell += 10;
            gameManager.wealth += 10;
            gameManager.inqMind += 10;
        }
        //3, 뒷다리가 나온 올챙이로 변경
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 2)
        {
            GetComponent<Animator>().SetInteger("step", 2);
            speed = 10f;
            gameManager.feedCount = 0;
            gameManager.step_Text.text = "3단계\n올챙이";

            // *     스탯 10씩 증가     *
            gameManager.charm += 10;
            gameManager.intell += 10;
            gameManager.wealth += 10;
            gameManager.inqMind += 10;
        }
        //4, 앞다리가 나온 올챙이로 변경
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 3)
        {
            GetComponent<Animator>().SetInteger("step", 3); //애니메이터 변수 step 3로 바꿈
            speed = 11f;
            playerCollider.size = new Vector2(2.2f, 1.133697f); //콜라이더 사이즈 변경
            gameManager.feedCount = 0;
            gameManager.step_Text.text = "4단계\n올챙이";

            // *     스탯 10씩 증가     *
            gameManager.charm += 10;
            gameManager.intell += 10;
            gameManager.wealth += 10;
            gameManager.inqMind += 10;
        }
        //5, 꼬리 짧은 개구리로 변경
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 4)
        {
            GetComponent<Animator>().SetInteger("step", 4); //애니메이터 변수 step 4로 바꿈
            playerCollider.size = new Vector2(2.163661f, 1.344424f); //콜라이더 사이즈 변경
            gameManager.feedCount = 0;
            gameManager.step_Text.text = "5단계\n개구리";

            // *     스탯 15씩 감소     *
            gameManager.charm += 10;
            gameManager.intell += 10;
            gameManager.wealth += 10;
            gameManager.inqMind += 10;
        }
        //6-1, 돌연변이 개구리로 변경
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 5)
        {
            GetComponent<Animator>().SetInteger("step", 5); //애니메이터 변수 step 5로 바꿈
            gameManager.feedCount = 0;
            gameManager.step_Text.text = "돌연변이\n개구리";

            // *     스탯 10씩 증가     *
            gameManager.charm -= 15;
            gameManager.intell -= 15;
            gameManager.wealth -= 15;
            gameManager.inqMind -= 15;

            gameManager.Stat_MIN();
        }
        //6-2, 정상 개구리로 변경
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 6)
        {
            GetComponent<Animator>().SetInteger("step", 6); //애니메이터 변수 step 6로 바꿈
            gameManager.feedCount = 0;
            gameManager.step_Text.text = "개구리";

            // *     스탯 10씩 증가     *
            gameManager.charm += 10;
            gameManager.intell += 10;
            gameManager.wealth += 10;
            gameManager.inqMind += 10;
        }
    }
}
