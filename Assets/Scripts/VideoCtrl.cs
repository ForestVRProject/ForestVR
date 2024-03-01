using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoCtrl : MonoBehaviour
{
    public static VideoCtrl instance;
    public GameObject RImage;
    public Image blackout2;
    public VideoPlayer video;
    public VideoClip girl_kor_1;
    public VideoClip girl_kor_2;
    public VideoClip girl_eng_1;
    public VideoClip girl_eng_2;
    public VideoClip adult_kor_1;
    public VideoClip adult_kor_2;
    public VideoClip adult_eng_1;
    public VideoClip adult_eng_2;
    public VideoClip boy_kor_1;
    public VideoClip boy_kor_2;
    public VideoClip boy_eng_1;
    public VideoClip boy_eng_2;
    public VideoClip ending;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Duplicated VideoCtrl, ignoring this one", gameObject);
        }
    }

    private void Start()
    {
        RImage.SetActive(false);
        blackout2.gameObject.SetActive(false);
    }

    public void Write1()
    {
        if (Guide.instance.isEnglish)
        {
            video.clip = adult_eng_1;
        }
        else if (!Guide.instance.isEnglish)
        {
            video.clip = adult_kor_1;
        }
        video.Play();
    }
    public void Answer1()
    {
        if (Guide.instance.isGirl && Guide.instance.isEnglish)
        {
            video.clip = girl_eng_1;
        }
        else if(Guide.instance.isGirl && !Guide.instance.isEnglish)
        {
            video.clip = girl_kor_1;
        }
        else if (!Guide.instance.isGirl && Guide.instance.isEnglish)
        {
            video.clip = boy_eng_1;
        }
        else if (!Guide.instance.isGirl && !Guide.instance.isEnglish)
        {
            video.clip = boy_kor_1;
        }
        video.Play();
    }
    public void Write2()
    {
        if (Guide.instance.isEnglish)
        {
            video.clip = adult_eng_2;
        }
        else if (!Guide.instance.isEnglish)
        {
            video.clip = adult_kor_2;
        }
        video.Play();
    }
    public void Answer2()
    {
        if (Guide.instance.isGirl && Guide.instance.isEnglish)
        {
            video.clip = girl_eng_2;
        }
        else if (Guide.instance.isGirl && !Guide.instance.isEnglish)
        {
            video.clip = girl_kor_2;
        }
        else if (!Guide.instance.isGirl && Guide.instance.isEnglish)
        {
            video.clip = boy_eng_2;
        }
        else if (!Guide.instance.isGirl && !Guide.instance.isEnglish)
        {
            video.clip = boy_kor_2;
        }
        video.Play();
    }

    public void Ending()
    {
        video.clip = ending;
        video.Play();
    }

    public void ShowVideo()
    {
        RImage.SetActive(true);
    }

    public void HideVideo()
    {
        RImage.SetActive(false);
    }
}
