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
    public string message = "jerry��, ���� �������� � ���� ��ó�� [����]���� ���� ��ó�ΰ���?";
    public AudioClip aud;
    public Animator anim; //hug anim test
    // Start is called before the first frame update
    void Start()
    {
        samples = new float[sampleRate];
        aud = GetComponent<AudioSource>();
        //StartCoroutine(UnityWebRequestStartConversationPOST());
        //StartCoroutine(UnityWebRequestContinueConversationPOST(conversation_id, message));
        StartCoroutine(UnityWebRequestKoreanTextRecognitionPOST());
        //StartCoroutine(UnityWebRequestGet());
        anim = GetComponent<Animator>();//hug anim test
    }

    IEnumerator UnityWebRequestKoreanTextSynthesisPOST()
    {
        string url = "";
        WWWForm form = new WWWForm();
        UnityWebRequest www = UnityWebRequest.Post(url, form); //��û�� ����

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
        form.AddField("username", username);
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
    IEnumerator UnityWebRequestContinueConversationPOST(string conversation_id, string message)
    {
        string url = "http://sd-church.duckdns.org:8000/continue_conversation}";
        WWWForm form = new WWWForm();
        form.AddField("conversation_id", conversation_id);
        form.AddField("message", message);
        //form.AddField("Password", pw);
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
    IEnumerator UnityWebRequestKoreanTextRecognitionPOST()
    {
        string url = "http://sd-church.duckdns.org:8000/korean-text-recognition";
        WWWForm form = new WWWForm();
        form.AddBinaryData("file", null, "Assets/2.mp3");
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
        aud.clip = Microphone.Start(Microphone.devices[0].ToString(), false, 5, sampleRate); //���� 5��
        EncodeMP3.convert(aud.clip, Application.dataPath + $"UserVoice{voiceNum}", 128); //������ clip�� mp3 ���Ϸ� ��ȯ�ؼ� �ش� ��ο� ����
        voiceNum += 1;
        /*aud.GetData(samples, 0);
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
        */
    }
}
