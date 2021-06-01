using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_BTN : MonoBehaviour
{
    // *    ����ȭ������     *
    public void Go_Prologue()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        GetComponent<AudioSource>().Play();
        
        SceneManager.LoadScene("Prologue");
        gameManager.spaceON = false;
        gameManager.space_time = 0f;
    }

    public void Load()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        GetComponent<AudioSource>().Play();

        gameManager.charm = PlayerPrefs.GetInt("charm");
        gameManager.intell = PlayerPrefs.GetInt("intell");
        gameManager.inqMind = PlayerPrefs.GetInt("inqMind");
        gameManager.wealth = PlayerPrefs.GetInt("wealth");
        gameManager.step = PlayerPrefs.GetInt("step");
        gameManager.feedCount = PlayerPrefs.GetInt("feedCount");

        gameManager.is_Load = true;
        gameManager.blockStat = true;

        SceneManager.LoadScene("Main");
    }

    // *    Ÿ��Ʋ��     *
    public void Go_Title()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Title");
    }

    // *    ���� ����    *
    public void Exit_Game()
    {
        GetComponent<AudioSource>().Play();
#if UNITY_EDITOR //�������϶�
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
