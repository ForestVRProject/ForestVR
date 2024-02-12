using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [Tooltip("ด๋ป็")]
    [SerializeField]
    private string[] girl_eng_txt;
    [SerializeField]
    private string[] boy_eng_txt;
    public int i = 0;
    public bool isSelected = false;
    public bool no = false;
    //public TextMeshProUGUI textShow;
    public GameObject btn1;
    public GameObject btn2;
    //private string[] textdata;
    public Image blackout;
    float time_fade = 0f;
    [SerializeField] float F_time;

    public void TextStart()
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
            //textShow.SetText(textdata[i]);
            yield return new WaitWhile(()=> Guide.instance.guideAud.isPlaying);
            if (i == 19)
            { 
                SelectDialogue();
                yield return new WaitUntil(() => isSelected);
                isSelected = false;
                if (no)
                {
                    i = 1;
                    Guide.instance.i = 1;
                    no = false;
                    continue;
                }
                Color alpha = blackout.color;
                alpha.a = 0;
                blackout.gameObject.SetActive(true);

                while (alpha.a < 1f)
                {
                    time_fade += Time.deltaTime / F_time;
                    alpha.a = Mathf.Lerp(0, 1, time_fade);
                    blackout.color = alpha;
                    yield return null;
                }
                SceneManager.LoadScene("InnerChild");
                
                yield return new WaitUntil(() => SceneManager.GetSceneByName("InnerChild").isLoaded);
                btn1 = GameObject.Find("Btn1");
                btn2 = GameObject.Find("Btn2");
                btn1.SetActive(false);
                btn2.SetActive(false);
                //textShow = GameObject.Find("TextData").GetComponent<TextMeshProUGUI>();
                i++;
                yield return new WaitForSeconds(1);
                StartCoroutine(SwitchText2());
                yield break;
            }
            i++;
            yield return new WaitForSeconds(1);
        }
    }

    public void SelectDialogue()
    {
        btn1.SetActive(true);
        btn2.SetActive(true);
    }

    public void SelectBtn1()
    {
        btn1.SetActive(false);
        btn2.SetActive(false);
        isSelected = true;
    }

    public void SelectBtn2()
    {
        no = true;
        btn1.SetActive(false);
        btn2.SetActive(false);
        isSelected = true;
    }

    public void SetDialogue()
    {
        /*if (Guide.instance.isEnglish && Guide.instance.isGirl)
        {
            textdata = girl_eng_txt;
        }
        else if (Guide.instance.isEnglish && !Guide.instance.isGirl)
        {
            textdata = boy_eng_txt;
        }*/
    }

    IEnumerator SwitchText2()
    {
        while (true)
        {
            Guide.instance.GuideSwitch();
            yield return new WaitWhile(() => Guide.instance.guideAud.isPlaying);
            if (i == 33)
            {
                yield return new WaitUntil(() => Elevator.instance._goingDown);
            }
            else if (i == 35)
            {
                SelectDialogue();
                btn1.GetComponent<Button>().onClick.AddListener(SelectBtn1);
                btn2.GetComponent<Button>().onClick.AddListener(SelectBtn2);
                yield return new WaitUntil(() => isSelected);
                isSelected = false;
                if (no)
                {
                    i = 43;
                    Guide.instance.i = 43;
                    no = false;
                    yield return new WaitWhile(() => Elevator.instance._goingDown);
                    yield return new WaitForSeconds(1);
                    continue;
                }
                VideoCtrl.instance.Write1();
            }
            else if (i == 42)
            {
                VideoCtrl.instance.HideVideo();
                yield return new WaitWhile(() => Elevator.instance._goingDown);
            }
            else if (i == 44)
            {
                VideoCtrl.instance.Answer1();
            }
            else if (i == 49)
            {
                VideoCtrl.instance.HideVideo();
            }
            i++;
            yield return new WaitForSeconds(1);
        }
    }
}
