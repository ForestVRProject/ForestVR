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
    public VideoClip child1;
    public VideoClip child2;
    public VideoClip adult1;
    public VideoClip adult2;
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
        video.clip = adult1;
        video.Play();
    }
    public void Answer1()
    {
        video.clip = child1;
        video.Play();
    }
    public void Write2()
    {
        video.clip = adult2;
        video.Play();
    }
    public void Answer2()
    {
        video.clip = child2;
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
