using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [Tooltip("대사")]
    [SerializeField]
    private string[] textdata;
    public int i = 0;
    public bool isSelected = false;
    public TextMeshProUGUI textShow;
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;

    private void Start()
    {
        Invoke("StartText", 3f);
    }

    public void StartText()
    {
        StartCoroutine(SwitchText());
    }

    IEnumerator SwitchText()
    {
        while (true)
        {
            Guide.instance.GuideSwitch();
            textShow.SetText(textdata[i]);
            yield return new WaitWhile(()=> Guide.instance.guideAud.isPlaying == true);
            if (i == 4)
            {
                SelectDialogue();
                yield return new WaitWhile(() => isSelected == false);
                continue;
            }
            i++;
            yield return new WaitForSeconds(1);
        }
    }

    public void SelectDialogue()
    {
        btn1.SetActive(true);
        btn2.SetActive(true);
        btn3.SetActive(true);
    }

    public void SelectBtn1()
    {
        //특정 번호의 대사로 이동
        i = 6;
        Guide.instance.i = 6;
        btn1.SetActive(false);
        btn2.SetActive(false);
        btn3.SetActive(false);
        isSelected = true;
    }

    public void SelectBtn2()
    {
        i = 8;
        Guide.instance.i = 8;
        btn1.SetActive(false);
        btn2.SetActive(false);
        btn3.SetActive(false);
        isSelected = true;
    }

    public void SelectBtn3()
    {
        i = 7;
        Guide.instance.i = 7;
        btn1.SetActive(false);
        btn2.SetActive(false);
        btn3.SetActive(false);
        isSelected = true;
    }
}
