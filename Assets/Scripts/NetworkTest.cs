using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(UnityWebRequestGet());
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

    IEnumerator UnityWebRequestPOSTTEST()
    {
        
        string url = "POST 통신을 사용할 서버 주소를 입력";
        WWWForm form = new WWWForm();
        string id = "아이디";
        string pw = "비밀번호";
        form.AddField("Username", id);
        form.AddField("Password", pw);
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
    
    /*public AudioSource UserVoice()
    {
        return;
    }*/
}
