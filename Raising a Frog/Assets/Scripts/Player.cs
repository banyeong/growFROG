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
            if (click >= 100)
            {
                //step�� 1�� ����
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
