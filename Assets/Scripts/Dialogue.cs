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
                yield return new WaitForSeconds(0.6f);
                VideoCtrl.instance.ShowVideo();
            }
            else if (i == 42)
            {
                VideoCtrl.instance.HideVideo();
                yield return new WaitWhile(() => Elevator.instance._goingDown);
            }
            else if (i == 44)
            {
                VideoCtrl.instance.Answer1();
                yield return new WaitForSeconds(0.6f);
                VideoCtrl.instance.ShowVideo();
            }
            else if (i == 49)
            {
                VideoCtrl.instance.HideVideo();
                yield return new WaitUntil(() => GameObject.Find("Trigger").GetComponent<Trigger>().isTrigger);
                GameObject.Find("Trigger").GetComponent<Trigger>().isTrigger = false;
            }
            else if (i == 53)
            {
                yield return new WaitUntil(() => GameObject.Find("Trigger2").GetComponent<Trigger>().isTrigger);
                GameObject.Find("Trigger2").GetComponent<Trigger>().isTrigger = false;
            }
            else if (i == 67)
            {
                SelectDialogue();
                btn1.GetComponent<Button>().onClick.AddListener(SelectBtn1);
                btn2.GetComponent<Button>().onClick.AddListener(SelectBtn2);
                yield return new WaitUntil(() => isSelected);
                isSelected = false;
                if (no)
                {
                    i = 72;
                    Guide.instance.i = 72;
                    no = false;
                    continue;
                }
            }
            else if (i == 130)
            {
                SelectDialogue();
                btn1.GetComponent<Button>().onClick.AddListener(SelectBtn1);
                btn2.GetComponent<Button>().onClick.AddListener(SelectBtn2);
                yield return new WaitUntil(() => isSelected);
                isSelected = false;
                if (no)
                {
                    i = 138;
                    Guide.instance.i = 138;
                    no = false;
                    continue;
                }
            }
            else if (i == 140)
            {
                SelectDialogue();
                btn1.GetComponent<Button>().onClick.AddListener(SelectBtn1);
                btn2.GetComponent<Button>().onClick.AddListener(SelectBtn2);
                yield return new WaitUntil(() => isSelected);
                isSelected = false;
                if (no)
                {
                    i = 150;
                    Guide.instance.i = 150;
                    no = false;
                    continue;
                }
            }
            else if (i == 155)
            {
                SelectDialogue();
                btn1.GetComponent<Button>().onClick.AddListener(SelectBtn1);
                btn2.GetComponent<Button>().onClick.AddListener(SelectBtn2);
                yield return new WaitUntil(() => isSelected);
                isSelected = false;
                if (no)
                {
                    i = 159;
                    Guide.instance.i = 159;
                    no = false;
                    continue;
                }
            }
            else if (i == 160)
            {
                SelectDialogue();
                btn1.GetComponent<Button>().onClick.AddListener(SelectBtn1);
                btn2.GetComponent<Button>().onClick.AddListener(SelectBtn2);
                yield return new WaitUntil(() => isSelected);
                isSelected = false;
                if (no)
                {
                    i = 166;
                    Guide.instance.i = 166;
                    no = false;
                    continue;
                }
                VideoCtrl.instance.Answer2();
                yield return new WaitForSeconds(0.6f);
                VideoCtrl.instance.ShowVideo();
            }
            else if (i == 165)
            {
                VideoCtrl.instance.HideVideo();
            }
            else if (i == 167)
            {
                SelectDialogue();
                btn1.GetComponent<Button>().onClick.AddListener(SelectBtn1);
                btn2.GetComponent<Button>().onClick.AddListener(SelectBtn2);
                yield return new WaitUntil(() => isSelected);
                isSelected = false;
                if (no)
                {
                    i = 176;
                    Guide.instance.i = 176;
                    no = false;
                    continue;
                }
                VideoCtrl.instance.Write2();
                yield return new WaitForSeconds(0.6f);
                VideoCtrl.instance.ShowVideo();
            }
            else if (i == 175)
            {
                VideoCtrl.instance.HideVideo();
            }
            else if (i == 179)
            {
                Color alpha1 = VideoCtrl.instance.blackout2.color;
                alpha1.a = 0;
                VideoCtrl.instance.blackout2.gameObject.SetActive(true);
                time_fade = 0f;
                while (alpha1.a < 1f)
                {
                    time_fade += Time.deltaTime / F_time;
                    alpha1.a = Mathf.Lerp(0, 1, time_fade);
                    VideoCtrl.instance.blackout2.color = alpha1;
                    yield return null;
                }
                VideoCtrl.instance.Ending();
                yield return new WaitForSeconds(0.6f);
                VideoCtrl.instance.ShowVideo();
            }
            else if (i == 186)
            {
                yield return new WaitWhile(()=>VideoCtrl.instance.video.isPlaying);
                SceneManager.LoadScene("OutroChild");
            }
            else if (i == 190)
            {
                yield break;
            }
            i++;
            yield return new WaitForSeconds(1);
        }
    }
}
