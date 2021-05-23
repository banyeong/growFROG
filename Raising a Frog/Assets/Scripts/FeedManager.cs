using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedManager : MonoBehaviour
{
    // *     ������ ������ ���� ������     *
    public GameObject feedPrefab;
    // *     ���� �ֱ�      *
    public float spawnRateMin = 1f; //�ּ�
    public float spawnRateMax = 2f; //�ִ�
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
        // �� ��ȭ�� ��ì�̰ų�, �޴ٸ� ���� ��ì���� ��
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 1
            || GameObject.Find("GameManager").GetComponent<GameManager>().step == 2)
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().feedCount == 15)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().step++;
                GameObject.Find("Player").GetComponent<Player>().Evolution();
            }
        }
        // �մٸ� ���� ��ì�̰ų�, ���� ª�� ��ì���� ��
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 3
            || GameObject.Find("GameManager").GetComponent<GameManager>().step == 4)
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().feedCount == 20)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().step++;
                GameObject.Find("Player").GetComponent<Player>().Evolution();
            }
        }
    }
}