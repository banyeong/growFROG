using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip audioEat;

    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }
    public void ExtraSound(string _action)
    {
        switch (_action)
        {
            case "EAT":
                audioSource.clip = audioEat;
                break;
            case "SUCCESS":
                audioSource.clip = GameObject.Find("ButtonManager").GetComponent<Button_event>().audioSuccess;
                break;
            case "FAILURE":
                audioSource.clip = GameObject.Find("ButtonManager").GetComponent<Button_event>().audioFailure;
                break;
            case "FINAL":
                audioSource.clip = GameObject.Find("FeedManager").GetComponent<FeedManager>().final;
                break;
        }
        audioSource.Play();
    }
}
