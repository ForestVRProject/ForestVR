using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UnityWebRequestGet());
    }

    IEnumerator UnityWebRequestGet()
    {
        string jobId = "41f1cdc2ff58bb5fdc287be0db2a8df3";
        string jobGrowId = "df3870efe8e8754011cd12fa03cd275f";


        string url = $"https://api.neople.co.kr/df/skills/{jobId}?jobGrowId={jobGrowId}&apikey=2zjY0ULmomyhW6gI2Biv4HrSSLO2W5j2";
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
}
