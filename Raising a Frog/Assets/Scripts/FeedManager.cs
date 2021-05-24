using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedManager : MonoBehaviour
{
    // *     생성할 먹이의 원본 프리팹     *
    public GameObject feedPrefab;
    // *     생성 주기      *
    public float spawnRateMin = 0.5f; //최소
    public float spawnRateMax = 1.0f; //최대
    private float spawnRate; //생성 주기
    private float timeAfterSpawn; // 생성 시점에서 지난 시간
    // *     생성 위치      *
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
        // *     부화한 이후에만 먹이 생성     *
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

    // *     위치 선정 함수     *
    void FeedPos()
    {
        float randomX = Random.Range(posMin, posMax);
        float randomY = Random.Range(posMin, posMax);
        feedPos = new Vector3(randomX, randomY, 1);
    }

    // *     먹은 먹이 갯수에 따라 Evolution 호출     *
    void FeedCountCheck()
    {
        // 막 부화한 올챙이거나, 뒷다리 나온 올챙이일 때
        if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 1
            || GameObject.Find("GameManager").GetComponent<GameManager>().step == 2)
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().feedCount == 15)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().step++;
                GameObject.Find("Player").GetComponent<Player>().Evolution();
            }
        }
        // 앞다리 나온 올챙이일 때
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 3)
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().feedCount == 20)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().step++;
                GameObject.Find("Player").GetComponent<Player>().Evolution();
            }
        }
        // 꼬리 짧은 개구리일 때 -> 5, 6 하나를 입력받아 정상이나 돌연변이 개구리로 바꿈
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().step == 4)
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().feedCount == 20)
            {
                int random = Random.Range(5, 8); // 5와 7 중에서 랜덤으로 추출
                if (random == 7) random = 6;
                GameObject.Find("GameManager").GetComponent<GameManager>().step = random;
                GameObject.Find("Player").GetComponent<Player>().Evolution();
            }
        }
    }
}
