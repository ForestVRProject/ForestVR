using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player : MonoBehaviour
{
    public static Player instance;
    private int sampleRate = 44100;
    private float[] samples; 
    public int voiceNum = 1;

    public AudioSource aud;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Duplicated Player, ignoring this one", gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void GetUserVoice()
    {
        aud.clip = Microphone.Start(Microphone.devices[0].ToString(), false, 10, sampleRate); //���� 10��
        EncodeMP3.convert(aud.clip, Application.dataPath + $"/UserVoice{voiceNum}", 128); //������ clip�� mp3 ���Ϸ� ��ȯ�ؼ� �ش� ��ο� ����
        Debug.Log("UserVoice" + voiceNum);
        voiceNum += 1;
        //Guide.instance.index++;
    }
}
