using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [Tooltip("대사")]
    [SerializeField]
    private string[] girl_eng_txt;
    [SerializeField]
    private string[] boy_eng_txt;
    public int i = 0;
    public bool isSelected = false;
    public bool no = false;
    public bool newborn = false;
    public bool toddler = false;
    public bool child = false;
    public bool teenager = false;
    public bool playground = false;
    public bool momcook = false;
    public bool dadhorses = false;
    public bool hand = false;
    public bool chair = false;
    //public TextMeshProUGUI textShow;
    public GameObject btn1;
    public GameObject btn2;
    public GameObject newbornBtn;
    public GameObject toddlerBtn;
    public GameObject childBtn;
    public GameObject teenagerBtn;
    public GameObject playgroundBtn;
    public GameObject momcookBtn;
    public GameObject dadhorsesBtn;
    public GameObject handBtn;
    public GameObject chairBtn;
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

    public void LateUpdate()
    {
        IsCameraFacingBack();
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
                newbornBtn = GameObject.Find("NewBornBtn");
                toddlerBtn = GameObject.Find("ToddlerBtn");
                childBtn = GameObject.Find("ChildBtn");
                teenagerBtn = GameObject.Find("TeenBtn");
                playgroundBtn = GameObject.Find("PlaygroundBtn");
                momcookBtn = GameObject.Find("MomCookBtn");
                dadhorsesBtn = GameObject.Find("DadHorseBtn");
                handBtn = GameObject.Find("HandBtn");
                chairBtn = GameObject.Find("ChairBtn");
                btn1.SetActive(false);
                btn2.SetActive(false);
                newbornBtn.SetActive(false);
                toddlerBtn.SetActive(false);
                childBtn.SetActive(false);
                teenagerBtn.SetActive(false);
                playgroundBtn.SetActive(false);
                momcookBtn.SetActive(false);
                dadhorsesBtn.SetActive(false);
                handBtn.SetActive(false);
                chairBtn.SetActive(false);
                //textShow = GameObject.Find("TextData").GetComponent<TextMeshProUGUI>();
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act18");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act18");
                }
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

    public void SelectTime()
    {
        newbornBtn.SetActive(true);
        toddlerBtn.SetActive(true);
        childBtn.SetActive(true);
        teenagerBtn.SetActive(true);
    }

    public void SelectMemory()
    {
        playgroundBtn.SetActive(true);
        momcookBtn.SetActive(true);
        dadhorsesBtn.SetActive(true);
        handBtn.SetActive(true);
        chairBtn.SetActive(true);
    }

    public void NewBornBtn()
    {
        newbornBtn.SetActive(false);
        toddlerBtn.SetActive(false);
        childBtn.SetActive(false);
        teenagerBtn.SetActive(false);
        newborn = true;
        isSelected = true;
    }

    public void ToddlerBtn()
    {
        newbornBtn.SetActive(false);
        toddlerBtn.SetActive(false);
        childBtn.SetActive(false);
        teenagerBtn.SetActive(false);
        toddler = true;
        isSelected = true;
    }

    public void ChildBtn()
    {
        newbornBtn.SetActive(false);
        toddlerBtn.SetActive(false);
        childBtn.SetActive(false);
        teenagerBtn.SetActive(false);
        child = true;
        isSelected = true;
    }
    public void TeenagerBtn()
    {
        newbornBtn.SetActive(false);
        toddlerBtn.SetActive(false);
        childBtn.SetActive(false);
        teenagerBtn.SetActive(false);
        teenager = true;
        isSelected = true;
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

    public void PlaygroundBtn()
    {
        playgroundBtn.SetActive(false);
        momcookBtn.SetActive(false);
        dadhorsesBtn.SetActive(false);
        handBtn.SetActive(false);
        chairBtn.SetActive(false);
        playground = true;
        isSelected = true;
    }
    public void MomCookBtn()
    {
        playgroundBtn.SetActive(false);
        momcookBtn.SetActive(false);
        dadhorsesBtn.SetActive(false);
        handBtn.SetActive(false);
        chairBtn.SetActive(false);
        momcook = true;
        isSelected = true;
    }
    public void DadHorsesBtn()
    {
        playgroundBtn.SetActive(false);
        momcookBtn.SetActive(false);
        dadhorsesBtn.SetActive(false);
        handBtn.SetActive(false);
        chairBtn.SetActive(false);
        dadhorses = true;
        isSelected = true;
    }
    public void HandBtn()
    {
        playgroundBtn.SetActive(false);
        momcookBtn.SetActive(false);
        dadhorsesBtn.SetActive(false);
        handBtn.SetActive(false);
        chairBtn.SetActive(false);
        hand = true;
        isSelected = true;
    }
    public void ChairBtn()
    {
        playgroundBtn.SetActive(false);
        momcookBtn.SetActive(false);
        dadhorsesBtn.SetActive(false);
        handBtn.SetActive(false);
        chairBtn.SetActive(false);
        chair = true;
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
            if (i == 73)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act28");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act28");
                }
            }
            if (i == 77)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act23");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act23");
                }
            }
            if (i == 84)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act21");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act21");
                }
            }
            if (i == 91)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act21");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act21");
                }
            }
            if (i == 99)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act23");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act23");
                }
            }
            if (i == 124)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act27");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act27");
                }
            }
            if (i == 126)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act28");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act28");
                }
            }
            if (i == 131)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act24");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act24");
                }
            }
            if (i == 133)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act2930");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act2930");
                }
            }
            if (i == 134)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act32");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act32");
                }
            }
            if (i == 142)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act31");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act31");
                }
            }
            if (i == 145)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act32");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act32");
                }
            }
            if (i == 148)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act32_2");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act32_2");
                }
            }
            if (i == 159)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Innerchild>().FadeOut();
                    yield return new WaitUntil(() => GameObject.Find("InnerchildGirl").GetComponent<Innerchild>().hug);
                    yield return new WaitForSeconds(3);
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Innerchild>().FadeOut();
                    yield return new WaitUntil(() => GameObject.Find("InnerchildBoy").GetComponent<Innerchild>().hug);
                    yield return new WaitForSeconds(3);
                }
            }
            Guide.instance.GuideSwitch();
            yield return new WaitWhile(() => Guide.instance.guideAud.isPlaying);
            if (i == 25)
            {
                Debug.Log("Turn to Back");
                yield return new WaitUntil(() => IsCameraFacingBack());
            }
            else if (i == 33)
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
                yield return new WaitUntil(() => GameObject.Find("BTrigger").GetComponent<Trigger>().isTrigger);
                GameObject.Find("BTrigger").GetComponent<Trigger>().isTrigger = false;
            }
            else if (i == 60)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act19");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act19");
                }
            }
            else if (i == 62)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act21");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act21");
                }
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
            else if (i == 74)
            {
                SelectTime();
                newbornBtn.GetComponent<Button>().onClick.AddListener(NewBornBtn);
                toddlerBtn.GetComponent<Button>().onClick.AddListener(ToddlerBtn);
                childBtn.GetComponent<Button>().onClick.AddListener(ChildBtn);
                teenagerBtn.GetComponent<Button>().onClick.AddListener(TeenagerBtn);
                yield return new WaitUntil(() => isSelected);
                isSelected = false;
                if (newborn)
                {
                    i++;
                    Guide.instance.i++;
                    continue;
                }
                else if (toddler)
                {
                    i = 80;
                    Guide.instance.i = 80;
                    continue;
                }
                else if (child)
                {
                    i = 87;
                    Guide.instance.i = 87;
                    continue;
                }
                else if (teenager)
                {
                    i = 96;
                    Guide.instance.i = 96;
                    continue;
                }
            }
            else if (i == 79 || i == 86 || i == 95)
            {
                i = 102;
                Guide.instance.i = 102;
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act22");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act22");
                }
                continue;
            }
            else if (i == 103)
            {
                SelectMemory();
                playgroundBtn.GetComponent<Button>().onClick.AddListener(PlaygroundBtn);
                momcookBtn.GetComponent<Button>().onClick.AddListener(MomCookBtn);
                dadhorsesBtn.GetComponent<Button>().onClick.AddListener(DadHorsesBtn);
                handBtn.GetComponent<Button>().onClick.AddListener(HandBtn);
                chairBtn.GetComponent<Button>().onClick.AddListener(ChairBtn);
                yield return new WaitUntil(() => isSelected);
                isSelected = false;
                if (playground)
                {
                    i++;
                    Guide.instance.i++;
                    if (Guide.instance.isGirl)
                    {
                        GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act21");
                    }
                    else
                    {
                        GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act21");
                    }
                    continue;
                }
                else if (momcook)
                {
                    i = 108;
                    Guide.instance.i = 108;
                    if (Guide.instance.isGirl)
                    {
                        GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act21");
                    }
                    else
                    {
                        GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act21");
                    }
                    continue;
                }
                else if (dadhorses)
                {
                    i = 111;
                    Guide.instance.i = 111;
                    if (Guide.instance.isGirl)
                    {
                        GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act21");
                    }
                    else
                    {
                        GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act21");
                    }
                    continue;
                }
                else if (hand)
                {
                    i = 113;
                    Guide.instance.i = 113;
                    if (Guide.instance.isGirl)
                    {
                        GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act25");
                    }
                    else
                    {
                        GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act25");
                    }
                    continue;
                }
                else if (chair)
                {
                    i = 116;
                    Guide.instance.i = 116;
                    if (Guide.instance.isGirl)
                    {
                        GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act26");
                    }
                    else
                    {
                        GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act26");
                    }
                    continue;
                }
            }
            else if (i == 107 || i == 110 || i == 112 || i == 115)
            {
                i = 119;
                Guide.instance.i = 119;
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act23");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act23");
                }
                continue;
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
                    i = 151;
                    Guide.instance.i = 151;
                    no = false;
                    continue;
                }
            }
            else if (i == 151)
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
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Innerchild>().ChangeColor();
                    yield return new WaitUntil(() => GameObject.Find("InnerchildGirl").GetComponent<Innerchild>().changed);
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Innerchild>().ChangeColor();
                    yield return new WaitUntil(() => GameObject.Find("InnerchildBoy").GetComponent<Innerchild>().changed);
                }
            }
            else if (i == 152)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act35");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act35");
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
            else if (i == 158)
            {
                if (Guide.instance.isGirl)
                {
                    GameObject.Find("InnerchildGirl").GetComponent<Animator>().SetTrigger("Act36");
                }
                else
                {
                    GameObject.Find("InnerchildBoy").GetComponent<Animator>().SetTrigger("Act36");
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

    public bool IsCameraFacingBack()
    {
        // Main Camera를 찾음
        GameObject mainCamera = GameObject.FindWithTag("MainCamera");

        if (mainCamera != null)
        {
            // Main Camera의 forward 방향
            Vector3 cameraForward = mainCamera.transform.forward;
            
            // World forward 방향
            Vector3 worldUp = Vector3.forward;
            
            // 두 벡터의 내적 계산
            float dotProduct = Vector3.Dot(cameraForward, worldUp);

            // 내적이 0보다 작으면 카메라가 뒤를 보고 있는 것으로 간주
            if (dotProduct < 0)
            {
                return true;
            }
        }

        // 그 외의 경우에는 false 반환
        return false;
    }
}
