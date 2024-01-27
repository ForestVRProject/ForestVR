using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoCtrl : MonoBehaviour
{
    public GameObject RImage;
    public VideoPlayer video;
    public VideoClip child2;
    public VideoClip adult1;
    public VideoClip adult2;
    private void Start()
    {
        StartCoroutine(VideoControl());
    }

    IEnumerator VideoControl()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                video.Play();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                video.clip = child2;
                video.Play();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                video.clip = adult1;
                video.Play();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                video.clip = adult2;
                video.Play();
            }
            yield return new WaitWhile(() => video.isPlaying == true);
        }
    }
}
