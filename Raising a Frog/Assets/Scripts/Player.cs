using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BoxCollider2D playerCollider;

    [SerializeField] //인스펙터 창에 보이기 하기 위함
    private int click; //개구리알_스페이스바 연타시 증가

    public Rigidbody2D playerRigidbody; //플레이어 리지드바디
    public float speed = 8f;

    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        playerRigidbody = GetComponent<Rigidbody2D>();
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
                //step을 1로 만듦
                GameObject.Find("GameManager").GetComponent<GameManager>().step++;
                Evolution();
            }
        }
        else
        {
            float xInput = Input.GetAxis("Horizontal");
            float yInput = Input.GetAxis("Vertical");

            float xSpeed = xInput * speed;
            float ySpeed = yInput * speed;

            Vector2 newVelocity = new Vector2(xSpeed, ySpeed);
            //Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

            playerRigidbody.velocity = newVelocity;
        }
    }

    // *     개구리 진화     *
    public void Evolution()
    {
        //막 부화한 올챙이라면
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 1)
        {
            GetComponent<Animator>().SetInteger("step", 1); //애니메이터 변수 step 1로 바꿈
            playerCollider.size = new Vector3(2.7f, 1.516f, 1f); //콜라이더 사이즈 변경
        }
    }
}
