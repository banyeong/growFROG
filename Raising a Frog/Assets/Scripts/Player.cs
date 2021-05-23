using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BoxCollider2D playerCollider;

    [SerializeField] //�ν����� â�� ���̱� �ϱ� ����
    private int spaceBar; //��������_�����̽��� ��Ÿ�� ����

    public Rigidbody2D playerRigidbody; //�÷��̾� ������ٵ�
    public float speed = 8f;

    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        spaceBar = 0;
    }

    void Update()
    {
        // ������ ���� ��
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //�����̽���
            {
                spaceBar++;
            }
            if (spaceBar >= 50)
            {
                //step�� 1�� ����
                GameObject.Find("GameManager").GetComponent<GameManager>().step++;
                Evolution();
            }
        }
        else
        {
            Player_Move();
        }
    }

    // *     ������ �Լ�     *
    void Player_Move()
    {
        // *       ������ ����        *
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);

        playerRigidbody.velocity = newVelocity;

        // *     ���� ��ȯ     *
        if (xInput < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (xInput > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        // *      ���ġ�� ���ΰ�?      *
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            GetComponent<Animator>().SetBool("isSwimming", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isSwimming", false);
        }
    }

    // *     ������ ��ȭ     *
    public void Evolution()
    {
        //2, �� ��ȭ�� ��ì�̷� ����
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 1)
        {
            GetComponent<Animator>().SetInteger("step", 1); //�ִϸ����� ���� step 1�� �ٲ�
            playerCollider.size = new Vector3(2.7f, 1.516f, 1f); //�ݶ��̴� ������ ����

            // *     ���� 10�� ����     *
            GameObject.Find("GameManager").GetComponent<GameManager>().charm += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().intell += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().wealth += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().inqMind += 10;
        }
        //3, �޴ٸ��� ���� ��ì�̷� ����
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 2)
        {
            GetComponent<Animator>().SetInteger("step", 2);
            speed = 10f;
            GameObject.Find("GameManager").GetComponent<GameManager>().feedCount = 0;

            // *     ���� 10�� ����     *
            GameObject.Find("GameManager").GetComponent<GameManager>().charm += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().intell += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().wealth += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().inqMind += 10;
        }
        //4, �մٸ��� ���� ��ì�̷� ����
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 3)
        {
            GetComponent<Animator>().SetInteger("step", 3); //�ִϸ����� ���� step 3�� �ٲ�
            speed = 11f;
            playerCollider.size = new Vector3(3.723f, 1.646f, 1f); //�ݶ��̴� ������ ����
            GameObject.Find("GameManager").GetComponent<GameManager>().feedCount = 0;

            // *     ���� 10�� ����     *
            GameObject.Find("GameManager").GetComponent<GameManager>().charm += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().intell += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().wealth += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().inqMind += 10;
        }
        //5, ���� ª�� �������� ����
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 4)
        {
            GetComponent<Animator>().SetInteger("step", 4); //�ִϸ����� ���� step 4�� �ٲ�
            playerCollider.size = new Vector3(3.402719f, 1.952039f, 1f); //�ݶ��̴� ������ ����
            GameObject.Find("GameManager").GetComponent<GameManager>().feedCount = 0;

            // *     ���� 10�� ����     *
            GameObject.Find("GameManager").GetComponent<GameManager>().charm += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().intell += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().wealth += 10;
            GameObject.Find("GameManager").GetComponent<GameManager>().inqMind += 10;
        }
    }
}
