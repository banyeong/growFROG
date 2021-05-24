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

    // ���̸� �԰� �ִ���, �����ϴ� ������ üũ for �ִϸ��̼�
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
        // ������ ���� ��
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //�����̽���
            {
                spaceBar++;
            }
            if (spaceBar >= 50)
            {
                //step�� 1�� ���� -> ��ȭ
                GameObject.Find("GameManager").GetComponent<GameManager>().step++;
                Evolution();
            }
        }
        else
        {
            // *     ���̸� �������� �� �ִϸ��̼� ����
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

            // *     �˾��� �������� ���� ������     *
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

    // *     ������ ��ȭ     *
    public void Evolution()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //2, �� ��ȭ�� ��ì�̷� ����
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 1)
        {
            GetComponent<Animator>().SetInteger("step", 1); //�ִϸ����� ���� step 1�� �ٲ�
            playerCollider.size = new Vector2(1.9f, 1f); //�ݶ��̴� ������ ����
            gameManager.step_Text.text = "2�ܰ�\n��ì��";

            // *     ���� 10�� ����     *
            gameManager.charm += 10;
            gameManager.intell += 10;
            gameManager.wealth += 10;
            gameManager.inqMind += 10;
        }
        //3, �޴ٸ��� ���� ��ì�̷� ����
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 2)
        {
            GetComponent<Animator>().SetInteger("step", 2);
            speed = 10f;
            gameManager.feedCount = 0;
            gameManager.step_Text.text = "3�ܰ�\n��ì��";

            // *     ���� 10�� ����     *
            gameManager.charm += 10;
            gameManager.intell += 10;
            gameManager.wealth += 10;
            gameManager.inqMind += 10;
        }
        //4, �մٸ��� ���� ��ì�̷� ����
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 3)
        {
            GetComponent<Animator>().SetInteger("step", 3); //�ִϸ����� ���� step 3�� �ٲ�
            speed = 11f;
            playerCollider.size = new Vector2(2.2f, 1.133697f); //�ݶ��̴� ������ ����
            gameManager.feedCount = 0;
            gameManager.step_Text.text = "4�ܰ�\n��ì��";

            // *     ���� 10�� ����     *
            gameManager.charm += 10;
            gameManager.intell += 10;
            gameManager.wealth += 10;
            gameManager.inqMind += 10;
        }
        //5, ���� ª�� �������� ����
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 4)
        {
            GetComponent<Animator>().SetInteger("step", 4); //�ִϸ����� ���� step 4�� �ٲ�
            playerCollider.size = new Vector2(2.163661f, 1.344424f); //�ݶ��̴� ������ ����
            gameManager.feedCount = 0;
            gameManager.step_Text.text = "5�ܰ�\n������";

            // *     ���� 15�� ����     *
            gameManager.charm += 10;
            gameManager.intell += 10;
            gameManager.wealth += 10;
            gameManager.inqMind += 10;
        }
        //6-1, �������� �������� ����
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 5)
        {
            GetComponent<Animator>().SetInteger("step", 5); //�ִϸ����� ���� step 5�� �ٲ�
            gameManager.feedCount = 0;
            gameManager.step_Text.text = "��������\n������";

            // *     ���� 10�� ����     *
            gameManager.charm -= 15;
            gameManager.intell -= 15;
            gameManager.wealth -= 15;
            gameManager.inqMind -= 15;

            gameManager.Stat_MIN();
        }
        //6-2, ���� �������� ����
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 6)
        {
            GetComponent<Animator>().SetInteger("step", 6); //�ִϸ����� ���� step 6�� �ٲ�
            gameManager.feedCount = 0;
            gameManager.step_Text.text = "������";

            // *     ���� 10�� ����     *
            gameManager.charm += 10;
            gameManager.intell += 10;
            gameManager.wealth += 10;
            gameManager.inqMind += 10;
        }
    }
}
