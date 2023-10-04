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
    public string conversation_id = "1fa05011-697a-4c7d-9daa-01d9bc0a7047";
    public string message = "jerry님, 지금 떠오르는 어린 시절 상처는 [누구]에게 받은 상처인가요?";
    public AudioClip aud;
    // Start is called before the first frame update
    void Start()
    {
        samples = new float[sampleRate];
        //StartCoroutine(UnityWebRequestStartConversationPOST());
        //StartCoroutine(UnityWebRequestContinueConversationPOST(conversation_id, message));
        StartCoroutine(UnityWebRequestKoreanTextRecognitionPOST());
        //StartCoroutine(UnityWebRequestGet());
    }

    private void Update()
    {
        //UserVoice();
    }

    IEnumerator UnityWebRequestGet()
    {
        string apikey = "";

        string url = $"https://api.neople.co.kr/df/skills/jobId?jobGrowId=jobGrowId&apikey={apikey}";
        UnityWebRequest www = UnityWebRequest.Get(url); //요청을 보냄

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

    IEnumerator UnityWebRequestStartConversationPOST()
    {
        string url = "http://sd-church.duckdns.org:8000/start_conversation";
        WWWForm form = new WWWForm();
        string username = "jerry";
        string test_data = "jerry is testing post";
        //string pw = "비밀번호";
        form.AddField("username", username);
        form.AddField("Data", test_data);
        //form.AddField("Password", pw);
        UnityWebRequest www = UnityWebRequest.Post(url, form);  // 보낼 주소와 데이터 입력

        yield return www.SendWebRequest();  // 응답 대기

        if (www.error == null)
        {
            Debug.Log(www.downloadHandler.text);    // 데이터 출력
        }
        else
        {
            Debug.Log("error");
        }
    }
    IEnumerator UnityWebRequestContinueConversationPOST(string conversation_id, string message)
    {
        string url = "http://sd-church.duckdns.org:8000/continue_conversation/1fa05011-697a-4c7d-9daa-01d9bc0a7047?message=jerry%EB%8B%98%2C%20%EC%A7%80%EA%B8%88%20%EB%96%A0%EC%98%A4%EB%A5%B4%EB%8A%94%20%EC%96%B4%EB%A6%B0%20%EC%8B%9C%EC%A0%88%20%EC%83%81%EC%B2%98%EB%8A%94%20%5B%EB%88%84%EA%B5%AC%5D%EC%97%90%EA%B2%8C%20%EB%B0%9B%EC%9D%80%20%EC%83%81%EC%B2%98%EC%9D%B8%EA%B0%80%EC%9A%94%3F";
        WWWForm form = new WWWForm();
        //string pw = "비밀번호";
        form.AddField("conversation_id", conversation_id);
        form.AddField("message", message);
        //form.AddField("Password", pw);
        UnityWebRequest www = UnityWebRequest.Post(url, form);  // 보낼 주소와 데이터 입력

        yield return www.SendWebRequest();  // 응답 대기

        if (www.error == null)
        {
            Debug.Log(www.downloadHandler.text);    // 데이터 출력
        }
        else
        {
            Debug.Log("error");
        }
    }
    IEnumerator UnityWebRequestKoreanTextRecognitionPOST()
    {
        string url = "http://sd-church.duckdns.org:8000/korean-text-recognition";
        WWWForm form = new WWWForm();
        //string pw = "비밀번호";
        form.AddField("file", "Assets/2.mp3");
        //form.AddField("Password", pw);
        UnityWebRequest www = UnityWebRequest.Post(url, form);  // 보낼 주소와 데이터 입력

        yield return www.SendWebRequest();  // 응답 대기

        if (www.error == null)
        {
            Debug.Log(www.downloadHandler.text);    // 데이터 출력
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
