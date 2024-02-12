using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoCtrl : MonoBehaviour
{
    public static VideoCtrl instance;
    public GameObject RImage;
    public VideoPlayer video;
    public VideoClip child1;
    public VideoClip child2;
    public VideoClip adult1;
    public VideoClip adult2;

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

    public void Write1()
    {
        video.clip = adult1;
        video.Play();
    }
    public void Answer1()
    {
        video.clip = child1;
        RImage.SetActive(true);
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

    public void HideVideo()
    {
        RImage.SetActive(false);
    }
}
