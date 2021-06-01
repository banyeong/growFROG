using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    public GameObject GoMain;

    int i;
    IEnumerator coroutine; bool endCoroutine = false;
    public Text prologueText;
    private string m_text = "올챙이의 성장을 위하여\n먹이를 꾸준히 먹자!\n\n행복한 삶을 위해서라면\n모험과 특훈도 잊지 말 것!\n\n성공적인 미래를 위하여! Go Go, 올챙이!";

    // Start is called before the first frame update
    void Start()
    {
        coroutine = _typing();
        StartCoroutine(_typing());
    }

    // Update is called once per frame
    void Update()
    {
        if (endCoroutine == true)
        {
            StopCoroutine(coroutine);
            GoMain.SetActive(true);
        }
    }

    IEnumerator _typing()
    {
        yield return new WaitForSeconds(0.5f);
        // * 첫 번째 타이핑 *
        for (i = 0; i <= m_text.Length; i++)
        {
            if (Input.GetMouseButton(0))
            {
                prologueText.text = m_text;
                endCoroutine = true;
                break;
            }
            prologueText.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.09f);
        }

        endCoroutine = true;
    }

    public void _GoMain()
    {
        SceneManager.LoadScene("Main");
    }
}
