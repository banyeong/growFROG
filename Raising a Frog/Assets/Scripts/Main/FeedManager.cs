using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedManager : MonoBehaviour
{
    // *     ������ ������ ���� ������     *
    public GameObject feedPrefab;
    // *     ���� �ֱ�      *
    public float spawnRateMin = 0.5f; //�ּ�
    public float spawnRateMax = 1.0f; //�ִ�
    private float spawnRate; //���� �ֱ�
    private float timeAfterSpawn; // ���� �������� ���� �ð�
    // *     ���� ��ġ      *
    private float posMin = -3.0f;
    private float posMax = 3.0f;
    Vector3 feedPos;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    void Update()
    {
        // *     ��ȭ�� ���Ŀ��� ���� ����     *
        if (GameObject.Find("GameManager").GetComponent<GameManager>().isPopUpON == false)
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().step > 0)
            {
                timeAfterSpawn += Time.deltaTime;
                if (timeAfterSpawn >= spawnRate)
                {
                    timeAfterSpawn = 0f;
                    FeedPos();

                    GameObject feed = Instantiate(feedPrefab, feedPos, Quaternion.identity);

                    spawnRate = Random.Range(spawnRateMin, spawnRateMax);
                }
            }
            FeedCountCheck();
        }
    }

    // *     ��ġ ���� �Լ�     *
    void FeedPos()
    {
        float randomX = Random.Range(posMin, posMax);
        float randomY = Random.Range(posMin, posMax);
        feedPos = new Vector3(randomX, randomY, 1);
    }

    // *     ���� ���� ������ ���� Evolution ȣ��     *
    void FeedCountCheck()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // �� ��ȭ�� ��ì�̰ų�, �޴ٸ� ���� ��ì���� ��
        if (gameManager.step == 1 || gameManager.step == 2)
        {
            if (gameManager.feedCount == 15)
            {
                gameManager.step++;
                GameObject.Find("Player").GetComponent<Player>().Evolution();
            }
        }
        // �մٸ� ���� ��ì���� ��
        else if (gameManager.step == 3)
        {
            if (gameManager.feedCount == 20)
            {
                gameManager.step++;
                GameObject.Find("Player").GetComponent<Player>().Evolution();
            }
        }
        // ���� ª�� �������� �� -> 5, 6 �ϳ��� �Է¹޾� �����̳� �������� �������� �ٲ�
        else if (gameManager.step == 4)
        {
            if (gameManager.feedCount == 20)
            {
                int random = Random.Range(5, 8); // 5�� 7 �߿��� �������� ����
                if (random == 7) random = 6;
                gameManager.step = random;
                GameObject.Find("Player").GetComponent<Player>().Evolution();
            }
        }
        else if (gameManager.step == 5 || gameManager.step == 6)
        {
            if (gameManager.feedCount == 25)
            {
                SceneManager.LoadScene("Ending");
            }
        }
    }
}
