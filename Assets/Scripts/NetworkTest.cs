using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkTest : MonoBehaviour
{
    int sampleRate = 44100;
    public float[] samples;
    public float rmsValue;
    public float modulate;
    public int resultValue;
    public int cutValue;
    // Start is called before the first frame update
    void Start()
    {
        samples = new float[sampleRate];
        //StartCoroutine(UnityWebRequestGet());
    }

    private void Update()
    {
        UserVoice();
    }

    IEnumerator UnityWebRequestGet()
    {
        string apikey = "";

        string url = $"https://api.neople.co.kr/df/skills/jobId?jobGrowId=jobGrowId&apikey={apikey}";
        UnityWebRequest www = UnityWebRequest.Get(url); //��û�� ����

        yield return www.SendWebRequest();

        if (www.error == null)
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log("ERROR");
        }
    }

    IEnumerator UnityWebRequestPOSTTEST()
    {
        
        string url = "POST ����� ����� ���� �ּҸ� �Է�";
        WWWForm form = new WWWForm();
        string id = "���̵�";
        string pw = "��й�ȣ";
        form.AddField("Username", id);
        form.AddField("Password", pw);
        UnityWebRequest www = UnityWebRequest.Post(url, form);  // ���� �ּҿ� ������ �Է�

        yield return www.SendWebRequest();  // ���� ���

        if (www.error == null)
        {
            Debug.Log(www.downloadHandler.text);    // ������ ���
        }
        else
        {
            Debug.Log("error");
        }
    }
    
    public void UserVoice()
    {
        AudioClip aud = Microphone.Start(Microphone.devices[0].ToString(), true, 1, sampleRate);
        aud.GetData(samples, 0);
        float sum = 0;
        for(int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i];
        }
        rmsValue = Mathf.Sqrt(sum / samples.Length);
        rmsValue = rmsValue * modulate;
        rmsValue = Mathf.Clamp(rmsValue, 0, 100);
        resultValue = Mathf.RoundToInt(rmsValue);
        if (resultValue < cutValue)
            resultValue = 0;
    }
}
