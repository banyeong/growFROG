using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BoxCollider2D playerCollider;

    [SerializeField] //�ν����� â�� ���̱� �ϱ� ����
    private int click; //��������_�����̽��� ��Ÿ�� ����

    public Rigidbody2D playerRigidbody; //�÷��̾� ������ٵ�
    public float speed = 8f;

    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        playerRigidbody = GetComponent<Rigidbody2D>();
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
            if (click >= 50)
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

            // *      �����̴� ������      *
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
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
        //�� ��ȭ�� ��ì�̶��
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 1)
        {
            GetComponent<Animator>().SetInteger("step", 1); //�ִϸ����� ���� step 1�� �ٲ�
            playerCollider.size = new Vector3(2.7f, 1.516f, 1f); //�ݶ��̴� ������ ����
        }
    }
}
