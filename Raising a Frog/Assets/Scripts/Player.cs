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
            // *       ������ ����        *
            float xInput = Input.GetAxis("Horizontal");
            float yInput = Input.GetAxis("Vertical");

            float xSpeed = xInput * speed;
            float ySpeed = yInput * speed;

            Vector2 newVelocity = new Vector2(xSpeed, ySpeed);

            playerRigidbody.velocity = newVelocity;

            //
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
    }

    // *     ������ ��ȭ     *
    public void Evolution()
    {
        //2, �� ��ȭ�� ��ì�̷� ����
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 1)
        {
            GetComponent<Animator>().SetInteger("step", 1); //�ִϸ����� ���� step 1�� �ٲ�
            playerCollider.size = new Vector3(2.7f, 1.516f, 1f); //�ݶ��̴� ������ ����
        }
        //3, �޴ٸ��� ���� ��ì�̷� ����
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 2)
        {
            GetComponent<Animator>().SetInteger("step", 2); //�ִϸ����� ���� step 2�� �ٲ�
            speed = 10f;
            //playerCollider.size = new Vector3(2.7f, 1.516f, 1f); //�ݶ��̴� ������ ����
        }
        //4, �մٸ��� ���� ��ì�̷� ����
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 3)
        {
            GetComponent<Animator>().SetInteger("step", 3); //�ִϸ����� ���� step 3�� �ٲ�
            speed = 11f;
            playerCollider.size = new Vector3(3.723f, 1.646f, 1f); //�ݶ��̴� ������ ����
        }
    }
}
