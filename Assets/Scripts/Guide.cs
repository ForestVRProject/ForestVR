using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public static Guide instance;
    public AudioSource guideAud;
    public AudioClip[] girl_eng;
    public AudioClip[] boy_eng;
    public bool isEnglish = true;
    public bool isGirl = true;
    public int i = 0;
    private AudioClip[] voice;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Duplicated Guide, ignoring this one",gameObject);
        }
    }

    public void GuideSwitch()
    {
        guideAud.clip = voice[i];
        guideAud.Play();
        i++;
    }

    public void SetEnglish()
    {
        this.isEnglish = true;
    }

    public void SetKorean()
    {
        this.isEnglish = false;
    }

    public void SetGirl()
    {
        this.isGirl = true;
    }

    public void SetBoy()
    {
        this.isGirl = false;
    }

    public void SetVoice()
    {
        if(isEnglish && isGirl)
        {
            voice = girl_eng;
        }
        else if(isEnglish && !isGirl)
        {
            voice = boy_eng;
        }
        else
        {
            voice = girl_eng;
        }
    }
}
