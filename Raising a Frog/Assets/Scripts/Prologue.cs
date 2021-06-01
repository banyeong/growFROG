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
    private string m_text = "��ì���� ������ ���Ͽ�\n���̸� ������ ����!\n\n�ູ�� ���� ���ؼ����\n����� Ư�Ƶ� ���� �� ��!\n\n�������� �̷��� ���Ͽ�! Go Go, ��ì��!";

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
        // * ù ��° Ÿ���� *
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
